using _5_UP0101;
using _5_UP0101.ADMINISTRATOR;
using _5_UP0101.COMPILER;
using _5_UP0101.MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace _5_UP0101
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>6
    public partial class MainWindow : Window
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var users = context.Users.ToList(); 
            bool userExists = users.Any(x => x.Login__ == loginBOX.Text.ToString());
            if (userExists)
            {
                Users user = users.First(x => x.Login__ == loginBOX.Text.ToString());
                if (PasswodBOX.Password == user.Password__)
                {
                    if (user.User_RoleID == 4)
                    {
                        Admin a = new Admin();
                        a.Show();
                        this.Close();
                    }
                    else if (user.User_RoleID == 5)
                    {
                        Compiler s = new Compiler();
                        s.Show();
                        this.Close();
                    }
                    else if (user.User_RoleID == 6)
                    {
                        Manager d = new Manager();
                        d.Show();
                        this.Close();
                    }
                }
                else if (PasswodBOX.Password == "")
                {
                    MessageBox.Show("Не все поля заполнены");
                }
                else MessageBox.Show("Пароль неверен");
            }
            else if (loginBOX.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else MessageBox.Show("Пользователя с таким логином не существует");
        }
    }
}




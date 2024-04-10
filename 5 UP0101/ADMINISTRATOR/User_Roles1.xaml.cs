using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5_UP0101.ADMINISTRATOR
{
    /// <summary>
    /// Логика взаимодействия для User_Roles.xaml
    /// </summary>
    public partial class User_Roles1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public User_Roles1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.User_Roles.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Name_Role.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name_Role.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            User_Roles q= new User_Roles();
            q.Name_role = Name_Role.Text;
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.User_Roles.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.User_Roles.ToList();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name_Role.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (DATAGRID.SelectedItem == null)
            {
                ERROR.Text = "Не выбрано поле";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name_Role.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as User_Roles;

                selected.Name_role = Name_Role.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.User_Roles.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.User_Roles.Remove(DATAGRID.SelectedItem as User_Roles);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.User_Roles.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as User_Roles;
                Name_Role.Text = selected.Name_role;
            }
        }

        private void Button_imp(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\json_roles.json");
            List<User_Roles_import> townnss = JsonConvert.DeserializeObject<List<User_Roles_import>>(json);
            foreach (var item in townnss)
            {
                User_Roles u = new User_Roles();
                u.Name_role = item.ser_Roles__.ToString();
                context.User_Roles.Add(u);
                context.SaveChanges();
                DATAGRID.ItemsSource = context.User_Roles.ToList();
            }
        }
        private bool ContainsEmojis(string input)
        {
            Regex rgx = new Regex(@"\p{Cs}");

            if (rgx.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
}


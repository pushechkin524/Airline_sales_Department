using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _5_UP0101.ADMINISTRATOR
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();
        public Users1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = null;
            DATAGRID.ItemsSource = context.Users.ToList();

            RoleID.ItemsSource = context.User_Roles.ToList();
            RoleID.DisplayMemberPath = "Name_role";
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == String.Empty || PasswordTB.Text == String.Empty || RoleID.SelectedItem == null)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Users q = new Users();
            q.User_RoleID = (RoleID.SelectedItem as User_Roles).User_RoleID;

            q.Password__ = PasswordTB.Text;
            q.Login__ = LoginTB.Text;
            context.Users.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Users.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == String.Empty || PasswordTB.Text == String.Empty || RoleID.SelectedItem == null)
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
            else if (ContainsEmojis(LoginTB.Text) || ContainsEmojis(PasswordTB.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Users;

                selected.User_RoleID = (RoleID.SelectedItem as User_Roles).User_RoleID;

                selected.Password__ = PasswordTB.Text;
                selected.Login__ = LoginTB.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Users.ToList();
            }
        }

        private async void Dalete_Click(object sender, RoutedEventArgs e)
        {

            if (DATAGRID.SelectedItem != null)
            {
                context.Users.Remove(DATAGRID.SelectedItem as Users);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Users.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Users;
                RoleID.SelectedItem = selected.User_Roles;

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

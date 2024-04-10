using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static MaterialDesignThemes.Wpf.Theme;


namespace _5_UP0101.ADMINISTRATOR
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();
        public Employees1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Employees.ToList();

            UserID_.ItemsSource = context.Users.ToList();
            UserID_.DisplayMemberPath = "Login__";
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Name__.Text == String.Empty || Surname_.Text == String.Empty || UserID_.SelectedItem == null || Patronymic_.Text == String.Empty || Passport_.Text == String.Empty || DP.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (!char.IsUpper(Name__.Text[0]) || !char.IsUpper(Surname_.Text[0]) || !char.IsUpper(Patronymic_.Text[0]))
            {
                ERROR.Text = "Не соблюден регистр";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name__.Text) || ContainsEmojis(Surname_.Text) || ContainsEmojis(Patronymic_.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else
            {
                ERROR.Text = string.Empty;
            }
            Employees q = new Employees();
            q.UserID = (UserID_.SelectedItem as Users).UserID;
            q.Surname           = Surname_.Text;
            q.Name_             = Name__.Text;
            q.Patronymic        = Patronymic_.Text;
            q.Passport_number   = Passport_.Text;
            q.DateOfBirth       = DP.Text;

            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Employees.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Employees.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Name__.Text == String.Empty || Surname_.Text == String.Empty || UserID_.SelectedItem == null || Patronymic_.Text == String.Empty || Passport_.Text == String.Empty || DP.Text == String.Empty)
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
            else if (ContainsEmojis(Name__.Text) || ContainsEmojis(Surname_.Text) || ContainsEmojis(Patronymic_.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Employees;

                selected.UserID = (UserID_.SelectedItem as Users).UserID;
                selected.Surname = Surname_.Text;
                selected.Name_ = Name__.Text;
                selected.Patronymic = Patronymic_.Text;
                selected.Passport_number = Passport_.Text;
                selected.DateOfBirth = DP.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Employees.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Employees.Remove(DATAGRID.SelectedItem as Employees);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Employees.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Employees;
                UserID_.SelectedItem = selected.Users;
                Surname_.Text = selected.Surname;
                Name__.Text = selected.Name_;
                Patronymic_.Text = selected.Patronymic;
                Passport_.Text = selected.Passport_number;
                DP.Text = selected.DateOfBirth;
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

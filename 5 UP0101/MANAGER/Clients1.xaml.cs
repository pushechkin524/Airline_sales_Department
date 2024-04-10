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

namespace _5_UP0101.COMPILER
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Clients1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Clients.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Passport__.Text == String.Empty || Surname__.Text == String.Empty || Name__.Text == String.Empty || Patronymic__.Text == String.Empty || DP.Text == String.Empty || Email.Text == String.Empty)

            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Passport__.Text) || ContainsEmojis(Surname__.Text) || ContainsEmojis(Name__.Text) || ContainsEmojis(Patronymic__.Text) || ContainsEmojis(DP.Text) || ContainsEmojis(Email.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }


            Clients q = new Clients();
            q.Passport_number = Passport__.Text;
            q.Surname = Surname__.Text;
            q.Name_ = Name__.Text;
            q.Patronymic = Patronymic__.Text;
            q.Date_of_birth = DP.Text;
            q.Email = Email.Text;
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Clients.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Clients.ToList();

        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Passport__.Text == String.Empty || Surname__.Text == String.Empty || Name__.Text == String.Empty || Patronymic__.Text == String.Empty || DP.Text == String.Empty || Email.Text == String.Empty)

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
            else if (ContainsEmojis(Passport__.Text) || ContainsEmojis(Surname__.Text) || ContainsEmojis(Name__.Text) || ContainsEmojis(Patronymic__.Text) || ContainsEmojis(DP.Text) || ContainsEmojis(Email.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Clients;

                selected.Passport_number = Passport__.Text;
                selected.Surname = Surname__.Text;
                selected.Name_ = Name__.Text;
                selected.Patronymic = Patronymic__.Text;
                selected.Date_of_birth = DP.Text;
                selected.Email = Email.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Clients.ToList();
            }

        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Clients.Remove(DATAGRID.SelectedItem as Clients);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Clients.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Clients;
                Passport__.Text = selected.Passport_number;
                Surname__.Text = selected.Surname;
                Name__.Text = selected.Name_;
                Patronymic__.Text = selected.Patronymic;
                DP.Text = selected.Date_of_birth;
                Email.Text = selected.Email;
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

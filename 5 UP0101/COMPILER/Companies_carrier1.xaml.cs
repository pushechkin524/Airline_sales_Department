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

namespace _5_UP0101.MANAGER
{
    /// <summary>
    /// Логика взаимодействия для Companies_carrier.xaml
    /// </summary>
    public partial class Companies_carrier1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Companies_carrier1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Companies_carrier.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Name_company.Text == String.Empty || Phone_company.Text == String.Empty || Email_company.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name_company.Text) || ContainsEmojis(Phone_company.Text) || ContainsEmojis(Email_company.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Companies_carrier q = new Companies_carrier();
            q.Name_company = Name_company.Text;
            q.Phone_company = Phone_company.Text;
            q.Email_company = Email_company.Text;
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Companies_carrier.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Companies_carrier.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Name_company.Text == String.Empty || Phone_company.Text == String.Empty || Email_company.Text == String.Empty)
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
            else if (ContainsEmojis(Name_company.Text) || ContainsEmojis(Phone_company.Text) || ContainsEmojis(Email_company.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Companies_carrier;

                selected.Name_company = Name_company.Text;
                selected.Phone_company = Phone_company.Text;
                selected.Email_company = Email_company.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Companies_carrier.ToList();
            }

        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Companies_carrier.Remove(DATAGRID.SelectedItem as Companies_carrier);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Companies_carrier.ToList();
            }

        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Companies_carrier;
                Name_company.Text = selected.Name_company;
                Phone_company.Text = selected.Phone_company;
                Email_company.Text = selected.Email_company;
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

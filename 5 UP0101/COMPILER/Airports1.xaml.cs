using _5_UP0101.ADMINISTRATOR;
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
    /// Логика взаимодействия для Airports1.xaml
    /// </summary>
    public partial class Airports1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Airports1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Airports.ToList();

            Town.ItemsSource = context.Towns.ToList();
            Town.DisplayMemberPath = "Town_name";
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Name__.Text == String.Empty || Town.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name__.Text) || ContainsEmojis(Town.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            Airports q = new Airports();
            q.Name_ = Name__.Text;
            q.TownID = (Town.SelectedItem as Towns).TownID;

            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Airports.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Airports.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Name__.Text == String.Empty || Town.Text == String.Empty)
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

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Airports;

                selected.TownID = (Town.SelectedItem as Towns).TownID;
                selected.Name_ = Name__.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Airports.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Airports.Remove(DATAGRID.SelectedItem as Airports);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Airports.ToList();
            }

        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Airports;
                Town.SelectedItem = selected.Towns;
                Name__.Text = selected.Name_;
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
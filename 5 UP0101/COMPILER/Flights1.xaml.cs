using _5_UP0101.ADMINISTRATOR;
using _5_UP0101.COMPILER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для Flights.xaml
    /// </summary>
    public partial class Flights1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Flights1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Flights.ToList();

            Companies_carrier.ItemsSource = context.Companies_carrier.ToList();
            Companies_carrier.DisplayMemberPath = "Name_company";

            Airports1.ItemsSource = context.Airports.ToList();
            Airports1.DisplayMemberPath = "Name_";

            Airports.ItemsSource = context.Airports.ToList();
            Airports.DisplayMemberPath = "Name_"; 

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Airplane_number.Text == String.Empty || DateOfVil.Text == String.Empty || DateOfPril.Text == String.Empty || Companies_carrier.SelectedItem == null || Airports1.SelectedItem == null || Airports.SelectedItem == null)

            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Airplane_number.Text) || ContainsEmojis(DateOfVil.Text) || ContainsEmojis(DateOfPril.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Flights BG = new Flights();
            BG.Airplane_number = Convert.ToInt32(Airplane_number.Text);
            BG.Departure_timе = DateOfVil.Text;
            BG.Arrival_timе = DateOfPril.Text;
            BG.CompanyID = (Companies_carrier.SelectedItem as Companies_carrier).Company_carrierID;
            BG.FromAirportID = (Airports1.SelectedItem as Airports).AirportID;
            BG.ToAirportID = (Airports.SelectedItem as Airports).AirportID;



            context.Flights.Add(BG);
            context.SaveChanges();

            DATAGRID.ItemsSource = context.Flights.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Airplane_number.Text == String.Empty || DateOfVil.Text == String.Empty || DateOfPril.Text == String.Empty || Companies_carrier.SelectedItem == null || Airports1.SelectedItem == null || Airports.SelectedItem == null)

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
            else if (ContainsEmojis(Airplane_number.Text) || ContainsEmojis(DateOfVil.Text) || ContainsEmojis(DateOfPril.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Flights;
                
                selected.Airplane_number = Convert.ToInt32(Airplane_number.Text);
                selected.Departure_timе = DateOfVil.Text;
                selected.Arrival_timе = DateOfPril.Text;
                selected.CompanyID = (Companies_carrier.SelectedItem as Companies_carrier).Company_carrierID;
                selected.FromAirportID = (Airports1.SelectedItem as Airports).AirportID;
                selected.ToAirportID = (Airports.SelectedItem as Airports).AirportID;
                context.SaveChanges();
                DATAGRID.ItemsSource = context.Flights.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {

                context.Flights.Remove(DATAGRID.SelectedItem as Flights);
                context.SaveChanges();
                DATAGRID.ItemsSource = context.Flights.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Flights;
                Airplane_number.Text = Convert.ToString(selected.Airplane_number);
                DateOfVil.Text = selected.Departure_timе;
                DateOfPril.Text = selected.Arrival_timе;
                Companies_carrier.SelectedItem = selected.Companies_carrier;
                Airports1.SelectedItem = selected.Airports;
                Airports.SelectedItem = selected.Airports;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Flights.ToList();
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

using _5_UP0101.ADMINISTRATOR;
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

namespace _5_UP0101.COMPILER
{
    /// <summary>
    /// Логика взаимодействия для Tickets.xaml
    /// </summary>
    public partial class Tickets1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Tickets1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Tickets.ToList();

            FlightID.ItemsSource = context.Flights.ToList();
            FlightID.DisplayMemberPath = "Airplane_number";

            CLASSSID.ItemsSource = context.CLASSS.ToList();
            CLASSSID.DisplayMemberPath = "Name_class";

            Baggage_typeID.ItemsSource = context.Baggage_type.ToList();
            Baggage_typeID.DisplayMemberPath = "Type_baggage";

            Waiting_hallID.ItemsSource = context.Waiting_hall.ToList();
            Waiting_hallID.DisplayMemberPath = "Name_waiting";

            ClientID.ItemsSource = context.Clients.ToList();
            ClientID.DisplayMemberPath = "Surname";
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (FlightID.SelectedItem == null || CLASSSID.SelectedItem == null || Baggage_typeID.SelectedItem == null
                || Waiting_hallID.SelectedItem == null || ClientID.SelectedItem == null || Price.Text == String.Empty
                || Animals.Text == String.Empty || Eat.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (!int.TryParse(Price.Text, out _))
            {
                ERROR.Text = "Неправильный тип данных";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Animals.Text) || ContainsEmojis(Eat.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Tickets q = new Tickets();
            q.FlightID = (FlightID.SelectedItem as Flights).FlightID;
            q.CLASSSID = (CLASSSID.SelectedItem as CLASSS).CLASSSID;
            q.Baggage_typeID = (Baggage_typeID.SelectedItem as Baggage_type).Baggage_typeID;
            q.Waiting_hallID = (Waiting_hallID.SelectedItem as Waiting_hall).Waiting_hallID;
            q.ClientID = (ClientID.SelectedItem as Clients).ClientsID;

            q.Price = Convert.ToDecimal(Price.Text);
            q.Animails = Animals.Text;
            q.Eat = Eat.Text;
            context.Tickets.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Tickets.ToList();
        }

        private async void Redact_Click_1(object sender, RoutedEventArgs e)
        {
            if (FlightID.SelectedItem == null || CLASSSID.SelectedItem == null || Baggage_typeID.SelectedItem == null
               || Waiting_hallID.SelectedItem == null || ClientID.SelectedItem == null || Price.Text == String.Empty
               || Animals.Text == String.Empty || Eat.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (!int.TryParse(Price.Text, out _))
            {
                ERROR.Text = "Неправильный тип данных";
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
            else if (ContainsEmojis(Animals.Text) || ContainsEmojis(Eat.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Tickets;

                selected.FlightID = (FlightID.SelectedItem as Flights).FlightID;
                selected.CLASSSID = (ClientID.SelectedItem as CLASSS).CLASSSID;
                selected.Baggage_typeID = (Baggage_typeID.SelectedItem as Baggage_type).Baggage_typeID;
                selected.Waiting_hallID = (Waiting_hallID.SelectedItem as Waiting_hall).Waiting_hallID;
                selected.ClientID = (ClientID.SelectedItem as Clients).ClientsID;
                selected.Price = Convert.ToDecimal(Price.Text);
                selected.Animails = Animals.Text;
                selected.Eat = Eat.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Tickets.ToList();
            }

        }

        private void Dalete_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DATAGRID.SelectedItem != null)
                {
                    context.Tickets.Remove(DATAGRID.SelectedItem as Tickets);

                    context.SaveChanges();
                    DATAGRID.ItemsSource = context.Tickets.ToList();
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void DATAGRID_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Tickets;
                FlightID.SelectedItem = selected.Flights;
                CLASSSID.SelectedItem = selected.CLASSS;
                Baggage_typeID.SelectedItem = selected.Baggage_type;
                Waiting_hallID.SelectedItem = selected.Waiting_hall;
                ClientID.SelectedItem = selected.Clients;
                Price.Text = selected.Price.ToString();
                Animals.Text = selected.Animails;
                Eat.Text = selected.Eat;
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



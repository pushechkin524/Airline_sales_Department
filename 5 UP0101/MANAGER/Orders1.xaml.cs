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

namespace _5_UP0101.COMPILER
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Orders1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Orders.ToList();

            Employee.ItemsSource = context.Employees.ToList();
            Employee.DisplayMemberPath = "Surname";

            Client.ItemsSource = context.Clients.ToList();
            Client.DisplayMemberPath = "Surname";

            Ticket.ItemsSource = context.Tickets.ToList();
            Ticket.DisplayMemberPath = "TicketID";
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Employee.SelectedItem == null || Client.SelectedItem == null || Ticket.SelectedItem == null)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Orders q = new Orders();
            q.EmployeeID = (Employee.SelectedItem as Employees).EmployeеID;
            q.ClientID = (Client.SelectedItem as Clients).ClientsID;
            q.TicketID = (Ticket.SelectedItem as Tickets).TicketID;
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Orders.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Orders.ToList();
        }

        private async void Redact_Click_1(object sender, RoutedEventArgs e)
        {
            if (Employee.SelectedItem == null || Client.SelectedItem == null || Ticket.SelectedItem == null)
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
                var selected = DATAGRID.SelectedItem as Orders;

                selected.EmployeeID = (Employee.SelectedItem as Employees).EmployeеID;
                selected.ClientID = (Client.SelectedItem as Clients).ClientsID;
                selected.TicketID = (Ticket.SelectedItem as Tickets).TicketID;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Orders.ToList();
            }
        }

        private void Dalete_Click_1(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Orders.Remove(DATAGRID.SelectedItem as Orders);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Orders.ToList();
            }
        }

        private void DATAGRID_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem == null)
            {
                return;
            }
            var selected = DATAGRID.SelectedItem as Orders;
            Client.SelectedItem= selected.Clients;
            Employee.SelectedItem = selected.Employees;
            Ticket.SelectedItem = selected.Tickets;
        }

        private void Dalete_Cli(object sender, RoutedEventArgs e)
        {

        }
    }
}

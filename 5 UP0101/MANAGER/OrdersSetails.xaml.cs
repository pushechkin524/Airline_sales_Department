using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для OrdersSetails.xaml
    /// </summary>
    public partial class OrdersSetails : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();
        public static ObservableCollection<Orders> OC = new ObservableCollection<Orders>();
        private int Count = 1;
        public OrdersSetails()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Orders.ToList();
            DATAGRID_Copy.ItemsSource = OC;
        }

        private void DATAGRID_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                OC.Add(DATAGRID.SelectedItem as Orders);
            }
        }

        private void Dalete_Click_1(object sender, RoutedEventArgs e)
        {
            if (DATAGRID_Copy.SelectedItem != null)
            {
                OC.Remove(DATAGRID_Copy.SelectedItem as Orders);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string check = $"Airline sales Department \n  Кассовый чек №{Count}\n";
            decimal sum = 0;
            for (int i = 0; i < OC.Count; i++)
            {
                check += $"{OC[i].Tickets.TicketID} - {OC[i].Tickets.Price}\n";
                sum += OC[i].Tickets.Price;
            }
            check += $"Итого к оплате: {sum}\n\n\n\n";
            File.AppendAllText("C:\\Users\\Ilyam\\OneDrive\\Рабочий стол\\Формат чека.txt", check);
            Process.Start("C:\\Users\\Ilyam\\OneDrive\\Рабочий стол\\Формат чека.txt");
            Count++;
        }
    }
}
using _5_UP0101.ADMINISTRATOR;
using _5_UP0101.MANAGER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _5_UP0101.COMPILER
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Manager()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Clients1();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Orders1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Tickets1();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Button_Click_zakaz(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new OrdersSetails();
        }

    }
}

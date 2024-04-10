using _5_UP0101.ADMINISTRATOR;
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

namespace _5_UP0101.MANAGER
{
    /// <summary>
    /// Логика взаимодействия для Compiler.xaml
    /// </summary>
    public partial class Compiler : Window
    {
        public Compiler()
        {
            InitializeComponent();
        }


        private void CLclass(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new CLASSS1();
        }

        private void typeCL(object sender, RoutedEventArgs e)
        {

            FrameAD.Content = new Baggage_type1();
        }

        private void zalCL(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Waiting_hallq();
        }

        private void perevozCL(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Companies_carrier1();
        }

        private void reisCL(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Flights1();
        }

        private void airportCL(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Airports1();
        }

        private void townCL(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Towns1();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}

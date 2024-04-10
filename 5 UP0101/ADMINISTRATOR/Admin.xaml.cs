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

namespace _5_UP0101
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Users1();       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new Employees1();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameAD.Content = new User_Roles1();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();   
            m.Show();
            this.Close();
        }
    }
}



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
    /// Логика взаимодействия для CLASSS.xaml
    /// </summary>
    public partial class CLASSS1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();
        public CLASSS1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.CLASSS.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Класс.Text == String.Empty || Fixed_allowance.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Класс.Text) || ContainsEmojis(Fixed_allowance.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            CLASSS q = new CLASSS();
            q.Name_class = Класс.Text;
            q.Fixed_allowance_class = Convert.ToInt32(Fixed_allowance.Text);
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.CLASSS.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.CLASSS.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Класс.Text == String.Empty || Fixed_allowance.Text == String.Empty)
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
            else if (ContainsEmojis(Класс.Text) || ContainsEmojis(Fixed_allowance.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as CLASSS;

                selected.Name_class = Класс.Text;
                selected.Fixed_allowance_class = Convert.ToInt32(Fixed_allowance.Text);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.CLASSS.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.CLASSS.Remove(DATAGRID.SelectedItem as CLASSS);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.CLASSS.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as CLASSS;
                Класс.Text = selected.Name_class;
                Fixed_allowance.Text = Convert.ToString(selected.Fixed_allowance_class);
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

using _5_UP0101.COMPILER;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Waiting_hall.xaml
    /// </summary>
    public partial class Waiting_hallq : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Waiting_hallq()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Waiting_hall.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Name_waiting.Text == String.Empty || Fixed_allowance_waiting.Text == String.Empty || Nubmer_waiting.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name_waiting.Text) && ContainsEmojis(Fixed_allowance_waiting.Text) && ContainsEmojis(Nubmer_waiting.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }


            Waiting_hall q = new Waiting_hall();
            q.Name_waiting = Name_waiting.Text;
            q.Fixed_allowance_waiting = Convert.ToInt32(Fixed_allowance_waiting.Text);
            q.Nubmer_waiting = Convert.ToInt32(Nubmer_waiting.Text);

            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Waiting_hall.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Waiting_hall.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Name_waiting.Text == String.Empty || Fixed_allowance_waiting.Text == String.Empty || Nubmer_waiting.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Name_waiting.Text) && ContainsEmojis(Fixed_allowance_waiting.Text) && ContainsEmojis(Nubmer_waiting.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Waiting_hall;

                selected.Name_waiting = Name_waiting.Text;
                selected.Fixed_allowance_waiting = Convert.ToInt32(Fixed_allowance_waiting.Text);
                selected.Nubmer_waiting = Convert.ToInt32(Nubmer_waiting.Text);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Waiting_hall.ToList();
            }
            else if (DATAGRID.SelectedItem == null)
            {
                ERROR.Text = "Не выбрано поле";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Waiting_hall.Remove(DATAGRID.SelectedItem as Waiting_hall);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Waiting_hall.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Waiting_hall;
                Name_waiting.Text = selected.Name_waiting;
                Fixed_allowance_waiting.Text = Convert.ToString(selected.Fixed_allowance_waiting);
                Nubmer_waiting.Text = Convert.ToString(selected.Nubmer_waiting);
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

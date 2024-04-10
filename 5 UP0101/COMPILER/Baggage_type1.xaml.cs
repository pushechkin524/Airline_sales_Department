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
    /// Логика взаимодействия для Baggage_type.xaml
    /// </summary>
    public partial class Baggage_type1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Baggage_type1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Baggage_type.ToList();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Type.Text == String.Empty || Allowance.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (!int.TryParse(Allowance.Text, out _))
            {
                ERROR.Text = "Неправильный тип данных";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(Type.Text) || ContainsEmojis(Allowance.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Baggage_type q = new Baggage_type();
            q.Type_baggage = Type.Text;
            q.Fixed_allowance_baggage = Convert.ToInt32(Allowance.Text);
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Baggage_type.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Baggage_type.ToList();
        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (Type.Text == String.Empty || Allowance.Text == String.Empty)
            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (!int.TryParse(Allowance.Text, out _))
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
            else if (ContainsEmojis(Type.Text) || ContainsEmojis(Allowance.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Baggage_type;

                selected.Type_baggage = Type.Text;
                selected.Fixed_allowance_baggage = Convert.ToInt32(Allowance.Text);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Baggage_type.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Baggage_type.Remove(DATAGRID.SelectedItem as Baggage_type);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Baggage_type.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Baggage_type;
                Type.Text = selected.Type_baggage;
                Allowance.Text = Convert.ToString(selected.Fixed_allowance_baggage);
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

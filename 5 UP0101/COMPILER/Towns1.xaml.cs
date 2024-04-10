using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Towns.xaml
    /// </summary>
    public partial class Towns1 : Page
    {
        Airline_sales_DepartmentEntities3 context = new Airline_sales_DepartmentEntities3();

        public Towns1()
        {
            InitializeComponent();
            DATAGRID.ItemsSource = context.Towns.ToList();

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (town.Text == String.Empty)

            {
                ERROR.Text = "Не все поля заполнены";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }
            else if (ContainsEmojis(town.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            Towns q = new Towns();
            q.Town_name = town.Text;
            //q.UserID = Convert.ToInt32(UserID_.Text);
            context.Towns.Add(q);
            context.SaveChanges();
            DATAGRID.ItemsSource = context.Towns.ToList();

        }

        private async void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (town.Text == String.Empty)

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
            else if (ContainsEmojis(town.Text))
            {
                ERROR.Text = "Смайлики нельзя";
                await Task.Delay(2000);
                ERROR.Text = string.Empty;
                return;
            }

            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Towns;

                selected.Town_name = town.Text;

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Towns.ToList();
            }
        }

        private void Dalete_Click(object sender, RoutedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                context.Towns.Remove(DATAGRID.SelectedItem as Towns);

                context.SaveChanges();
                DATAGRID.ItemsSource = context.Towns.ToList();
            }
        }

        private void DATAGRID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATAGRID.SelectedItem != null)
            {
                var selected = DATAGRID.SelectedItem as Towns;
                town.Text = selected.Town_name;
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\json_towns.json");
            List<Town_name_import> townnss = JsonConvert.DeserializeObject<List<Town_name_import>>(json);
            foreach (var item in townnss)
            {
                Towns u = new Towns();
                u.Town_name = item.Town_name__.ToString();
                context.Towns.Add(u);
                context.SaveChanges();
                DATAGRID.ItemsSource = context.Towns.ToList();
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

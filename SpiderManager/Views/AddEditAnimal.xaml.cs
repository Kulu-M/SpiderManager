using Newtonsoft.Json;
using ParentalMonitor.Classes;
using SpiderManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace SpiderManager.Views
{
    /// <summary>
    /// Interaction logic for AddEditAnimal.xaml
    /// </summary>
    public partial class AddEditAnimal : Window
    {
        public ObservableCollection<Species> speciesList;

        public bool justStarted = true;
        public AddEditAnimal()
        {
            InitializeComponent();
        }

        private void cb_species_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (justStarted == true)
            {
                justStarted = false;
                return;
            }            

            //TODO implement adding a new species
            if ((cb_species.SelectedIndex) == 0)
            {
                MessageBox.Show("Inser a new species");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            speciesList = new ObservableCollection<Species>(JsonConvert.DeserializeObject<List<Species>>(File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data/species.json"))));

            cb_species.ItemsSource = speciesList;
        }

        private void b_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_name.Text))
            {
                MessageBox.Show("Enter a name!");
            }
            if (dob_date == null)
            {
                MessageBox.Show("Enter a date of birth!");
            }
            if (cb_species.SelectedItem == null)
            {
                MessageBox.Show("Select a species!");
            }

            var spider = new Spider();
            spider.name = tb_name.Text;
            spider.species = cb_species.SelectedItem as Species;
            spider.dateOfBirth = (DateTime)dob_date.SelectedDate;
            App._spiderList.Add(spider);
            SafeLoad.SaveToJson();
        }
    }
}

using Newtonsoft.Json;
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

            

            if ((cb_species.SelectedIndex) == 0)
            {
                MessageBox.Show("hallo");
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
    }
}

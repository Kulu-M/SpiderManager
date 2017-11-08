using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpiderManager.Database_EF;
using SpiderManager.Views;

namespace SpiderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DEPRECATED!
        private ObservableCollection<Animals> animalsObservable;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //createExampleData();
        }

        private void createExampleData()
        {
            IQueryable<Animals> animalList;
            using (var context = new Entities())
            {
                animalsObservable = new ObservableCollection<Animals>(context.Animals);
            }
            dg_mainGrid.ItemsSource = animalsObservable;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SpiderSelect spiderSelectWindow = new SpiderSelect();
            spiderSelectWindow.Owner = this;
            spiderSelectWindow.Show();
        }
    }
}

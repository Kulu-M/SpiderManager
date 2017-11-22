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
using System.Windows.Shapes;
using SpiderManager.Model;

namespace SpiderManager.Views
{
    /// <summary>
    /// Interaction logic for SpiderSelect.xaml
    /// </summary>
    public partial class SpiderSelect : Window
    {
        public SpiderSelect()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Open the Main Window in the same size as it was when the User closed it the last time
            this.Height = Properties.Settings.Default.WindowHeight;
            this.Width = Properties.Settings.Default.WindowWidth;

            //createExampleData();

            lb_spiderListBox.ItemsSource = App._spiderList;
            if (App._spiderList != null && App._spiderList.Count > 0)
            {
                lb_spiderListBox.SelectedItem = App._spiderList.First();
            }         
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_spiderListBox.SelectedItem as Spider == null) return;
            sp_detailsStacker.DataContext = lb_spiderListBox.SelectedItem as Spider;
            gr_dataEventGrid.ItemsSource = (lb_spiderListBox.SelectedItem as Spider).eventList;
        }

        public void createExampleData()
        {
            var e1 = new Event
            {
                eventTime = DateTime.Today,
                eventType = "Futter",
                eventComment = "1 Schabe"
            };
            var e2 = new Event
            {
                eventTime = DateTime.Today,
                eventType = "Futter2",
                eventComment = "2 Schabe"
            };
            var e3 = new Event
            {
                eventTime = DateTime.Today,
                eventType = "Futter3",
                eventComment = "3 Schabe"
            };
            var e4 = new Event
            {
                eventTime = DateTime.Today,
                eventType = "Futter4",
                eventComment = "4 Schabe"
            };
            var eventList1 = new ObservableCollection<Event> {e1, e2};
            var eventList2 = new ObservableCollection<Event> { e3, e4 };


            var spider1 = new Spider
            {
                dateOfBirth = DateTime.Today,
                eventList = eventList1,
                name = "Arachno",
                species = new Species { name = "Brachypelma Smiti"}
            };
            var spider2 = new Spider
            {
                dateOfBirth = DateTime.Today,
                eventList = eventList2,
                name = "Brachno",
                species = new Species { name = "Chromatopelma cyaneopubescens" }
            };
            App._spiderList.Add(spider1);
            App._spiderList.Add(spider2);
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            AddEditAnimal ae = new AddEditAnimal();
            ae.Owner = this;
            ae.ShowDialog();
        }

        private void b_addEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpider = lb_spiderListBox.SelectedItem as Spider;
            if (selectedSpider == null)
            {
                MessageBox.Show("Select a spider");
                return;
            }
            
            AddEditData aed = new AddEditData();
            aed.Owner = this;
            aed.ShowDialog();

            if (App.eventContainer != null)
            {
                var spiderToChange = App._spiderList.FirstOrDefault(x => x == selectedSpider);
                if (spiderToChange.eventList == null) spiderToChange.eventList = new ObservableCollection<Event>();                
                spiderToChange.eventList.Add(App.eventContainer);
            }
            lb_spiderListBox.Items.Refresh();
        }

        private void b_deleteEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpider = lb_spiderListBox.SelectedItem as Spider;
            if (selectedSpider == null)
            {
                MessageBox.Show("Select a spider");
                return;
            }

            if (gr_dataEventGrid.SelectedItem as Event == null)
            {
                MessageBox.Show("Select an event");
                return;
            }

            var spiderToChange = App._spiderList.FirstOrDefault(x => x == selectedSpider);
            spiderToChange.eventList.Remove(gr_dataEventGrid.SelectedItem as Event);

            lb_spiderListBox.Items.Refresh();
            //TODO delte from event list
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.WindowHeight = this.ActualHeight;
            Properties.Settings.Default.WindowWidth = this.ActualWidth;
            Properties.Settings.Default.Save();
        }

        private void b_remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Are you sure?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (msgResult)
            {
                case MessageBoxResult.Yes:
                    var selectedSpider = lb_spiderListBox.SelectedItem as Spider;
                    if (selectedSpider != null)
                    {
                        App._spiderList.Remove(selectedSpider);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}

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
using System.Threading;
using SpiderManager.Classes;
using System.Windows.Threading;

namespace SpiderManager.Views
{
    /// <summary>
    /// Interaction logic for SpiderSelect.xaml
    /// </summary>
    public partial class Main : Window
    {
        #region Startup

        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Date = DateTime.Today;

            //Open the Main Window in the same size as it was when the User closed it the last time
            this.Height = Properties.Settings.Default.WindowHeight;
            this.Width = Properties.Settings.Default.WindowWidth;

            lb_spiderListBox.ItemsSource = App._spiderList;
            if (App._spiderList != null && App._spiderList.Count > 0)
            {
                lb_spiderListBox.SelectedItem = App._spiderList.First();
            }
            startDateCheckerTimer();
        }

        #endregion Startup

        #region DateCheckerTimer

        public static DispatcherTimer timer;

        public void startDateCheckerTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(Properties.Settings.Default.DateCheckThreadingTime);
            timer.Tick += dateTimer_Tick;
            timer.Start();
        }

        public void stopDateCheckerTimer()
        {
            timer.Stop();
        }

        void dateTimer_Tick(object sender, EventArgs e)
        {
            if (dateChanged())
            {
                Properties.Settings.Default.Date = DateTime.Today;
                lb_spiderListBox.Items.Refresh();
            }
            FeedingReminder.showFeedingReminder();
        }

        public bool dateChanged()
        {
            if (Properties.Settings.Default.Date != DateTime.Today)
            {
                return true;
            }
            return false;
        }

        #endregion DateCheckerTimer

        #region SpiderList

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_spiderListBox.SelectedItem as Spider == null) return;
            sp_detailsStacker.DataContext = lb_spiderListBox.SelectedItem as Spider;
            gr_dataEventGrid.ItemsSource = (lb_spiderListBox.SelectedItem as Spider).eventList;
        }

        private void b_add_spider_Click(object sender, RoutedEventArgs e)
        {
            AddAnimal ae = new AddAnimal();
            ae.Owner = this;
            ae.ShowDialog();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (lb_spiderListBox.SelectedItem as Spider == null)
            {
                MessageBox.Show("Select a Spider!");
                return;
            }

            App.spiderContainer = lb_spiderListBox.SelectedItem as Spider;
            EditAnimal ea = new EditAnimal();
            ea.Owner = this;
            ea.ShowDialog();

            App.spiderContainer = null;
        }

        private void b_remove_spider_Click(object sender, RoutedEventArgs e)
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

        #endregion SpiderList

        #region EventList

        private void b_addEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpider = lb_spiderListBox.SelectedItem as Spider;
            if (selectedSpider == null)
            {
                MessageBox.Show("Select a spider");
                return;
            }

            AddData aed = new AddData();
            aed.Owner = this;
            aed.ShowDialog();

            if (App.eventContainer != null)
            {
                var spiderToChange = App._spiderList.FirstOrDefault(x => x == selectedSpider);
                if (spiderToChange.eventList == null) spiderToChange.eventList = new ObservableCollection<Event>();
                spiderToChange.eventList.Add(App.eventContainer);
            }

            if (gr_dataEventGrid.ItemsSource == null)
            {
                gr_dataEventGrid.ItemsSource = (lb_spiderListBox.SelectedItem as Spider).eventList;
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

        #endregion EventList
        
        #region Closing

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.WindowHeight = this.ActualHeight;
            Properties.Settings.Default.WindowWidth = this.ActualWidth;
            Properties.Settings.Default.Save();
        }

        #endregion Closing
    }
}

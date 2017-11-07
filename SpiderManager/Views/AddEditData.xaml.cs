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
    /// Interaction logic for AddEditData.xaml
    /// </summary>
    public partial class AddEditData : Window
    {
        public ObservableCollection<string> eventTypes;

        public AddEditData()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            eventTypes = new ObservableCollection<string>(JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data/eventTypes.json"))));

            cb_eventType.ItemsSource = eventTypes;
            cb_eventType.SelectedIndex = 0;

            dtp_eventDateTime.Value = (DateTime.Now);
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            if (cb_eventType.SelectedItem == null)
            {
                MessageBox.Show("Select an event type!");
            }

            if (dtp_eventDateTime.Value == null)
            {
                MessageBox.Show("Select an event date/time!");
            }

            Event ev = new Event();
            ev.eventComment = tb_eventComment.Text;
            ev.eventType = cb_eventType.SelectedItem as string;
            ev.eventTime = (DateTime)dtp_eventDateTime.Value;

            App.eventContainer = ev;

            this.Close();
        }

        private void b_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}

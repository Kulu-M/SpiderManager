using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SpiderManager.Classes;

namespace SpiderManager.Model
{
    public class Spider
    {
        public string name { get; set; }
        public Species species { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ObservableCollection<Event> eventList { get; set; }
        public Brush color
        {
            get
            {
                if (CalculateFeedingTime.needToFeed(this) == true)
                {
                    color = Brushes.Red;
                    return Brushes.Red;
                }
                color = Brushes.Black;
                return Brushes.Black;
            }
            set { }
        }
    }
}

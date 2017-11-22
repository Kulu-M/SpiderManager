using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SpiderManager.Classes;
using System.ComponentModel;

namespace SpiderManager.Model
{
    public class Spider
    {
        public string name { get; set; }
        public Species species { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ObservableCollection<Event> eventList { get; set; }
        public DateTime lastFed
        {
            get
            {
                return CalculateLastEventTimes.calculateLastFeedingTime(this);
            }
            set { }
        }
        public DateTime lastMold
        {
            get
            {
                return CalculateLastEventTimes.calculateLastMoldingTime(this);
            }
            set { }
        }
        private Brush _color;
        public Brush color
        {
            get {
                if (CalculateLastEventTimes.needToFeed(this) == true)
                {
                    _color = Brushes.Red;
                    return _color;
                }
                _color = Brushes.Black;
                return _color;
            }
            set { }
        }
    }
}

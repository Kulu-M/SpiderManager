using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager.Model
{
    public class Spider
    {
        public string name { get; set; }
        public Species species { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ObservableCollection<Event> eventList { get; set; }
    }
}

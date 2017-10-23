using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager.Model
{
    public class Spider
    {
        public string name { get; set; }
        public string species { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<Event> eventList { get; set; }
    }
}

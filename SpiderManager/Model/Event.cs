using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager.Model
{
    public class Event
    {
        public DateTime eventTime { get; set; }
        public string eventType { get; set; }
        public string eventComment { get; set; }
    }
}

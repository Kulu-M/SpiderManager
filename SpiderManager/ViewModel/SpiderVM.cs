using SpiderManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager
{
    public class SpiderVM
    {
        public ObservableCollection<Spider> spiderList;
        public Event eventContainer = new Event();
        public Spider spiderContainer = new Spider();
    }
}

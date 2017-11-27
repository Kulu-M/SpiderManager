using SpiderManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpiderManager.Classes
{
    public class FeedingReminder
    {
        static List<Spider> feedingList = new List<Spider>();

        public static void addSpiderToFeed(Spider feedMe) {
            if (feedMe == null || feedingList.Any(x => x.name == feedMe.name)) return;
            feedingList.Add(feedMe);
        }
       
        public static void clearFeedingList()
        {
            feedingList.Clear();
        }

        public static void showFeedingReminder() {
            if (feedingList == null || feedingList.Count < 1) return;
            string s = "Please feed the following spiders:" + Environment.NewLine;
            foreach (var spider in feedingList)
            {
                s += spider.name + Environment.NewLine;
            }
            MessageBox.Show(s,"Please feed your spiders", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            clearFeedingList();
        }
    }
}

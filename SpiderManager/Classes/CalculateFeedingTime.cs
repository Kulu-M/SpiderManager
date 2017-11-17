using SpiderManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager.Classes
{
    public static class CalculateFeedingTime
    {
        public static bool needToFeed(Spider spider)
        {
            if (spider == null || spider.eventList == null || spider.eventList.Count < 1) return false;
            var lastFeedingDate = spider.eventList.Max(d => d.eventTime);

            if ((DateTime.Now - lastFeedingDate).TotalDays < Properties.Settings.Default.DaysToRemindToFeed) return false;
            return true;            
        }
    }
}

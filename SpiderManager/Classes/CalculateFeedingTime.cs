using SpiderManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderManager.Classes
{
    public static class CalculateLastEventTimes
    {
        public static DateTime calculateLastFeedingTime(Spider spider)
        {
            if (spider == null || spider.eventList == null || spider.eventList.Count < 1 || (from e in spider.eventList where e.eventType == "Feed" select e).Count() == 0) return DateTime.MinValue;
            return (from e in spider.eventList where e.eventType == "Feed" select e.eventTime).Max();
        }

        public static bool needToFeed(Spider spider)
        {
            var lastFeedingDate = calculateLastFeedingTime(spider);
            if (lastFeedingDate == DateTime.MinValue) return false;
            if ((DateTime.Now - lastFeedingDate).TotalDays < Properties.Settings.Default.DaysToRemindToFeed) return false;
            return true;            
        }

        public static DateTime calculateLastMoldingTime(Spider spider)
        {
            if (spider == null || spider.eventList == null || spider.eventList.Count < 1 || (from e in spider.eventList where e.eventType == "Mold" select e).Count() == 0) return DateTime.MinValue;
            return (from e in spider.eventList where e.eventType == "Mold" select e.eventTime).Max();
        }
    }
}

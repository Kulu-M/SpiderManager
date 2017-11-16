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
        public static DateTime? calculateFeedingTime(Spider spider)
        {
   
            if (spider == null || spider.eventList == null || spider.eventList.Count < 1) return null;
            var latestDate = spider.eventList.Max(d => d.eventTime);
            return null;
        }
    }
}

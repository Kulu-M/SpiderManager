﻿using SpiderManager.Model;
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
            if ((DateTime.Now - lastFeedingDate).TotalDays > spider.feedingInterval)
            {
                FeedingReminder.addSpiderToFeed(spider);
                return true;
            }
            
            return false;            
        }

        public static DateTime calculateLastMoltingTime(Spider spider)
        {
            if (spider == null || spider.eventList == null || spider.eventList.Count < 1 || (from e in spider.eventList where e.eventType == "Molt" select e).Count() == 0) return DateTime.MinValue;
            return (from e in spider.eventList where e.eventType == "Molt" select e.eventTime).Max();
        }
    }
}

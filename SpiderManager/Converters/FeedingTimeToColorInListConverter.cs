using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using SpiderManager.Classes;

namespace SpiderManager.Converters
{
    class FeedingTimeToColorInListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CalculateFeedingTime.calculateFeedingTime(null);
            return Brushes.Red;
            if (value == null) return Brushes.Black;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Brushes.Red;
        }
    }
}

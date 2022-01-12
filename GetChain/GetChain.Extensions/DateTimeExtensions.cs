using System;
using System.Collections.Generic;
using System.Linq;

namespace GetChain.GetChain.Extensions {
    
    public static class DateTimeExtensions {
        
        public static IEnumerable<DateTime> WithEmptyDates(this IEnumerable<DateTime> dates, DateTime start, DateTime end, TimeSpan span) {
            var list = Enumerable.Range(0, (int) (end - start).TotalDays + 1)
                .Select(x => start.Add(span));

            return list.Union(dates).OrderBy(x => x.Date);
        }
        
        public static IEnumerable<KeyValuePair<DateTime, int>> FrequencyGroupByDay(this IEnumerable<DateTime> dates) {
            return dates.GroupBy(x => x.Date)
                .Select(x => new KeyValuePair<DateTime, int>(x.Key, x.Count()));
        }

        public static IEnumerable<DateTime> Between(this IEnumerable<DateTime> dates, DateTime start, DateTime end) {
            return dates.Where(x => x >= start && x <= end);
        }
    }
}
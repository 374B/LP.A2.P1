using System;
using System.Linq;
using System.Collections.Generic;

namespace LP.University.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static TimeSpan Sum<T>(this IEnumerable<T> self, Func<T, TimeSpan> selector)
        {
            var ticks = self.Sum(x => selector(x).Ticks);
            return TimeSpan.FromTicks(ticks);
        }
    }
}

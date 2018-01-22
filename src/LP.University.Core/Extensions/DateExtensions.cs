using System;

namespace LP.University.Core.Extensions
{
    public static class DateExtensions
    {
        public static bool InPast(this DateTime self)
        {
            return self < DateTime.Now;
        }

        public static bool InFuture(this DateTime self)
        {
            return self > DateTime.Now;
        }

    }
}

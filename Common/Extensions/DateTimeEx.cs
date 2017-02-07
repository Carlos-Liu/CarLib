using System;
using System.Diagnostics.Contracts;

namespace CarLib.Common.Extensions
{
    /// <summary>
    /// Extension methods for class <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeEx
    {
        /// <summary>
        /// Convert local time to UTC time
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime LocalToUtc(this DateTime source)
        {
            Contract.Assert(source.Kind == DateTimeKind.Local, "The DateTimeKind should be set as Local.");

            // Do not convert the constant values.
            if (source == DateTime.MaxValue || source == DateTime.MinValue)
            {
                return source;
            }

            return TimeZoneInfo.ConvertTimeToUtc(source);
        }

        /// <summary>
        /// Get the last instant of the specified day, e.g. if specified day is 2016/09/19
        /// then it will return 2016/09/19 23:59:59.
        /// </summary>
        /// <param name="day">The time will get the last instant.</param>
        /// <returns>The last instant of the specified date time.</returns>
        public static DateTime GetLastInstant(this DateTime day)
        {
            return day.Date
                      .AddHours(23)
                      .AddMinutes(59)
                      .AddSeconds(59);
        }
    }
}

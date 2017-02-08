using System;
using System.Collections.Generic;
using CarLib.Common.Properties;

namespace CarLib.Common.Extensions
{
    /// <summary>
    /// Extension class for the <seealso cref="TimeSpan"/> type.
    /// </summary>
    public static class TimeSpanEx
    {
        private const string PartSeparator = " ";

        /// <summary>
        /// Get the friendly formated display string for specified time span, e.g. 1 minute 10 seconds.
        /// </summary>
        /// <param name="timespan">The TimeSpan object to get friendly string.</param>
        /// <returns>The user friendly display string.</returns>
        public static string ToReadableString(this TimeSpan timespan)
        {

            var totalSeconds = timespan.TotalSeconds;

            if (totalSeconds < 0)
                throw new ArgumentException("The total seconds cannot be negative value.");

            var dayValue = timespan.Days;
            var hourValue = timespan.Hours;
            var minuteValue = timespan.Minutes;
            var secondValue = timespan.Seconds;

            List<string> parts = new List<string>();
            if (dayValue > 0)
            {
                parts.Add(string.Format("{0}{1}", dayValue, Resources.TimeSpan_DisplayUnit_Day));
            }

            if (hourValue > 0)
            {
                parts.Add(string.Format("{0}{1}", hourValue, Resources.TimeSpan_DisplayUnit_Hour));
            }

            if (minuteValue > 0)
            {
                parts.Add(string.Format("{0}{1}", minuteValue, Resources.TimeSpan_DisplayUnit_Minute));
            }

            // Current rule is: the duration less than 1 minute will be dropped on if there is day or hour value
            bool needDisplaySeconds = dayValue == 0 && hourValue == 0;
            if (needDisplaySeconds)
            {
                // do not display '0 second' if there is minute value
                if (secondValue > 0 || minuteValue == 0)
                {
                    parts.Add(string.Format("{0}{1}", secondValue, Resources.TimeSpan_DisplayUnit_Second));
                }
            }

            var displayString = string.Join(PartSeparator, parts);

            return displayString;
        }

        /// <summary>
        /// Get the friendly formated display string for time estimation, e.g. About 1 minute 10 seconds.
        /// </summary>
        /// <param name="timespan">The TimeSpan object to get friendly string.</param>
        /// <returns>The friendly formated display string for time estimation.</returns>
        public static string ToTimeEstimationString(this TimeSpan? timespan)
        {
            if (!timespan.HasValue)
            {
                return Resources.TimeSpan_PromptStringForMaxTimeSpan;
            }

            var estimationString = ToReadableString(timespan.Value);
            return Resources.TimeSpan_TimeEstimation_AboutPrefix + estimationString;
        }
    }
}

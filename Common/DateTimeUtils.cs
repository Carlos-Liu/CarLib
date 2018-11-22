using System;
using System.Globalization;
using System.Xml;

namespace CarLib.Common
{
  public static class DateTimeUtils
  {
    /// <summary>
    /// Parses the UTC from RFC3339.
    /// </summary>
    /// <param name="dateTimeString">The date time string.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">
    /// Occurs when the date time string is invalid.
    /// </exception>
    /// <exception cref="FormatException">
    /// Occurs when the date time string is not in a valid format.
    /// </exception>
    public static DateTime ParseUtcFromRfc3339(string dateTimeString)
    {
      if (string.IsNullOrWhiteSpace(dateTimeString))
      {
        throw new ArgumentException("Invalid date time string.", nameof(dateTimeString));
      }

      return XmlConvert.ToDateTime(dateTimeString, XmlDateTimeSerializationMode.Utc);
    }

    /// <summary>
    /// Formatting a DateTime as a string in RFC3339-format
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    // refer to https://sebnilsson.com/blog/c-datetime-to-rfc3339-iso-8601/
    public static string ToRfc3339String(this DateTime dateTime)
    {
      return dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
    }
  }
}

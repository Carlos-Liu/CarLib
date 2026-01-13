using System;

namespace CarLib.Common.Extensions
{
    /// <summary>
    /// Extension class for the <see cref="string"/> type.
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// Compare the two strings with ordinal sort rules.
        /// </summary>
        /// <param name="left">The left side string to be compared.</param>
        /// <param name="right">The right side string to be compared.</param>
        /// <param name="ignoreCase">If ignore case when doing the compare.</param>
        /// <returns>
        /// True: If the two strings are equal with specified compare option.
        /// False: The two strings are not equal with specified compare option.
        /// </returns>
        public static bool EqualOrdinal(this string left, string right, bool ignoreCase = true)
        {
            if (left == null)
            {
                return right == null;
            }

            if (ignoreCase)
            {
                return left.Equals(right, StringComparison.OrdinalIgnoreCase);
            }

            return left.Equals(right, StringComparison.Ordinal);
        }

        /// <summary>
        /// Compare two strings using InvariantCulture and ignoring case.
        /// </summary>
        /// <param name="str">The string to compare.</param>
        /// <param name="other">The other string to compare.</param>
        /// <returns>Return True if the two strings are equal, else return False.</returns>
        public static bool CompareInvariantIgnoreCase(this string str, string other)
        {
            // Why use ToUpperInvariant instead of string.Equals with StringComparison.InvariantCultureIgnoreCase?
            //  -The method will be used by EF core to SQL translation, so string.Equals with StringComparison.InvariantCultureIgnoreCase does not work.
            // Why use ToUpperInvariant instead of ToUpper?
            //  -ToUpper comparision does not work for Turkish culture.
            //  -Reference: https://stackoverflow.com/questions/3550213/in-c-sharp-what-is-the-difference-between-toupper-and-toupperinvariant
            return (str == null && other == null) ||
                   (str != null && other != null &&
                   str.ToUpperInvariant() == other.ToUpperInvariant());
        }
    }
}

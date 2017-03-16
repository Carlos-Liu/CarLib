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
    }
}

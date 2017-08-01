using System;

namespace CarLib.Common
{
    /// <summary>
    /// Converts byte array to string and vice versa.
    /// </summary>
    public static class BytesStringConverter
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-64 digits.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] data)
        {
            if (data == null)
            {
                return string.Empty;
            }

            var converted = Convert.ToBase64String(data);
            return converted;
        }

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64 digits,
        /// to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="bytesDataString"></param>
        /// <returns></returns>
        public static byte[] FromBase64String(string bytesDataString)
        {
            if (string.IsNullOrEmpty(bytesDataString))
            {
                return null;
            }

            var byteArray = Convert.FromBase64String(bytesDataString);
            return byteArray;
        }
    }
}

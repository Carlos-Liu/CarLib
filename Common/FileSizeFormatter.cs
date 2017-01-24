using System;
using System.IO;
using System.Security;
using CarLib.Common.Properties;

namespace CarLib.Common
{
    /// <summary>
    /// Helper class to format the file size.
    /// </summary>
    public static class FileSizeFormatter
    {
        /// <summary>
        /// Provides the human readable format for the specified file size.
        /// </summary>
        /// <param name="fileSizeInBytes">The file size (in bytes).</param>
        /// <returns>The human readable format for the specified file size.</returns>
        public static string GetReadableFileSize(long fileSizeInBytes)
        {
            // take below link as references
            // http://stackoverflow.com/questions/281640/how-do-i-get-a-human-readable-file-size-in-bytes-abbreviation-using-net

            string[] units =
            {
                Resources.FileSize_Unit_Byte,
                Resources.FileSize_Unit_KB,
                Resources.FileSize_Unit_MB,
                Resources.FileSize_Unit_GB,
                Resources.FileSize_Unit_TB
            };

            int order = 0;
            double fileSizeInDouble = fileSizeInBytes;
            while (fileSizeInDouble >= 1024 && order < units.Length - 1)
            {
                order++;
                fileSizeInDouble = fileSizeInDouble / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string formattedResult = String.Format("{0:0.##} {1}", fileSizeInDouble, units[order]);
            return formattedResult;
        }

        /// <summary>
        /// Provides the human readable format file size for specified file.
        /// <remarks>The <paramref name="fullFilePath"/> must indicate a valid and existing file.</remarks>
        /// </summary>
        /// <param name="fullFilePath">The full file name.</param>
        /// <returns>The human readable format for the specified file size.</returns>
        /// <exception cref="SecurityException">Occurs when the caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">Occurs when accessing to fileName is denied.</exception>
        /// <exception cref="IOException">Occurs when the state of the file or directory cannot be updated.</exception>
        public static string GetReadableFileSize(string fullFilePath)
        {
            var fileInfo = new FileInfo(fullFilePath);

            var formattedString = GetReadableFileSize(fileInfo.Length);
            return formattedString;
        }
    }
}

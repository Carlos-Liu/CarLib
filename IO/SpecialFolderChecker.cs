using System;
using System.IO;

namespace CarLib.IO
{
    /// <summary>
    /// Helper class to check the system special folder.
    /// </summary>
    public static class SpecialFolderChecker
    {
        /// <summary>
        /// Check if the specified directory in a special folder.
        /// </summary>
        /// <param name="directory">The special directory to be checked.</param>
        /// <param name="specialFolder">The system special folders.</param>
        /// <returns>Return true if the directory is the subdirectory of the special folder, else return false.</returns>
        private static bool InSpecialDirectory(string directory, Environment.SpecialFolder specialFolder)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return false;
            }

            try
            {
                directory = directory.Trim();
                var specialFolderPath = Environment.GetFolderPath(specialFolder);

                // Uniform all the directory separators to make sure 'c:/windows/' is treated the same as 'c:\windows\
                // Note: DirectorySeparatorChar is '\' and AltDirectorySeparatorChar is '/'
                directory = directory.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                specialFolderPath = specialFolderPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

                // Add trailing backslash if needed
                var directoryWithBackslash = PathUtilities.AddTrailingBackslash(directory);
                var specialFolderPathWithBackslash = PathUtilities.AddTrailingBackslash(specialFolderPath);

                return directoryWithBackslash.StartsWith(specialFolderPathWithBackslash, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the specified directory in Windows directory or SYSROOT.
        /// </summary>
        /// <param name="directory">The special directory to be checked.</param>
        /// <returns>Return true if the specified directory in Windows directory or SYSROOT.</returns>
        public static bool InWindowsDirectory(string directory)
        {
            return InSpecialDirectory(directory, Environment.SpecialFolder.Windows);
        }

        public static bool InUserProfile(string directory)
        {
            return InSpecialDirectory(directory, Environment.SpecialFolder.UserProfile);
        }
    }
}

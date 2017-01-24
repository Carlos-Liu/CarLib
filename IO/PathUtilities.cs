using System.IO;

namespace CarLib.IO
{
    /// <summary>
    /// Utilities class for the path.
    /// </summary>
    public static class PathUtilities
    {
        /// <summary>
        /// Add the trailing slash at the end of specified path.
        /// </summary>
        /// <param name="path">The path to be add the trailing slash.</param>
        /// <returns>Add </returns>
        public static string AddTrailingBackslash(string path)
        {
            // They're always one character but EndsWith is shorter than array style access to last 
            // path character. Change this if performance are a (measured) issue.
            // DirectorySeparatorChar is '\' and AltDirectorySeparatorChar is '/'
            string separator1 = Path.DirectorySeparatorChar.ToString();
            string separator2 = Path.AltDirectorySeparatorChar.ToString();

            path = path.Trim();

            if (path.EndsWith(separator1) || path.EndsWith(separator2))
                return path;

            // If there is the "alt" separator then I add a trailing one. 
            // Note that URI format (file://drive:\path\filename.ext) is not supported in most .NET I/O 
            // functions then we don't support it here too. 
            if (path.Contains(separator2))
                return path + separator2;

            return path + separator1;
        }
    }
}

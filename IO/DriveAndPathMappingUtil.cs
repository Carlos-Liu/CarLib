using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CarLib.IO
{
  /// <summary>
  /// Utility class helps to do the drive and path mapping related works.
  /// E.g. Get the physical path of drive mapped to local folder
  /// </summary>
  public static class DriveAndPathMappingUtil
  {
    // refer to https://msdn.microsoft.com/en-us/library/windows/desktop/aa365461%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);

    /// <summary>
    /// Get the physical path of drive mapped to local folder (e.g. by using 'subst' command).
    /// 
    /// For example, "C:\Test" folder is mapper to drive "X:" by using subst command, then this 
    /// function is helping to convert the path "X:\FolderA\123.log" to "C:\Test\FolderA\123.log".
    /// </summary>
    /// <param name="path">A path to be converted, it may or may not start with mapped drive.</param>
    /// <returns>The physical full path for the specified <paramref name="path"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// Occurs when the input path is null or empty.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Occurs when <paramref name="path"/> contains one or more of the invalid characters defined 
    /// in System.IO.Path.GetInvalidPathChars.
    /// </exception>
    public static string GetPhysicalPath(string path)
    {
      if (string.IsNullOrWhiteSpace(path))
      {
        throw new ArgumentNullException("path");
      }

      // Get the drive letter
      var pathRoot = Path.GetPathRoot(path);
      if (string.IsNullOrEmpty(pathRoot))
      {
        throw new ArgumentException("The path does not contain root directory information.", "path");
      }

      var deviceNameToBeQueried = pathRoot.Replace("\\", "");
      const int maxCharNumberForTargetPath = 260;
      var targetPath = new StringBuilder(maxCharNumberForTargetPath);
      var queryResult = QueryDosDevice(deviceNameToBeQueried, targetPath, targetPath.Capacity);
      if (queryResult == 0)
      {
        throw new Exception("QueryDosDevice failed.");
      }

      string result;

      // If drive is substed, the result will be in the format of "\??\C:\RealPath\".
      const string substPrefix = @"\??\";
      if (targetPath.ToString().StartsWith(substPrefix))
      {
        // Strip the \??\ prefix.
        var root = targetPath.ToString().Remove(0, substPrefix.Length);
        result = Path.Combine(root, path.Replace(Path.GetPathRoot(path), ""));
      }
      else
      {
        // if not SUBSTed, just assume it's not mapped.
        result = path;
      }

      return result;
    }
  }
}

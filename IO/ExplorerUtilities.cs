using System;
using System.Runtime.InteropServices;

namespace CarLib.IO
{
  /// <summary>
  /// Utilities methods about windows explorer related.
  /// </summary>
  public static class ExplorerUtilities
  {

    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr ILCreateFromPathW(string pszPath);

    [DllImport("shell32.dll")]
    private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, int cild, IntPtr apidl, int dwFlags);

    [DllImport("shell32.dll")]
    private static extern void ILFree(IntPtr pidl);

    /// <summary>
    /// Open the specified file/path in windows explorer and set focus on the file/path
    /// </summary>
    /// <param name="filePath"></param>
    public static void OpenFolderAndSelectFile(string filePath)
    {
      if (string.IsNullOrWhiteSpace(filePath))
      {
        throw new ArgumentNullException("filePath");
      }

      IntPtr pidl = ILCreateFromPathW(filePath);
      SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);
      ILFree(pidl);
    }
  }
}

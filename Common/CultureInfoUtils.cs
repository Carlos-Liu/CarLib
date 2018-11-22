using System;
using System.Globalization;
using System.Linq;

namespace CarLib.Common
{
  public static class CultureInfoUtils
  {
    /// <summary>
    /// Determines whether the specified language and region is valid.
    /// </summary>
    /// <param name="languageAndRegion">The language and region.</param>
    /// <returns>
    ///   <c>true</c> if the specified language and region is valid; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsLanguageAndRegionValid(string languageAndRegion)
    {
      // for full list please refer to https://msdn.microsoft.com/en-us/library/cc233982.aspx
      return CultureInfo.GetCultures(CultureTypes.AllCultures)
        .Any(culture => string.Equals(culture.Name, languageAndRegion, StringComparison.CurrentCultureIgnoreCase));
    }
  }
}

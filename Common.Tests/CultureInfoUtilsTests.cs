using CarLib.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
  [TestClass]
  public class CultureInfoUtilsTests
  {
    [TestMethod]
    public void IsLanguageAndRegionValid_OneValidWord_ReturnTrue()
    {
      // ar means Arabic
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("ar");
      Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void IsLanguageAndRegionValid_ThreeValidWords_ReturnTrue()
    {
      // Azerbaijani (Cyrillic)
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("az-Cyrl-AZ");
      Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void IsLanguageAndRegionValid_LowerCaseButValid_ReturnTrue()
    {
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("en-us");
      Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void IsLanguageAndRegionValid_UpperCaseButValid_ReturnTrue()
    {
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("EN-US");
      Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void IsLanguageAndRegionValid_ChineseMailandCulture_ReturnTrue()
    {
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("zh-CN");
      Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void IsLanguageAndRegionValid_Invalid_ReturnFalse()
    {
      var isValid = CultureInfoUtils.IsLanguageAndRegionValid("en-CN");
      Assert.IsFalse(isValid);
    }
  }
}

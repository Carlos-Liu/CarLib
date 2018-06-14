using CarLib.Common.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Database
{
  [TestClass]
  public class DbUtilsTests
  {
    [TestMethod]
    public void EscapeForLikeSql_InputIsNull_ReturnEmptyStringButNotNull()
    {
      var actual = DbUtils.EscapeForLikeSql(null);
      Assert.AreEqual("", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIsEmpty_ReturnEmptyStringButNotNull()
    {
      var actual = DbUtils.EscapeForLikeSql(string.Empty);
      Assert.AreEqual("", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIsWhitespaceOnly_InputUnchanged()
    {
      var actual = DbUtils.EscapeForLikeSql("  ");
      Assert.AreEqual("  ", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputDoesNotIncludePatternMatchingChar_InputUnchanged()
    {
      var actual = DbUtils.EscapeForLikeSql("ab  cd");
      Assert.AreEqual("ab  cd", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIncludesLeftBracket_EscapedCorrectly()
    {
      var actual = DbUtils.EscapeForLikeSql("Ab[c");
      Assert.AreEqual("Ab[[]c", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIncludesPercentSign_EscapedCorrectly()
    {
      var actual = DbUtils.EscapeForLikeSql("%Abc%");
      Assert.AreEqual("[%]Abc[%]", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIncludesUnderscore_EscapedCorrectly()
    {
      var actual = DbUtils.EscapeForLikeSql("_A_bc");
      Assert.AreEqual("[_]A[_]bc", actual);
    }

    [TestMethod]
    public void EscapeForLikeSql_InputIncludesAllChars_EscapedCorrectly()
    {
      var actual = DbUtils.EscapeForLikeSql("_A_b%%c[ [d]");
      Assert.AreEqual("[_]A[_]b[%][%]c[[] [[]d]", actual);
    }
  }
}

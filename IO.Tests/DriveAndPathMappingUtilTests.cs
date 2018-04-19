using System;
using CarLib.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IO.Tests
{
  [TestClass]
  public class DriveAndPathMappingUtilTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetPhysicalPath_InputPathIsNull_ThrowException()
    {
      DriveAndPathMappingUtil.GetPhysicalPath(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetPhysicalPath_InputPathIsWhiteSpaceOnly_ThrowException()
    {
      DriveAndPathMappingUtil.GetPhysicalPath("  ");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPhysicalPath_InputPathStartWithInvalidChar_ThrowException()
    {
      DriveAndPathMappingUtil.GetPhysicalPath("<:\\abc");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPhysicalPath_InputPathNotContainRootDir_ThrowException()
    {
      DriveAndPathMappingUtil.GetPhysicalPath("abc\\123.log");
    }
  }
}

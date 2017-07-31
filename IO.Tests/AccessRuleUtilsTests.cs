using System;
using System.IO;
using System.Security.AccessControl;
using CarLib.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IO.Tests
{
  [TestClass]
  public class AccessRuleUtilsTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SetFullControlForEveryone_PathIsNull_ThrowException()
    {
      AccessRuleUtils.SetFullControlForEveryone(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SetFullControlForEveryone_PathOnlyIncludesWhitespace_ThrowException()
    {
      AccessRuleUtils.SetFullControlForEveryone(" ");
    }

    [TestMethod]
    [ExpectedException(typeof(DirectoryNotFoundException))]
    public void SetFullControlForEveryone_PathNotExist_ThrowException()
    {
      AccessRuleUtils.SetFullControlForEveryone(@"A:\Path not exist\Path not exist\Path not exist");
    }

    [TestMethod]
    public void SetFullControlForEveryone_CreateTempDirectoryThenSetAccessControl_Assigned()
    {
      // Arrange
      var commonDocDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
      string testDirectory = Path.Combine(commonDocDir, "TestDirectory-A3688960-23CA-47D9-9858-40C7BF8CAC50");

      Directory.CreateDirectory(testDirectory);

      // Act
      AccessRuleUtils.SetFullControlForEveryone(testDirectory);

      // Assert
      var directorySecurity = Directory.GetAccessControl(testDirectory, AccessControlSections.Access);
      var rules = directorySecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

      foreach (FileSystemAccessRule rule in rules)
      {
        Assert.AreEqual("Everyone", rule.IdentityReference.Value);
        Assert.AreEqual(FileSystemRights.Modify | FileSystemRights.Synchronize, rule.FileSystemRights);
        Assert.AreEqual(PropagationFlags.None, rule.PropagationFlags);
        Assert.AreEqual(InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, rule.InheritanceFlags);
        Assert.AreEqual(AccessControlType.Allow, rule.AccessControlType);

        break;
      }

      Directory.Delete(testDirectory);
    }
  }
}

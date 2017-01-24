using System;
using System.IO;
using CarLib.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IO.Tests
{
    [TestClass]
    public class SpecialFolderCheckerTests
    {
        private static string _specialFolderPathWithTrailingBackslash;
        private static string _specialFolderPathWithoutTrailingBackslash;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Get the real windows directory on the machine run these tests
            // the result of Environment.GetFolderPath does not include the trailing backslash
            var specialFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            _specialFolderPathWithoutTrailingBackslash = specialFolderPath;
            _specialFolderPathWithTrailingBackslash = _specialFolderPathWithoutTrailingBackslash + Path.DirectorySeparatorChar;
        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryIsEmpty_ReturnFalse()
        {
            // Arrange
            string directory = string.Empty;

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsFalse(actual);

        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryIsWindowsWithoutTrailingSeparator_ReturnTrue()
        {
            // Arrange
            // e.g. c:\windows
            string directory = _specialFolderPathWithoutTrailingBackslash;

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryIsWindowsWithTrailingSeparator_ReturnTrue()
        {
            // Arrange
            // e.g. c:\windows\
            string directory = _specialFolderPathWithTrailingBackslash;

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryIsWindowsWithAltTrailingSeparator_ReturnTrue()
        {
            // Arrange
            // replace the '\' with '/', e.g. C:/windows/
            string directory = _specialFolderPathWithTrailingBackslash.Replace(
                Path.DirectorySeparatorChar,
                Path.AltDirectorySeparatorChar);

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void InWindowsDirectory_DirectoryIsSubDirectoryUnderWindowsFolderInLowerCase_ReturnTrue()
        {
            // Arrange
            // e.g. c:\windows\subFolder
            string directory = _specialFolderPathWithTrailingBackslash + @"subFolder";

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void InWindowsDirectory_DirectoryIsSubDirectoryUnderWindowsFolderInUpperCase_ReturnTrue()
        {
            // Arrange
            // e.g. C:\WINDOWS\SUBFOLDER\SUB-SUBFOLDER
            string directory = _specialFolderPathWithTrailingBackslash + @"SUBFOLDER\SUB-SUBFOLDER\";

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryStartsWithWindowsButNotSystemWindow_ReturnFalse()
        {
            // Arrange
            // e.g. C:\windows1\
            string directory = _specialFolderPathWithoutTrailingBackslash + "1";

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void InWindowsDirectory_DirectoryIsWindowsWithWhitespaces_ReturnTrue()
        {
            // Arrange
            // e.g. '   C:\windows   ', with whitespaces
            string directory = "  " + _specialFolderPathWithoutTrailingBackslash + "   ";

            // Act
            var actual = SpecialFolderChecker.InWindowsDirectory(directory);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}

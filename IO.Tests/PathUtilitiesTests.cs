using CarLib.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IO.Tests
{
    [TestClass]
    public class PathUtilitiesTests
    {
        [TestMethod]
        public void AddTrailingBackslash_EndWithDirectorySeparatorChar_PathIsNotChanged()
        {
            // Arrange
            const string testDirectory = @"C:\folder\";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(testDirectory, actual);
        }

        [TestMethod]
        public void AddTrailingBackslash_EndWithAltDirectorySeparatorChar_PathIsNotChanged()
        {
            // Arrange
            const string testDirectory = @"C:/folder/";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(testDirectory, actual);
        }

        [TestMethod]
        public void AddTrailingBackslash_HasLeadingAndTrailingSpaces_BackslashIsAddedCorrectly()
        {
            // Arrange
            const string testDirectory = @"  C:/folder  ";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(@"C:/folder/", actual);
        }

        [TestMethod]
        public void AddTrailingBackslash_NotEndWithDirectorySeparatorChar_TrailingBackslashIsAdded()
        {
            // Arrange
            const string testDirectory = @"C:\folder";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(@"C:\folder\", actual);
        }

        [TestMethod]
        public void AddTrailingBackslash_OnlyHasDriveLetterWithoutDirectorySeparator_TrailingBackslashIsAdded()
        {
            // Arrange
            const string testDirectory = @"C:";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(@"C:\", actual);
        }

        [TestMethod]
        public void AddTrailingBackslash_PathContainAltDirectorySeparatorChar_AltTrailingBackslashIsAdded()
        {
            // Arrange
            const string testDirectory = @"file//C:\folder";

            // Act
            var actual = PathUtilities.AddTrailingBackslash(testDirectory);

            // Assert
            Assert.AreEqual(@"file//C:\folder/", actual);
        }
    }
}

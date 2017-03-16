using System.Globalization;
using System.Threading;
using CarLib.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Extensions
{
    [TestClass]
    public class StringExTests
    {
        [TestMethod]
        public void EqualOrdinal_BothAreNull_ReturnTrue()
        {
            // Arrange
            string left = null;
            string right = null;

            // Act
            bool isEqual = left.EqualOrdinal(right);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_LeftIsNull_ReturnFalse()
        {
            // Arrange
            string left = null;
            string right = string.Empty;

            // Act
            bool isEqual = left.EqualOrdinal(right);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_LeftIsEmpty_ReturnFalse()
        {
            // Arrange
            string left = string.Empty;
            string right = null;

            // Act
            bool isEqual = left.EqualOrdinal(right);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_LeftAndRightAreTheSame_ReturnTrue()
        {
            // Arrange
            string left = "str";
            string right = "str";

            // Act
            bool isEqual = left.EqualOrdinal(right);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_LeftAndRightAreInDiffCaseButIgnoreCase_ReturnTrue()
        {
            // Arrange
            string left = "str";
            string right = "STR";

            // Act
            bool isEqual = left.EqualOrdinal(right);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_LeftAndRightAreInDiffCaseButCareTheCase_ReturnFalse()
        {
            // Arrange
            string left = "str";
            string right = "STR";

            // Act
            bool isEqual = left.EqualOrdinal(right, false);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void EqualOrdinal_DuplicateTheTurkeyBug_EqualOrdinalSolvesTheProblem()
        {
            // There is a issue when comparing the letter 'i' and 'I' in Turkey culture
            // which is demonstrated as below.

            // Arrange
            string left = "i";
            string right = "I";
            var cultureBackup = Thread.CurrentThread.CurrentCulture;

            // set culture as Turkey, refer to https://msdn.microsoft.com/en-us/library/cc233982.aspx
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR");

            // Act
            bool generalCompareResult = string.Equals("i", "I");
            // generalCompareResult will be False which should be True, this is the bug

            bool isEqual = left.EqualOrdinal(right);

            // rollback the culture
            Thread.CurrentThread.CurrentCulture = cultureBackup;

            // Assert
            Assert.IsTrue(isEqual);
        }
    }

}

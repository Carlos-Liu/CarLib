using CarLib.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class BytesStringConverterTests
    {
        [TestMethod]
        public void ToBase64String_ByteArrayIsNull_ReturnEmptyString()
        {
            var result = BytesStringConverter.ToBase64String(null);
            Assert.AreEqual(string.Empty, result);
        }
              
        [TestMethod]
        public void FromBase64String_StringIsNull_ReturnNull()
        {
            var result = BytesStringConverter.FromBase64String(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FromBase64String_StringIsEmpty_ReturnNull()
        {
            var result = BytesStringConverter.FromBase64String(string.Empty);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IntegrationTest_ConvertToStringAndBack_ByteArrayIsCorrect()
        {
            // Arrange
            var bytes = new byte[] { 1, 2, 3, 4, 5 };

            // Act
            var convertedString = BytesStringConverter.ToBase64String(bytes);
            var convertedBytes = BytesStringConverter.FromBase64String(convertedString);

            // Assert
            CollectionAssert.AreEqual(bytes, convertedBytes);
        }
    }
}

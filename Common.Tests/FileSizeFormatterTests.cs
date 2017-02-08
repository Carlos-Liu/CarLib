using CarLib.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class FileSizeFormatterTests
    {
        [TestMethod]
        public void GetReadableFileSize_SizeIsZero_ZeroByte()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(0);

            // Assert
            Assert.AreEqual("0 bytes", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIsOneByte_OneByte()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(1);

            // Assert
            Assert.AreEqual("1 bytes", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1023Byte_1023Byte()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(1023);

            // Assert
            Assert.AreEqual("1023 bytes", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1024Byte_OneKB()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(1024);

            // Assert
            Assert.AreEqual("1 KB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1MB_OneKB()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(1024 * 1024);

            // Assert
            Assert.AreEqual("1 MB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeJustLargerThan1GB_DisplayGbFormat()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize(1024 * 1024 * 1024 + 1);

            // Assert
            Assert.AreEqual("1 GB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeJustLargerThan1TB_DisplayGbFormat()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize((long)1024 * 1024 * 1024 * 1024 + 1);

            // Assert
            Assert.AreEqual("1 TB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1AndAHalfMb_DisplayCorrectMbFormat()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize((long)(1024 * 1024 * 1.5));

            // Assert
            Assert.AreEqual("1.5 MB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1Point05Mb_DisplayCorrectMbFormat()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize((long)(1024 * 1024 * 1.05));

            // Assert
            Assert.AreEqual("1.05 MB", actual);
        }

        [TestMethod]
        public void GetReadableFileSize_SizeIs1Point085Mb_DisplayCorrectMbFormat()
        {
            // Arrange & Act
            var actual = FileSizeFormatter.GetReadableFileSize((long)(1024 * 1024 * 1.086));

            // Assert
            Assert.AreEqual("1.09 MB", actual);
        }
    }
}

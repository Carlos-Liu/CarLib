using System;
using CarLib.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Extensions
{
    [TestClass]
    public class DateTimeExTests
    {
        [TestMethod]
        public void LocalToUtc_TimeIsMaxValue_ValueNotChanged()
        {
            DateTime time = DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Local);

            var actual = time.LocalToUtc();

            Assert.AreEqual(DateTime.MaxValue, actual);
        }

        [TestMethod]
        public void LocalToUtc_TimeIsMinValue_ValueNotChanged()
        {
            DateTime time = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Local);

            var actual = time.LocalToUtc();

            Assert.AreEqual(DateTime.MinValue, actual);
        }

        [TestMethod]
        public void LocalToUtc_TestCurrentTime_ConvertCorrectly()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime time = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);

            var actual = time.LocalToUtc();

            Assert.IsTrue(TestHelper.AreTheDateTimesEqual(utcNow, actual));
        }

        [TestMethod]
        public void GetLastInstant_SpecifiedTimeIsTheFirstInstantOfDay_GetLastInstantCorrectly()
        {
            DateTime time = new DateTime(2016, 9, 19, 0, 0, 0);
            var expected = new DateTime(2016, 9, 19, 23, 59, 59);
            var actual = time.GetLastInstant();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLastInstant_SpecifiedTimeIsTheLastInstantOfDay_GetLastInstantCorrectly()
        {
            DateTime time = new DateTime(2016, 9, 19, 23, 59, 59);
            var expected = new DateTime(2016, 9, 19, 23, 59, 59);
            var actual = time.GetLastInstant();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetLastInstant_SpecifiedTimeIsTheMiddleInstantOfDay_GetLastInstantCorrectly()
        {
            DateTime time = new DateTime(2016, 9, 19, 12, 0, 0);
            var expected = new DateTime(2016, 9, 19, 23, 59, 59);
            var actual = time.GetLastInstant();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreClosed_TwoTimesAreSame_ReturnTrue()
        {
          // Arrange
          var time1 = new DateTime(2017, 03, 30, 8, 0, 0);
          var time2 = new DateTime(2017, 03, 30, 8, 0, 0);

          // Act
          bool isClosed = time1.AreClosed(time2);

          // Assert
          Assert.IsTrue(isClosed);
        }

        [TestMethod]
        public void AreClosed_TimesAreDiffWith2SecondsAndToleranceIs2Seconds_ReturnTrue()
        {
          // Arrange
          var time1 = new DateTime(2017, 03, 30, 8, 0, 0);
          var time2 = new DateTime(2017, 03, 30, 8, 0, 2);

          // Act
          bool isClosed = time1.AreClosed(time2, 2000);

          // Assert
          Assert.IsTrue(isClosed);
        }

        [TestMethod]
        public void AreClosed_TimesAreDiffWith2SecondsAndToleranceIsLessThan2Seconds_ReturnFalse()
        {
          // Arrange
          var time1 = new DateTime(2017, 03, 30, 8, 0, 2);
          var time2 = new DateTime(2017, 03, 30, 8, 0, 0);

          // Act
          bool isClosed = time1.AreClosed(time2, 1999);

          // Assert
          Assert.IsFalse(isClosed);
        }

        [TestMethod]
        public void AreClosed_TimesAreDiffWith2SecondsAndToleranceIsLargerThan2Seconds_ReturnTrue()
        {
          // Arrange
          var time1 = new DateTime(2017, 03, 30, 8, 0, 2);
          var time2 = new DateTime(2017, 03, 30, 8, 0, 0);

          // Act
          bool isClosed = time1.AreClosed(time2, 2001);

          // Assert
          Assert.IsTrue(isClosed);
        }
    }
}

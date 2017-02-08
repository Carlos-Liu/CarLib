using System;
using CarLib.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Extensions
{
    [TestClass]
    public class TimeSpanExTests
    {
        #region ToReadableString Tests

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void ToReadableString_PassInNegativeValue_ThrowException()
        {
            var timespan = TimeSpan.FromSeconds(-1);
            timespan.ToReadableString();
        }

        [TestMethod]
        public void ToReadableString_PassInZero_Return0Second()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(0);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("0 Second(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_LessThan1Minute_OnlyDisplaySecond()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(59);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("59 Second(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_Exactly1Minute_OnlyDisplayMinute()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(60);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Minute(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_61Seconds_Display1Minute()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(61);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Minute(s) 1 Second(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_119Seconds_Display1Minute()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(119);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Minute(s) 59 Second(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_59MinutesAnd59Seconds_Display2Minutes()
        {
            // Arrange
            var timespan = TimeSpan.FromSeconds(59*60 + 59);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("59 Minute(s) 59 Second(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_Exacyly1Hour_Display1Hour()
        {
            // Current rule is: the duration less than 1 minute will be dropped
            // Arrange
            var timespan = TimeSpan.FromSeconds(60*60);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Hour(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_Exactly1Day_Display1Day()
        {
            // Current rule is: the duration less than 1 minute will be dropped
            // Arrange
            var timespan = TimeSpan.FromSeconds(60*60*24);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Day(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_1DayPlus1Second_Display1Day()
        {
            // Current rule is: the duration less than 1 minute will be dropped
            // Arrange
            var timespan = TimeSpan.FromSeconds(60*60*24 + 1);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Day(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_1DayPlus1Minute_Display1Day1Minute()
        {
            // Current rule is: the duration less than 1 minute will be dropped
            // Arrange
            var timespan = TimeSpan.FromSeconds(60*60*24 + 60);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("1 Day(s) 1 Minute(s)", actual);
        }

        [TestMethod]
        public void ToReadableString_MoreThan2Days_DisplayCorrectly()
        {
            // Current rule is: the duration less than 1 minute will be dropped
            // Arrange
            var timespan = TimeSpan.FromSeconds(60*60*24*2 + 60*60*3 + 4*60 + 1);

            // Act
            var actual = timespan.ToReadableString();

            // Assert
            Assert.AreEqual("2 Day(s) 3 Hour(s) 4 Minute(s)", actual);
        }


        #endregion

        #region ToTimeEstimationString Tests

        [TestMethod]
        public void ToTimeEstimationString_LessThan1Minute_AboutPrefixIsAdded()
        {
            // Arrange
            TimeSpan? timespan = TimeSpan.FromSeconds(59);

            // Act
            var actual = timespan.ToTimeEstimationString();

            // Assert
            Assert.AreEqual("About 59 Second(s)", actual);
        }

        [TestMethod]
        public void ToTimeEstimationString_NullTimeSpan_ShowCalculating()
        {
            // Arrange & Act
            var actual = ((TimeSpan?) null).ToTimeEstimationString();

            // Assert
            Assert.AreEqual("Calculating...", actual);
        }

        #endregion
    }
}

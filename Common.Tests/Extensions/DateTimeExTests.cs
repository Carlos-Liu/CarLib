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
    }
}

using System;

namespace Common.Tests
{
    internal class TestHelper
    {

        public static bool AreTheDateTimesEqual(DateTime left, DateTime right)
        {
            // 10,000 ticks in a millisecond, 10 million ticks in a second.
            const long threshold = 10000000;
            var delta = left.Ticks - right.Ticks;
            return Math.Abs(delta) < threshold;
        }
    }
}

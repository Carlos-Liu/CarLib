using System;
using System.Threading;
using CarLib.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IO.Tests
{
    [TestClass]
    public class FileCopyRemainingTimeCalculatorTests
    {
        [TestMethod]
        public void EvaluateRemainingTime_ByDefault_IsZero()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            Assert.AreEqual(0, actualRemainingTime.TotalSeconds);
        }

        #region Without pausing/resuming

        [TestMethod]
        public void EvaluateRemainingTime_ReportProgressTwiceWithoutPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(8, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void EvaluateRemainingTime_ReportProgressInMilliSeconds_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(1000, 100000);

            // use 100 millisecond to copy 1000 bytes
            Thread.Sleep(100);
            calc.ProgressChanged(2000, 100000);

            // use 50 millisecond to copy 1000 bytes
            Thread.Sleep(20);
            calc.ProgressChanged(3000, 100000);

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(5.82, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void EvaluateRemainingTime_ReportProgress3TimesWithSameSpeedWithoutPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // use 1 second to copy 10 bytes (30 - 20)
            Thread.Sleep(1000);
            calc.ProgressChanged(30, 100);

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(7, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void EvaluateRemainingTime_ReportProgress3TimesWithDiffSpeedWithoutPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // use 1 second to copy 40 bytes (60 - 20)
            Thread.Sleep(1000);
            calc.ProgressChanged(60, 100);

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(1.6, actualRemainingTime.TotalSeconds);
        }

        #endregion

        #region With pausing/resuming

        [TestMethod]
        public void PauseResume_ReportProgressTwiceWithPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // suppose pausing for 3 seconds
            calc.Pause();
            Thread.Sleep(3000);
            calc.Resume();

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(8, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void PauseResume_ReportProgress3TimesWithSameSpeedWithPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // suppose pausing for 3 seconds
            calc.Pause();
            Thread.Sleep(3000);
            calc.Resume();

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // suppose pausing for 1 second
            calc.Pause();
            Thread.Sleep(1000);
            calc.Resume();

            // use 1 second to copy 10 bytes (30 - 20)
            Thread.Sleep(1000);
            calc.ProgressChanged(30, 100);
            
            // suppose pausing for 2 seconds
            calc.Pause();
            Thread.Sleep(2000);
            calc.Resume();

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(7, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void PauseResume_ReportProgress3TimesWithDiffSpeedWithPausing_EstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            calc.Pause();
            Thread.Sleep(3000);
            calc.Resume();

            // use 1 second to copy 40 bytes (60 - 20)
            Thread.Sleep(1000);
            calc.ProgressChanged(60, 100);

            // Act
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(1.6, actualRemainingTime.TotalSeconds);
        }

        #endregion

        [TestMethod]
        public void Reset_EvaluateTimeJustAfterReset_IsZero()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // Act
            calc.Reset();
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            Assert.AreEqual(0, actualRemainingTime.TotalSeconds);
        }

        [TestMethod]
        public void Reset_CalcTwice_The2ndEstimationIsCorrect()
        {
            // Arrange
            var calc = new FileCopyRemainingTimeCalculator();

            calc.ProgressChanged(10, 100);

            // use 1 second to copy 10 bytes (20 - 10)
            Thread.Sleep(1000);
            calc.ProgressChanged(20, 100);

            // Act
            calc.Reset();

            // report progress for another file copy
            calc.ProgressChanged(20, 100);

            // use 3 seconds to copy 40 bytes (60 - 20)
            Thread.Sleep(3000);
            calc.ProgressChanged(60, 100);

            // estimate for the 2nd file copy
            var actualRemainingTime = calc.EvaluateRemainingTime();

            // Assert
            AssertSecondsWithTolerance(3, actualRemainingTime.TotalSeconds);
        }

        private void AssertSecondsWithTolerance(double expectedSeconds, double actualSeconds)
        {
            // Considerate the coding execution performance, | expectedSeconds - actualSeconds | < 2 seconds is acceptable
            const double toleranceSeconds = 0.5;

            var diff = Math.Abs(expectedSeconds - actualSeconds);
            Assert.IsTrue(diff < toleranceSeconds);
        }
    }
}

using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace CarLib.IO
{
    /// <summary>
    /// Helper class to estimate the remaining time on file copy.
    /// </summary>
    public class FileCopyRemainingTimeCalculator
    {
        private readonly Stopwatch _Watch = new Stopwatch();
        private readonly Stopwatch _PauseWatch = new Stopwatch();
        private bool IsFirstProgress { get; set; }
        private long TotalBytesCopied { get; set; }
        private long TotalFileBytesToCopy { get; set; }
        // The total time taken to do coping. 
        private double TotalTimeTakenInSeconds { get { return _Watch.Elapsed.TotalSeconds - TotalPausedTimeInSeconds; } }
        // The total paused time in seconds
        private double TotalPausedTimeInSeconds { get; set; }

        // The copied bytes for the first time reporting the progress.
        // Q: Why need record this? 
        // A: When ProgressChanged is called for the first time, there may already be N bytes copied,
        //      but how long did it taken to copy the N bytes? This class may not know. So just exclude
        //      the copied bytes for the first time when do the remaining time estimation.
        private long CopiedBytesForFirstTime { get; set; }

        public FileCopyRemainingTimeCalculator()
        {
            Reset();
        }

        private void StartEstimating()
        {
            TotalBytesCopied = 0;

            _Watch.Start();
        }

        /// <summary>
        /// Report the copy progress.
        /// </summary>
        /// <remarks>
        /// The <paramref name="totalCopiedSizeBytes"/> may not be 0 for the first time reporting the progress.
        /// </remarks>
        /// <param name="totalCopiedSizeBytes">The total copied bytes.</param>
        /// <param name="totalFileSizeBytes">The total bytes to be copied.</param>
        public void ProgressChanged(long totalCopiedSizeBytes, long totalFileSizeBytes)
        {
            if (IsFirstProgress)
            {
                StartEstimating();
                TotalFileBytesToCopy = totalFileSizeBytes;
                CopiedBytesForFirstTime = totalCopiedSizeBytes;
                IsFirstProgress = false;
            }

            Contract.Assert(totalFileSizeBytes == TotalFileBytesToCopy, "The total bytes to copy has been changed.");

            TotalBytesCopied = totalCopiedSizeBytes;
            if (TotalBytesCopied == totalFileSizeBytes)
            {
                _Watch.Stop();
            }
        }

        /// <summary>
        /// Evaluate the remaining time.
        /// </summary>
        /// <returns>Return the evaluated remaining time. And return null if cannot evaluate the remaining time.</returns>
        public TimeSpan? EvaluateRemainingTime()
        {
            double? remainingSeconds = null;
            if (TotalFileBytesToCopy > TotalBytesCopied)
            {
                var alreadyCopiedBytesWithTiming = TotalBytesCopied - CopiedBytesForFirstTime;
                if (alreadyCopiedBytesWithTiming == 0)
                {
                    return null;
                }

                // remaining seconds = (TotalTimeTakenInSeconds / alreadyCopiedBytesWithTiming) * (TotalFileBytesToCopy - TotalBytesCopied);
                remainingSeconds = TotalTimeTakenInSeconds * (TotalFileBytesToCopy - TotalBytesCopied) / alreadyCopiedBytesWithTiming;
            }

            if (remainingSeconds.HasValue)
            {
                var timeSpan = TimeSpan.FromSeconds(remainingSeconds.Value);
            return timeSpan;
        }

            return null;
        }
        /// <summary>
        /// Pause the timing.
        /// <remarks>Resume must be called in pair.</remarks>
        /// </summary>
        public void Pause()
        {
            _PauseWatch.Restart();
        }

        /// <summary>
        /// Resume the timing.
        /// </summary>
        public void Resume()
        {
            _PauseWatch.Stop();
            TotalPausedTimeInSeconds += _PauseWatch.Elapsed.TotalSeconds;
        }

        /// <summary>
        /// Reset the timing.
        /// </summary>
        public void Reset()
        {
            IsFirstProgress = true;
            _Watch.Reset();
            TotalBytesCopied = 0;
            TotalFileBytesToCopy = 0;
            CopiedBytesForFirstTime = 0;
            TotalPausedTimeInSeconds = 0;
        }
    }
}

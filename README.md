# CarLib

[![Build status](https://ci.appveyor.com/api/projects/status/7yixd9vs2iqqpjf1/branch/master?svg=true)](https://ci.appveyor.com/project/Carlos-Liu/carlib/branch/master)
[![codecov](https://codecov.io/gh/Carlos-Liu/CarLib/branch/master/graph/badge.svg)](https://codecov.io/gh/Carlos-Liu/CarLib)

The library includes commonly used functions during the development work.

####  TimeSpan.ToReadableString
> Get the friendly formated display string for specified time span, e.g.
```
var timespan = new TimeSpan(2, 0, 25);
var friendlyString = timespan.ToReadableString();
// friendlyString is "2 Hour(s) 25 Second(s)".
```

#### TimeSpan.ToTimeEstimationString
> Get the friendly formated display string for time , e.g. 
```
var timespan = new TimeSpan(2, 0, 25);
var estimationString = timespan.ToTimeEstimationString();
// estimationString is "About 2 Hour(s) 25 Second(s)".
```

#### FileSizeFormatter.GetReadableFileSize
> Provides the human readable format for the specified file size. e.g. 
```
var fileSize = FileSizeFormatter.GetReadableFileSize(1024 * 1024 * 1.5);
// fileSize is "1.5 MB".
```
```
var fileSize = FileSizeFormatter.GetReadableFileSize(@"c:\temp\123.txt");
// fileSize is "112 KB".
```

#### PathUtilities.AddTrailingBackslash
> Add the trailing slash at the end of specified path just when needed. e.g.
```
const string testDirectory = @"C:\folder\";
var actual = PathUtilities.AddTrailingBackslash(testDirectory);
// actual is "C:\folder\".
```
```
const string testDirectory = @"  C:/folder  "
var actual = PathUtilities.AddTrailingBackslash(testDirectory);
// actual is C:/folder/
```

#### SpecialFolderChecker.InWindowsDirectory
> Check if the specified directory in Windows directory or SYSROOT. e.g.
```
string directory = @"C:\Windows
bool actual = SpecialFolderChecker.InWindowsDirectory(directory);
// actual is True.
```

#### SpecialFolderChecker.InUserProfile
> Check if the specified directory in the user's profile folder. e.g.
```
string directory = @"C:\Users\<login user name>";
bool actual = SpecialFolderChecker.InUserProfile(directory);
// actual is True.
```

#### FileCopyRemainingTimeCalculator
> Helper class to estimate the remaining time on file copy. 
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

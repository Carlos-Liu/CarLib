using System.Globalization;
using System.Threading;
using BecLS.Framework.Test;
using Xunit;

namespace Fip.Infrastructure.Tests;
public class StringExtensionTest : IClassFixture<TestFixture<UnitTestModule>>
{
    [Fact]
    public void CompareInvariantIgnoreCase_BothNull_True()
    {
        // Arrange
        string left = null;
        string right = null;

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_LeftNullRightNotNull_False()
    {
        // Arrange
        string left = null;
        var right = "value";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_LeftNotNullRightNull_False()
    {
        // Arrange
        var left = "value";
        string right = null;

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_SameTextDifferentCase_True()
    {
        // Arrange
        var left = "HeLLo WoRLd";
        var right = "hello world";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_BothEmptyStrings_True()
    {
        // Arrange
        var left = string.Empty;
        var right = string.Empty;

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);
    }
    [Fact]
    public void CompareInvariantIgnoreCase_LeftEmptyRightNotNull_False()
    {
        // Arrange
        var left = string.Empty;
        var right = "value";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_LeftNotNullRightEmpty_False()
    {
        // Arrange
        var left = "value";
        var right = string.Empty;

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_WhitespaceDifferentCounts_False()
    {
        // Arrange
        var left = " ";
        var right = "  ";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_SpecialCharactersSameCaseInsensitive_True()
    {
        // Arrange
        var left = "café"; // contains accent
        var right = "CAFÉ";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_TurkishI_DifferentInInvariant_False()
    {
        // Arrange
        var left = "i";   // Latin small letter i
        var right = "İ";  // Latin capital letter I with dot above

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CompareInvariantIgnoreCase_EnglishCulture_True()
    {
        // Arrange
        var backupCulture = Thread.CurrentThread.CurrentCulture;

        var cultureInfo = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        var left = "i";
        var right = "I";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);

        // rollback the culture
        Thread.CurrentThread.CurrentCulture = backupCulture;
    }

    [Fact]
    public void CompareInvariantIgnoreCase_TurkeyCulture_True()
    {
        var backupCulture = Thread.CurrentThread.CurrentCulture;

        var cultureInfo = new CultureInfo("tr-TR");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        var left = "i";
        var right = "I";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);

        // rollback the culture
        Thread.CurrentThread.CurrentCulture = backupCulture;
    }

    [Fact]
    public void CompareInvariantIgnoreCase_TurkishWord_SameWhenIgnoringCase_True()
    {
        // Arrange
        var left = "istanbul";
        var right = "ISTANBUL";

        // Act
        var result = left.CompareInvariantIgnoreCase(right);

        // Assert
        Assert.True(result);
    }
}

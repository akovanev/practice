namespace DateExtensions.UnitTests;

public class DateExtensionsTests
{
    [Theory]
    [InlineData(2024, true)]
    [InlineData(2022, false)]
    [InlineData(2000, true)]
    [InlineData(3000, false)]
    public void IsLeap_PositiveYear_ReturnsResult(int year, bool expected)
    {
        // Act
        bool isLeap = year.IsLeap();
        
        // Assert
        Assert.Equal(expected, isLeap);
    }

    [Fact]
    public void GetIso8601WeekOfYear_RandomDate_ReturnsWeek()
    {
        // Assign
        var date = new DateTime(2024, 06, 21);
        int expectedWeek = 25;
        
        // Act
        int actualWeek = date.GetIso8601WeekOfYear();
        
        // Assert
        Assert.Equal(expectedWeek, actualWeek);
    }
}
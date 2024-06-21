namespace DateExtensions;

public static class DateExtensions
{
    public static bool IsLeap(this int year)
    {
        // Leap year is divisible by 4
        // Except for years which are divisible by 100
        // But including years which are divisible by 400

        if (year <= 0)
            throw new ArgumentException("Year should be greater than 0");
        
        if (year % 400 == 0)
        {
            return true;
        }

        if (year % 100 == 0)
        {
            return false;
        }

        return year % 4 == 0;
    }
    
    public static int GetIso8601WeekOfYear(this DateTime date)
    {
        // ISO 8601 week 1 is the week with the year's first Thursday in it
        DateTime jan1 = new DateTime(date.Year, 1, 1);
        int daysOffset = jan1.DayOfWeek.DayOfWeekOffset();

        // First Thursday of the year
        DateTime firstThursday = jan1.AddDays(3 - daysOffset);

        // Start of the first week
        DateTime startOfFirstWeek = firstThursday.AddDays(-3);

        // Calculate the week number
        int weekNumber = (date - startOfFirstWeek).Days / 7 + 1;
        return weekNumber;
    }

    internal static int DayOfWeekOffset(this DayOfWeek day)
        // Monday = 0, ..., Sunday = 6
        => ((int)day + 6) % 7;
}
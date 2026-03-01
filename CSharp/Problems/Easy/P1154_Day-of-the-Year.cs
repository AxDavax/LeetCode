/*
    1154. Day of the Year

    Given a string date representing a Gregorian calendar date formatted as YYYY-MM-DD, 
    return the day number of the year.

 
    Example 1:

        Input: date = "2019-01-09"
        Output: 9
        Explanation: Given date is the 9th day of the year in 2019.

    Example 2:

        Input: date = "2019-02-10"
        Output: 41


    Constraints:

        date.length == 10
        date[4] == date[7] == '-', and all other date[i] 's are digits
        date represents a calendar date between Jan 1st, 1900 and Dec 31st, 2019.

 */

namespace LeetCode.CSharp.Problems.Easy;

public static class P1154_Day_of_the_Year
{
    #region Optimal Solution
    
    /// <summary>
    /// Complexité temporelle : O(1) 
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int DayOfYear_DateTime(string date)
    {
        var d = DateTime.Parse(date);
        return d.DayOfYear;
    }

    #endregion

    #region Alternative Solutions

    private static readonly int[] cumulative =
    {
        0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334
    };

    /// <summary>
    /// Complexité temporelle : O(1) 
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int DayOfYear_O1(string date)
    {
        int year = int.Parse(date[..4]);
        int month = int.Parse(date[5..7]);
        int day = int.Parse(date[8..]);

        int days = cumulative[month - 1] + day;

        if (month > 2 && IsLeapYear(year)) days++;

        return days;
    }

    /// <summary>
    /// Complexité temporelle : O(12) 
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int DayOfYear_arrays(string date)
    {
        int year = int.Parse(date[..4]);
        int month = int.Parse(date[5..7]);
        int day = int.Parse(date[8..]);

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int sum = 0;

        for (int j = 1; j < month; j++)
            sum += daysInMonth[j - 1];

        if (month > 2 && IsLeapYear(year)) sum++;

        return sum + day;
    }


    /// <summary>
    /// Complexité temporelle : O(12) 
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int DayOfYear_switch(string date)
    {
        int year = Convert.ToInt32(date[..4]);
        int month = Convert.ToInt32(date.Substring(5, 2));
        int day = Convert.ToInt32(date.Substring(8, 2));
      
        int sum = 0;

        for (int j = 1; j < month; j++)
            sum += DaysInMonth(j, year);

        return sum + day;
    }

    #endregion

    #region Methods

    static bool IsLeapYear(int year) => ((year % 4 == 0) & (year % 100 != 0)) || (year % 400 == 0);


    static int DaysInMonth(int month, int year) => month switch
    {
        4 or 6 or 9 or 11 => 30,
        2 => (IsLeapYear(year)) ? 29 : 28,
        _ => 31
    };

    #endregion

    #region Helper

    static void Print(string date, Func<string, int> method)
    {
        Console.WriteLine($"The date {date} is the {method(date)}th day of the year.");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print("2019-01-09", DayOfYear_DateTime);
        Print("2019-01-09", DayOfYear_O1);
        Print("2019-01-09", DayOfYear_arrays);
        Print("2019-01-09", DayOfYear_switch);
        Console.Read();

        Print("2019-02-10", DayOfYear_DateTime);
        Print("2019-02-10", DayOfYear_O1);
        Print("2019-02-10", DayOfYear_arrays);
        Print("2019-02-10", DayOfYear_switch);
    }

    #endregion
}
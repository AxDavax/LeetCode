/*
    1185. Day of the Week

    Given a date, return the corresponding day of the week for that date.

    The input is given as three integers representing the day, month and year respectively.

    Return the answer as one of the following values 
    {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.

    Note: January 1, 1971 was a Friday.

 
    Example 1:

        Input: day = 31, month = 8, year = 2019
        Output: "Saturday"

    Example 2:

        Input: day = 18, month = 7, year = 1999
        Output: "Sunday"

    Example 3:

        Input: day = 15, month = 8, year = 1993
        Output: "Sunday"


    Constraints:

        The given dates are valid dates between the years 1971 and 2100.
*/
namespace LeetCode.CSharp.Problems.Easy;

public static class P1185_Day_of_the_Week
{
    #region Optimal Solution
    
    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static string DayOfTheWeek_DateTime(int day, int month, int year)
    {
        string[] week = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        var date = new DateTime(year, month, day);
        return week[(int)date.DayOfWeek];
    }

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static string DayOfTheWeek_O1(int day, int month, int year)
    {
        string[] week = { "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int years = year - 1971;

        int days = years * 365;

        days += (year - 1969) / 4;
        days -= (year - 1901) / 100;
        days += (year - 1601) / 400;

        for (int j = 1; j < month; j++)
            days += daysInMonth[j - 1];

        if (month > 2 && IsLeapYear(year)) days++;

        return DayOfWeek((days + day) % 7);
    }

    /// <summary>
    /// Time Complexity : O(Y) where Y is the number of years since 1971 
    /// Spatial Complexity : O(1)
    /// </summary>

    public static string DayOfTheWeek_arrays(int day, int month, int year)
    {
        string[] week = { "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" }; 
        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int days = 0;
        
        for (int i = 1971; i < year; i++)
            days += (IsLeapYear(i)) ? 366 : 365;

        for (int j = 1; j < month; j++)
            days += (j == 2 && IsLeapYear(year)) ? 29 : daysInMonth[j - 1];

        return DayOfWeek((days + day) % 7);
    }

    /// <summary>
    /// Time Complexity : O(Y) where Y is the number of years since 1971 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static string DayOfTheWeek_switch(int day, int month, int year)
    {
        int sum = 0;
        for (int i = 1971; i < year; i++)
            sum += (IsLeapYear(i)) ? 366 : 365;

        for (int j = 1; j < month; j++)
            sum += DaysInMonth(j, year);
        
        return DayOfWeek((sum + day) % 7);
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

    static string DayOfWeek(int wkDay) => wkDay switch
    {
        0 => "Thursday",
        1 => "Friday",
        2 => "Saturday",
        3 => "Sunday",
        4 => "Monday",
        5 => "Tuesday",
        6 => "Wednesday",
        _ => "None"
    };

    #endregion

    #region Helper

    delegate string DayOfTheWeek(int d, int m, int y);

    static void Print(int day, int month, int year, DayOfTheWeek method)
    {
        Console.WriteLine($"{year}-{month}-{day} is a {method(day, month, year)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(31, 8, 2019, DayOfTheWeek_DateTime);
        Print(31, 8, 2019, DayOfTheWeek_O1);
        Print(31, 8, 2019, DayOfTheWeek_arrays);
        Print(31, 8, 2019, DayOfTheWeek_switch);
        Console.Read();

        Print(18, 7, 1999, DayOfTheWeek_DateTime);
        Print(18, 7, 1999, DayOfTheWeek_O1);
        Print(18, 7, 1999, DayOfTheWeek_arrays);
        Print(18, 7, 1999, DayOfTheWeek_switch);
        Console.ReadLine();
        Console.Read();

        Print(15, 8, 1993, DayOfTheWeek_DateTime);
        Print(15, 8, 1993, DayOfTheWeek_O1);
        Print(15, 8, 1993, DayOfTheWeek_arrays);
        Print(15, 8, 1993, DayOfTheWeek_switch);
        Console.Read();
    }

    #endregion
}
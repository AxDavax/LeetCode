/*
    1360. Number of Days Between Two Dates

    Write a program to count the number of days between two dates.

    The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.

 
    Example 1:

        Input: date1 = "2019-06-29", date2 = "2019-06-30"
        Output: 1

    Example 2:

        Input: date1 = "2020-01-15", date2 = "2019-12-31"
        Output: 15


    Constraints:

        The given dates are valid dates between the years 1971 and 2100.
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1360_Number_of_Days_Between_Two_Dates
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int DaysBetweenDateTimes(string date1, string date2)
    {
        DateTime dt1 = DateTime.Parse(date1);
        DateTime dt2 = DateTime.Parse(date2);
        TimeSpan diffDT = dt2 - dt1;
        return (int)Math.Abs(diffDT.TotalDays);
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(N) where N is the number of years between the two dates
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int DaysBetweenDates(string date1, string date2)
    {
        var (year1, year2) = DTPart(date1, date2, 0, 4);
        var (month1, month2) = DTPart(date1, date2, 5, 2);
        var (day1, day2) = DTPart(date1, date2, 8, 2);

        if (year1 == year2)
        {
            if ((month1 == month2) & (day1 > day2))
                Permuter(ref day1, ref day2);
            else if (month1 > month2)
            {
                Permuter(ref month1, ref month2);
                Permuter(ref day1, ref day2);
            }
        }
        else if (year1 > year2)
        {
            Permuter(ref year1, ref year2);
            Permuter(ref month1, ref month2);
            Permuter(ref day1, ref day2);
        }

        int sum = 0;

        for (int i = year1; i < year2; i++)
            sum += (IsLeapYear(i)) ? 366 : 365;

        sum += DaysInYear(year2, month2, day2);
        sum -= DaysInYear(year1, month1, day1);

        return sum;
    }

    #endregion

    #region Alternative's Methods

    static (int, int) DTPart(string date1, string date2, int start, int length) =>
            (Convert.ToInt32(date1.Substring(start, length)), Convert.ToInt32(date2.Substring(start, length)));

    static void Permuter(ref int dt1, ref int dt2)
    {
        int tmp = dt1;
        dt1 = dt2;
        dt2 = tmp;
    }

    static bool IsLeapYear(int year) => ((year % 4 == 0) & (year % 100 != 0)) || (year % 400 == 0);

    static int DaysInYear(int year, int month, int day)
    {
        int sum = 0;
        if (month == 2)
            sum += 31;
        else if (month > 2)
        {
            for (int j = 1; j < month; j++)
                sum += DaysInMonth(j, year);
        }

        return sum + day;
    }

    static int DaysInMonth(int month, int year) => month switch
    {
        4 or 6 or 9 or 11 => 30,
        2 => (IsLeapYear(year)) ? 29 : 28,
        _ => 31
    };

    #endregion

    #region Helper

    public static void Print(string date1, string date2)
    {
        Console.WriteLine($"The number of days between {date1} and {date2} is {DaysBetweenDateTimes(date1, date2)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print("2019-06-29", "2019-06-30"); // 1
        Print("2020-01-15", "2019-12-31"); // 15
    }

    #endregion
}
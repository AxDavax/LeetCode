/*
    168. Excel Sheet Column Title

    Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

    For example:

        A-> 1
        B-> 2
        C-> 3
        ...
        Z-> 26
        AA-> 27
        AB-> 28
        ...
 

    Example 1:

        Input: columnNumber = 1
        Output: "A"

    Example 2:

        Input: columnNumber = 28
        Output: "AB"

    Example 3:

        Input: columnNumber = 701
        Output: "ZY"


    Constraints:    1 <= columnNumber <= 2^31 - 1
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0168_Excel_Sheet_Column_Title
{
    #region Solution

    /// <summary>
    /// Time Complexity : O(log(n))
    /// Spatial Complexity : O(log(n))
    /// </summary>
    public static string ConvertToTitle(int columnNumber)
    {
        List<char> title = new();

        while (columnNumber-- > 0)
        {
            title.Add((char)((columnNumber % 26) + 'A'));
            columnNumber /= 26;
        }

        title.Reverse();
        return new string(title.ToArray());
    }

    #endregion

    #region Test

    public static void Test()
    {
        int colNumb = 701;
        Console.WriteLine($"The columnNumber {colNumb} is titled : {ConvertToTitle(colNumb)}");
        Console.Read();
    }

    #endregion
}
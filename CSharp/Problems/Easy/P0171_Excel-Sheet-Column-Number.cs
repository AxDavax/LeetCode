/*
    171. Excel Sheet Column Number

    Given a string columnTitle that represents the column title as appears in an Excel sheet, 
    return its corresponding column number.

    For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
    ...
 

    Example 1:

        Input: columnTitle = "A"
        Output: 1

    Example 2:

        Input: columnTitle = "AB"
        Output: 28

    Example 3:

        Input: columnTitle = "ZY"
        Output: 701
 

    Constraints:

        1 <= columnTitle.length <= 7
        columnTitle consists only of uppercase English letters.
        columnTitle is in the range ["A", "FXSHRXW"].

 */

namespace LeetCode.CSharp.Problems.Easy;

public static class P0171_Excel_Sheet_Column_Number
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int TitleToNumber(string columnTitle)
    {
        int ans = 0;

        foreach (var ch in columnTitle)
        {
            int res = ch - 'A' + 1;
            ans = ans * 26 + res;
        }

        return ans;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int TitleToNumberPow(string columnTitle)
    {
        int max = columnTitle.Length - 1, sum = 0;

        for (int i = 0; i <= max; i++)
            sum += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, max - i);

        return sum;
    }

    #endregion

    #region Test

    public static void Test()
    {
        // Console.WriteLine(TitleToNumber("A")); // 1
        // Console.WriteLine(TitleToNumber("AB")); // 28
        // Console.WriteLine(TitleToNumber("ZY")); // 701

        string columnExcel = "BS";
        Console.WriteLine($"The Excel column {columnExcel} represents the " +
                          $"{TitleToNumber(columnExcel)} th column");
        Console.Read();
    }

    #endregion
}

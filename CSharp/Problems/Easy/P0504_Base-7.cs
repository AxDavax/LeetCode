/*
    504. Base 7
    
    Given an integer num, return a string of its base 7 representation.

 
    Example 1:

        Input: num = 100
        Output: "202"

    Example 2:

        Input: num = -7
        Output: "-10"


    Constraints:

        -10^7 <= num <= 10^7
*/

using System.Text;

namespace LeetCode.CSharp.Problems.Easy;

public static class P0504_Base_7
{
    #region Solution

    /// <summary>
    /// Complexité temporelle : O(log7(n))
    /// Complexité spatialle : O(log7(n))
    /// </summary>
    public static string ConvertToBase7(int num)
    {
        if (num == 0) return "0";
        
        var res = new StringBuilder();
        
        int n = Math.Abs(num);
        while (n > 0)
        {
            res.Append(n % 7);
            n /= 7;
        }
        
        if (num < 0) res.Append('-');
        char[] arr = res.ToString().ToCharArray();
        
        Array.Reverse(arr);
        return new string(arr);
    }

    #endregion

    #region Test

    public static void Test()
    {
        int num = 100;
        Console.WriteLine($"Input: num = {num}");
        Console.WriteLine($"Output: \"{ConvertToBase7(num)}\"");

        num = -7;
        Console.WriteLine($"Input: num = {num}");
        Console.WriteLine($"Output: \"{ConvertToBase7(num)}\"");
    }

    #endregion
}
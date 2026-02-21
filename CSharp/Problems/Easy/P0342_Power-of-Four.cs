/*
    342. Power of Four
    
    Given an integer n, return true if it is a power of four. Otherwise, return false.

    An integer n is a power of four, if there exists an integer x such that n == 4x.

 
    Example 1:

        Input: n = 16
        Output: true

    Example 2:

        Input: n = 5
        Output: false

    Example 3:

        Input: n = 1
        Output: true


    Constraints:

    -2^31 <= n <= 2^31 - 1


    Follow up: Could you solve it without loops/recursion?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0342_Power_of_Four
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(1)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPowerOfFour_Bitwise(int n)
    {
        return n > 0 && (n & (n - 1)) == 0   
                     && (n & 0x55555555) != 0; // a set bit at an even position
    }

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Time Complexity : O(1)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPowerOfFour_Mod3(int n) => n > 0 && (n & (n - 1)) == 0 && (n % 3 == 1);

    /// <summary>
    /// Time Complexity : O(log4(n))
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPowerOfFour_Iterative(int n)
    {
        if (n <= 0) return false;

        while (n % 4 == 0)
            n /= 4;

        return n == 1;
    }

    #endregion

    #region Helper

    public static void Print(int n, Func<int, bool> method)
    {
        Console.WriteLine($"Is {n} a power of 4 : {method(n)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(16, IsPowerOfFour_Bitwise);
        Print(5, IsPowerOfFour_Bitwise);
        Print(1, IsPowerOfFour_Bitwise);
        Print(300, IsPowerOfFour_Bitwise);
    }

    #endregion
}
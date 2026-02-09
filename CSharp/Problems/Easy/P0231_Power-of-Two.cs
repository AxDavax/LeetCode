/*
    231. Power of Two    

    Given an integer n, return true if it is a power of two. Otherwise, return false.

    An integer n is a power of two, if there exists an integer x such that n == 2^x.


    Example 1:

        Input: n = 1
        Output: true
        Explanation: 2^0 = 1
    
    Example 2:

        Input: n = 16
        Output: true
        Explanation: 2^4 = 16
    
    Example 3:

        Input: n = 3
        Output: false


    Constraints:

        -2^31 <= n <= 2^31 - 1


    Follow up: Could you solve it without loops/recursion?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0231_Power_of_Two
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static bool IsPowerOfTwo_Bit(int n) => n > 0 && (n & (n - 1)) == 0;

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static bool IsPowerOfTwo(int n) => double.IsInteger(Math.Log2(n));

    #endregion

    #region Helper

    public static void Print(int n)
    {
        Console.WriteLine($"Is {n} a power of 2 : {IsPowerOfTwo(n)}"); 
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(1);    // True
        Print(16);   // True
        Print(3);    // False
        Print(514);  // False
    }

    #endregion
}
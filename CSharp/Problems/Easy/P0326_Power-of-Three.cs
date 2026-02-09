/*
    326. Power of Three
    
    Given an integer n, return true if it is a power of three. Otherwise, return false.

    An integer n is a power of three, if there exists an integer x such that n == 3x.

 
    Example 1:

        Input: n = 27
        Output: true
        Explanation: 27 = 3^3
    
    Example 2:

        Input: n = 0
        Output: false
        Explanation: There is no x where 3^x = 0.
    
    Example 3:

        Input: n = -1
        Output: false
        Explanation: There is no x where 3^x = (-1).
 
    Constraints:

    -2^31 <= n <= 2^31 - 1


    Follow up: Could you solve it without loops/recursion?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0326_Power_of_Three
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static bool IsPowerOfThree_Optimal(int n)
    {
        // 3^19 is the largest power of 3 that fits in a 32-bit signed integer
        return n > 0 && 1162261467 % n == 0;
    }

    #endregion

    #region Alternatives Solution

    /// <summary>
    /// Complexité temporelle : O(log3(n))
    /// Complexité spatialle : O(1)
    /// </summary>
    public static bool IsPowerOfThree_Iterative(int n)
    {
        if (n <= 0) return false;

        while (n % 3 == 0)
            n /= 3;

        return n == 1;
    }

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static bool IsPowerOfThree_Log(int n)
    {
        // pas parfaite pour les nombres négatifs et zéro, 
        // mais elle est rapide pour les autres cas
        return double.IsInteger(Math.Log(n, 3));
    }

    #endregion

    #region Helper

    public static void Print(int n) => Console.WriteLine($"Is {n} a power of three? {IsPowerOfThree_Optimal(n)}");

    #endregion

    #region Test

    public static void Test()
    {
        Print(27); // true
        Print(0);  // false
        Print(-1); // false
    }

    #endregion
}
/*
    1137. N-th Tribonacci Number

    The Tribonacci sequence Tn is defined as follows: 

    T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.

    Given n, return the value of Tn.

 
    Example 1:

        Input: n = 4
        Output: 4
        Explanation:
            T_3 = 0 + 1 + 1 = 2
            T_4 = 1 + 1 + 2 = 4
    
    Example 2:

        Input: n = 25
        Output: 1389537

    Constraints: 0 <= n <= 37
        The answer is guaranteed to fit within a 32-bit integer, ie. answer <= 2^31 - 1.
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1137_Tribonnaci_Number
{
    #region Optimal Solution

    /// <summary>
    /// Time complexity : O(n)
    /// Spatial complexity : O(1)
    /// </summary>
    public static int Tribonacci_Iterative(int n)
    {
        if (n <= 1) return n;
        if (n == 2) return 1;

        int a = 0, b = 1, c = 1, sum = 2;

        for (int i = 3; i <= n; i++)
        {
            sum = a + b + c;
            a = b;
            b = c;
            c = sum;
        }

        return sum;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time complexity : O(n)
    /// Spatial complexity : O(n)
    /// <summary> 
    public static int Tribonacci_Array(int n)
    {
        if (n <= 1) return n;
        if (n == 2) return 1;
        
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;
        
        for (int i = 3; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
        
        return dp[n];
    }

    #endregion

    #region Test

    public static void Test()
    {
        Console.WriteLine(Tribonacci_Iterative(4)); // Output: 4
        Console.WriteLine(Tribonacci_Iterative(25)); // Output: 1389537
    }

    #endregion
}
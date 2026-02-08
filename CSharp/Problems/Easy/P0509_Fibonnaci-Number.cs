/*
    509. Fibonacci Number
 
    The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
    such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,

        F(0) = 0, F(1) = 1
        F(n) = F(n - 1) + F(n - 2), for n > 1.
    
    Given n, calculate F(n).


    Example 1:

        Input: n = 2
        Output: 1
        Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.
    
    Example 2:

        Input: n = 3
        Output: 2
        Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.
    
    Example 3:

        Input: n = 4
        Output: 3
        Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.


    Constraints:
        0 <= n <= 30
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0509_Fibonnaci_Number
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int Fib_Iterative(int n)
    {
        if (n <= 1) return n;

        int a = 0, b = 1, sum = 1;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return sum;
    }

    #endregion

    #region Alternatives Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int Fib_Array(int n)
    {
        if (n <= 1) return n;

        int[] fib = new int[n + 1];

        fib[0] = 0;
        fib[1] = 1;

        for (int i = 2; i <= n; i++)
            fib[i] = fib[i - 2] + fib[i - 1];

        return fib[n];
    }
    
    /// <summary>
    /// Complexité temporelle : O(2^n)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int Fib_Recursive(int n)
    {
        return n switch
        {
            0 => 0,
            1 => 1,
            _ => Fib_Recursive(n - 1) + Fib_Recursive(n - 2)
        };
    }

    #endregion

    #region Test
    
    public static void Test()
    {
        for (int n = 0; n <= 10; n++)
            Console.WriteLine($"Fib({n}) = {Fib_Iterative(n)}");
    }

    #endregion
}
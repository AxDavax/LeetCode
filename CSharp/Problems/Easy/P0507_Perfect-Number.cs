/*
    507. Perfect Number
 
    A perfect number is a positive integer that is equal to the sum of its positive divisors, 
    excluding the number itself. A divisor of an integer x is an integer that can divide x evenly.

    Given an integer n, return true if n is a perfect number, otherwise return false.

 
    Example 1:

        Input: num = 28
        Output: true
        Explanation: 28 = 1 + 2 + 4 + 7 + 14
                     1, 2, 4, 7, and 14 are all divisors of 28.
    
    Example 2:

        Input: num = 7
        Output: false


    Constraints: 1 <= num <= 10^8
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0507_Perfect_Number
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(√n)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPerfectNumber_Sqrt(int num)
    {
        if (num <= 1) return false;

        int sum = 1;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                sum += i;
                if (i * i != num)
                    sum += num / i;
            }
        }

        return sum == num;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(n)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPerfectNumber_Full(int num)
    {
        if (num <= 1) return false;

        int sum = 0;
        
        for (int i = 1; i < num; i++)
            if (num % i == 0)
                sum += i;

        return sum == num;
    }

    #endregion

    #region Helper

    static void Print(int num) 
    {
        Console.WriteLine($"Is {num} a perfect number : {IsPerfectNumber_Sqrt(num)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(28); // Output: true
        Print(7);  // Output: false
    }

    #endregion
}
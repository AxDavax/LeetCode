/*
    202. Happy Number    

    Write an algorithm to determine if a number n is happy.

    A happy number is a number defined by the following process:

    Starting with any positive integer, replace the number by the sum of the squares of its digits.
    Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a 
    cycle which does not include 1.
    Those numbers for which this process ends in 1 are happy.
    Return true if n is a happy number, and false if not.


    Example 1:

    Input: n = 19
    Output: true
    Explanation:
    Math.Pow(1, 2) + Math.Pow(9, 2) = 82
    Math.Pow(8, 2) + Math.Pow(2, 2) = 68
    Math.Pow(6, 2) + Math.Pow(8, 2) = 100
    Math.Pow(1, 2) + Math.Pow(0, 2) + Math.Pow(0, 2) = 1
    Example 2:

    Input: n = 2
    Output: false

    Constraints:

    1 <= n <= Math.Pow(2, 31) - 1
*/

using System.Net.NetworkInformation;

namespace LeetCode.CSharp.Problems.Easy;

public static class P0202_Happy_Number
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(log(n))
    /// Spatial Complexity : O(1)
    /// </summary>

    public static bool IsHappy_Floyd(int n)
    {
        int slow = n;
        int fast = n;

        do
        {
            slow = SumSquares(slow);
            fast = SumSquares(SumSquares(fast));
        }
        while (slow != fast);

        return slow == 1;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(log(n))
    /// Spatial Complexity : O(log(n))
    /// </summary>
    public static bool IsHappy_HashSet(int n, out int x)
    {
        var seen = new HashSet<int>();

        while (!seen.Contains(n))
        {
            seen.Add(n);
            n = SumSquares(n);

            if (n == 1)
            {
                x = 1;
                return true;
            }
        }

        x = n;
        return false;
    }

    #endregion

    #region Method

    private static int SumSquares(int n)
    {
        int sum = 0;

        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }

        return sum;
    }

    #endregion

    #region Helper

    private static void Print(int n)
    {
        int endingCycleNumber;
        if (IsHappy_HashSet(n, out endingCycleNumber))
            Console.WriteLine($"{n} is a Happy Number ! \n");
        else
            Console.WriteLine($"{n} it ends up with {endingCycleNumber} as an ending cycle and so is not a Happy Number ! \n");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(19);
        Print(2);
    }

    #endregion
}
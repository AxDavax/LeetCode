/*
    70. Climbing Stairs
    
    You are climbing a staircase. It takes n steps to reach the top.
    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

 
    Example 1:

        Input: n = 2
        Output: 2
        Explanation: There are two ways to climb to the top.
                     1. 1 step + 1 step
                     2. 2 steps

    Example 2:

        Input: n = 3
        Output: 3
        Explanation: There are three ways to climb to the top.
                     1. 1 step + 1 step + 1 step
                     2. 1 step + 2 steps
                     3. 2 steps + 1 step

 
    Constraints:     1 <= n <= 45
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0070_Climbing_Stairs
{
    #region Solution

    /// <summary>
    /// Time Complexity : O(n)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int ClimbStairs(int n)
    {
        if (n <= 2) return n;

        int a = 1, b = 2;

        for (int i = 3; i <= n; i++)
        {
            int sum = a + b;
            a = b;
            b = sum;
        }

        return b;
    }

    #endregion


    #region Test

    public static void Test()
    {
        var testCases = new[]
        {
            new { N = 2, Expected = 2 },
            new { N = 3, Expected = 3 },
            new { N = 4, Expected = 5 },
            new { N = 5, Expected = 8 },
            new { N = 6, Expected = 13 },
            new { N = 7, Expected = 21 },
            new { N = 8, Expected = 34 },
            new { N = 9, Expected = 55 },
            new { N = 10, Expected = 89 },
        };

        foreach (var testCase in testCases)
        {
            var result = ClimbStairs(testCase.N);
            Console.WriteLine($"Input: n = {testCase.N}, " +
                              $"Output: {result}, " +
                              $"Expected: {testCase.Expected}");
        }
    }

    #endregion
}
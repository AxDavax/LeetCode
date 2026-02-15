/*
    1523. Count Odd Numbers in an Interval Range

    Given two non-negative integers low and high. 
    Return the count of odd numbers between low and high (inclusive).

    Example 1:

        Input: low = 3, high = 7
        Output: 3
        Explanation: The odd numbers between 3 and 7 are [3,5,7].
    
    Example 2:

        Input: low = 8, high = 10
        Output: 1
        Explanation: The odd numbers between 8 and 10 are [9].

    Constraints:

        0 <= low <= high <= 10^9
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1523_Count_Odd_Numbers_in_an_Interval_Range
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int CountOdds_O1(int low, int high) => (high + 1) / 2 - low / 2;

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(n) 
    /// Spatial Complexity : O(1)
    /// </summary>

    static public int CountOdds_On(int low, int high)
    {
        low = (low % 2 == 0) ? low + 1 : low;
        high = (high % 2 == 0) ? high - 1 : high;

        int count = 0;

        for (int i = low; i <= high; i += 2)
            count++;

        return count;
    }

    #endregion

    #region Test

    public static void Test()
    {
        Console.WriteLine(CountOdds_O1(3, 7)); // Expected: 3
        Console.WriteLine(CountOdds_O1(8, 10)); // Expected: 1
    }

    #endregion
}
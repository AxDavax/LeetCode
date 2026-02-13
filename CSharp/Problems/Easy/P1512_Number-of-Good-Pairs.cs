/*
    
    1512. Number of Good Pairs

    Given an array of integers nums, return the number of good pairs.

    A pair (i, j) is called good if nums[i] == nums[j] and i < j.

 
    Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.

    Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.

    Example 3:

        Input: nums = [1,2,3]
        Output: 0
 

    Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1512_Number_of_Good_Pairs
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(N) 
    /// Spatial Complexity : O(1)
    /// </summary>

    public static int NumIdenticalPairs_freq(int[] nums)
    {
        var freq = new int[101];
        int count = 0;
        
        foreach (var num in nums)
            count += freq[num]++;
        
        return count;
    }

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Complexité temporelle : O(N) 
    /// Complexité spatialle : O(N)
    /// </summary>
    public static int NumIdenticalPairs_dict(int[] nums)
    {
        int count = 0;
        var dictCount = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (dictCount.ContainsKey(num))
            {
                count += dictCount[num];
                dictCount[num]++;
            }
            else
                dictCount.Add(num, 1);
        }

        return count;
    }

    /// <summary>
    /// Complexité temporelle : O(N^2) 
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int NumIdenticalPairs_nestedLoops(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length - 1; i++)
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] == nums[j]) count++;
        
        return count;
    }

    #endregion

    #region Helper

    static string ShowArray(int[] nums) => "[" + string.Join(", ", nums) + "]";

    #endregion

    #region Test

    public static void Test()
    {
        var testCases = new[]
        {
            new { Nums = new[] { 1, 2, 3, 1, 1, 3 }, Expected = 4 },
            new { Nums = new[] { 1, 1, 1, 1 }, Expected = 6 },
            new { Nums = new[] { 1, 2, 3 }, Expected = 0 },
        };

        foreach (var testCase in testCases)
        {
            var result = NumIdenticalPairs_freq(testCase.Nums);
            Console.WriteLine($"Input: nums = {ShowArray(testCase.Nums)}, " +
                              $"Output: {result}, " +
                              $"Expected: {testCase.Expected}");
        }
    }

    #endregion
}
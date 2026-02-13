/*
    1. Two Sum

    Given an array of integers nums and an integer target, return indices of the two numbers 
    such that they add up to target.

    You may assume that each input would have exactly one solution, and you may not use 
    the same element twice.

    You can return the answer in any order.


    Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

    Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]

    Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
 

    Constraints:

        2 <= nums.length <= 10^4
        -10^9 <= nums[i] <= 10^9
        -10^9 <= target <= 10^9
        Only one valid answer exists.
 

    Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0001_Two_Sum
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(n)
    /// Spatial Complexity : O(n)
    /// </summary>
    public static (int x, int y)? TwoSum_dict(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        int complement;

        for (int i = 0; i < nums.Length; i++)
        {
            complement = target - nums[i];
            if (dict.TryGetValue(complement, out int index))
                return (index, i);

            dict[nums[i]] = i;
        }

        return null;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(n^2)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static (int x, int y)? TwoSum_nestedLoops(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return (i, j);
            }
        }

        return null;
    }

    #endregion

    #region Helper

    static void Print(int[] nums, int target)
    {
        var result = TwoSum_dict(nums, target);

        if (result is null)
            Console.WriteLine("Target not hit, no couple of numbers match target !");
        else
            Console.WriteLine($"Indices found : [{result?.x}, {result?.y}]");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(new[] { 2, 7, 11, 15 }, 9); // Output: [0,1]
        Print(new[] { 3, 2, 4 }, 6); // Output: [1,2]
        Print(new[] { 3, 3 }, 6); // Output: [0,1]
    }

    #endregion
}
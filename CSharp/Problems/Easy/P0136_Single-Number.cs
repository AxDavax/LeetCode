/*
    136. Single Number

    Given a non-empty array of integers nums, every element appears twice except for one. 
    Find that single one.

    You must implement a solution with a linear runtime complexity and use only constant extra space.


    Example 1:

        Input: nums = [2, 2, 1]

        Output: 1

    Example 2:

        Input: nums = [4, 1, 2, 1, 2]

        Output: 4

    Example 3:

        Input: nums = [1]

        Output: 1


    Constraints:

    1 <= nums.length <= 3 * 104
    - 3 * 104 <= nums[i] <= 3 * 104
    Each element in the array appears twice except for one element which appears only once.

*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0136_Single_Number
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(1)
    /// L'opérateur XOR (^) est utilisé pour trouver le nombre unique dans le tableau.
    /// n XOR n = 0 pour tout nombre n, et n XOR 0 = n. 
    /// </summary>
    public static int SingleNumber_Bits(int[] nums)
    {
        int single = 0;

        // Ainsi, en XORant tous les éléments du tableau
        foreach (int num in nums)
            single ^= num;

        return single;
    }

    #endregion

    #region Alternatives Solutions

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int SingleNumber_HashSet(int[] nums)
    {
        var hash = new HashSet<int>();

        foreach (var num in nums)
            if (!hash.Add(num))
                hash.Remove(num);

        return hash.First();
    }

    /// <summary>
    /// Complexité temporelle : O(n^2)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int SingleNumber_List(int[] nums)
    {
        List<int> list = nums.ToList();

        for (int i = 0; i < nums.Length; i++)
        {
            if (list.Contains(nums[i]))
                list.Remove(nums[i]);
            else
                list.Add(nums[i]);
        }

        return list.FirstOrDefault();
    }

    #endregion

    #region Test 

    public static void Test()
    {
        int[] nums = { 4, 1, 2, 1, 2 };

        string showArray = "{" + string.Join(",", nums) + "}";

        Console.WriteLine($"In the array nums = {showArray}, " +
                          $"the unique number is : {SingleNumber_Bits(nums)}");
    }

    #endregion
}
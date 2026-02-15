/*    
    217. Contains Duplicate
    
    Given an integer array nums, return true if any value appears at least twice in the array, 
    and return false if every element is distinct.


    Example 1:

        Input: nums = [1, 2, 3, 1]

        Output: true

    Explanation:

        The element 1 occurs at the indices 0 and 3.

    
    Example 2:

        Input: nums = [1, 2, 3, 4]

        Output: false

    Explanation:

        All elements are distinct.


    Example 3:

        Input: nums = [1, 1, 1, 3, 3, 4, 3, 2, 4, 2]

        Output: true



    Constraints:

        1 <= nums.length <= 105
        - 109 <= nums[i] <= 109
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0217_Contains_Duplicate
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(n) 
    /// Spatial Complexity : O(n)
    /// </summary>
    public static bool ContainsDuplicate_set(int[] nums)
    {
        var set = new HashSet<int>();
        
        foreach (var num in nums)
        {
            if (!set.Add(num))
                return true;
        }
        
        return false;
    }

    #endregion

    #region Alternatives Solution

    /// <summary>
    /// Time Complexity : O(n) 
    /// Spatial Complexity : O(n)
    /// </summary>
    public static bool ContainsDuplicate_Linq(int[] nums) => nums.Length != nums.Distinct().Count();


    /// <summary>
    /// Time Complexity : O(nlog(n)) 
    /// Spatial Complexity : O(1)
    /// </summary>

    public static bool ContainsDuplicate_sort(int[] nums)
    {
        Array.Sort(nums);
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
                return true;
        }
        
        return false;
    }

    #endregion

    #region Test

    public static void Test()
    {
        var testCases = new[]
        {
            new { Nums = new[] { 1, 2, 3, 1 }, Expected = true },
            new { Nums = new[] { 1, 2, 3, 4 }, Expected = false },
            new { Nums = new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, Expected = true },
        };

        foreach (var testCase in testCases)
        {
            var result = ContainsDuplicate_set(testCase.Nums);
            Console.WriteLine(result == testCase.Expected
                ? "Test passed."
                : $"Test failed. Expected: {testCase.Expected}, Got: {result}");
        }
    }

    #endregion
}
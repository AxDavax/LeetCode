/*
    35. Search Insert Position

    Given a sorted array of distinct integers and a target value, return the index 
    if the target is found. If not, return the index where it would be if it were inserted in order.

    You must write an algorithm with O(log n) runtime complexity.

 
    Example 1:

        Input: nums = [1, 3, 5, 6], target = 5
        Output: 2

    Example 2:

        Input: nums = [1, 3, 5, 6], target = 2
        Output: 1

    Example 3:

        Input: nums = [1, 3, 5, 6], target = 7
        Output: 4


    Constraints:

        1 <= nums.length <= 10^4
        - 10^4 <= nums[i] <= 10^4
        nums contains distinct values sorted in ascending order.
        -10^4 <= target <= 10^4

 */

namespace LeetCode.CSharp.Problems.Easy;

public static class P0035_Search_Insert_Position
{
    #region Solution

    /// <summary>
    /// Time Complexity : O(log(n))
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;
            
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }

    #endregion

    #region Helpers

    static string ShowArray(int[] nums) => "[" + string.Join(", ", nums) + "]";

    public static void Print(int target, int[] numbers)
    {
        Console.WriteLine($"Find the target {target} in the array {ShowArray(numbers)}, the position is : {SearchInsert(numbers, target)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        int[] numbers = { 1, 3, 5, 6 };
        Print(5, numbers);  // 2
        Print(2, numbers);  // 1
        Print(7, numbers);  // 4
    }

    #endregion
}
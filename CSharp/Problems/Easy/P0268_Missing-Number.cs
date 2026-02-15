/*    
    268. Missing Number
    
    Given an array nums containing n distinct numbers in the range [0, n], 
        return the only number in the range that is missing from the array.

    Example 1:

        Input: nums = [3,0,1]

        Output: 2

        Explanation:

            n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 
            2 is the missing number in the range since it does not appear in nums.

    Example 2:

        Input: nums = [0,1]

        Output: 2

        Explanation:

            n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 
            2 is the missing number in the range since it does not appear in nums.

    Example 3:

        Input: nums = [9,6,4,2,3,5,7,0,1]

        Output: 8

        Explanation:

            n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 
            8 is the missing number in the range since it does not appear in nums.
    
    Constraints:

        n == nums.length
        1 <= n <= 104
        0 <= nums[i] <= n
        All the numbers of nums are unique.
 

    Follow up: Could you implement a solution using only O(1) extra space complexity 
                                                         and O(n) runtime complexity?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0268_Missing_Number
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(n)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int MissingNumber_Iterative(int[] nums)
    {
        int n = nums.Length;
        int sum = (n * (n + 1)) / 2;

        for (int i = 0; i < n; i++)
            sum -= nums[i];

        return sum;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int MissingNumber_HashSet(int[] nums)
    {
        int n = nums.Length;
        var set = new HashSet<int>(nums);

        for(int i = 0; i <= n; i++)
            if (!set.Contains(i)) 
                return i;

        return -1;
    }

    #endregion

    #region Test

    public static void Test()
    {
        var nums1 = new[] { 3, 0, 1 };
        var nums2 = new[] { 0, 1 };
        var nums3 = new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

        Console.WriteLine(MissingNumber_Iterative(nums1)); // Output: 2
        Console.WriteLine(MissingNumber_Iterative(nums2)); // Output: 2
        Console.WriteLine(MissingNumber_Iterative(nums3)); // Output: 8
    }

    #endregion
}
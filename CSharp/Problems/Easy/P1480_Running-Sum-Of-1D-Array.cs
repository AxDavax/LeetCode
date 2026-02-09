/*
    1480. Running Sum of 1d Array    

    Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).

    Return the running sum of nums.

 
    Example 1:

        Input: nums = [1,2,3,4]
        Output: [1,3,6,10]
        Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].

    Example 2:

        Input: nums = [1,1,1,1,1]
        Output: [1,2,3,4,5]
        Explanation: Running sum is obtained as follows: [1, 1+1, 1+1+1, 1+1+1+1, 1+1+1+1+1].

    Example 3:

        Input: nums = [3,1,2,10,1]
        Output: [3,4,6,16,17]
 

    Constraints:

        1 <= nums.length <= 1000
        -10^6 <= nums[i] <= 10^6
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1480_Running_Sum_Of_1D_Array
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int[] RunningSum_O1(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
            nums[i] += nums[i - 1];

        return nums;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(n)
    /// </summary>
    public static int[] RunningSum_On(int[] nums)
    {
        int[] res = new int[nums.Length];
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            res[i] = sum + nums[i];
            sum += nums[i];
        }

        return res;
    }

    #endregion

    static string ShowArray(int[] nums) => "[" + string.Join(", ", nums) + "]";

    #region Test

    public static void Test()
    {
        int[] nums = { 1, 2, 3, 4 };

        Console.WriteLine($"The array nums = {ShowArray(nums)}, " +
                          $"and his running Sum array : {ShowArray(RunningSum_O1(nums))}");
        Console.Read();
    }

    #endregion
}
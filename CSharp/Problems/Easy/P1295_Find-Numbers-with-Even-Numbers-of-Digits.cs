/*
    1295. Find Numbers with Even Numbers of Digits

    Given an array nums of integers, return how many of them contain an even number of digits.

    Example 1:

        Input: nums = [12, 345, 2, 6, 7896]
        Output: 2
        Explanation:
            12 contains 2 digits (even number of digits). 
            345 contains 3 digits (odd number of digits). 
            2 contains 1 digit (odd number of digits). 
            6 contains 1 digit (odd number of digits). 
            7896 contains 4 digits (even number of digits). 
            Therefore only 12 and 7896 contain an even number of digits.

    Example 2:

        Input: nums = [555, 901, 482, 1771]
        Output: 1
        Explanation:
            Only 1771 contains an even number of digits.
 

    Constraints:

        1 <= nums.length <= 500
        1 <= nums[i] <= 10^5
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P1295_Find_Numbers_with_Even_Numbers_of_Digits
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(N)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int FindNumbers_boundaries(int[] nums)
    {
        int count = 0;

        foreach (int num in nums)
            if ((num >= 10 && num <= 99) || 
                (num >= 1000 && num <= 9999) || 
                (num >= 100000 && num <= 999999)) 
                count++; 

        return count;
    }

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Time Complexity : O(N)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int FindNumbers_log(int[] nums)
    {
        int count = 0; 
        
        foreach (int num in nums) 
        { 
            int digits = (int)Math.Floor(Math.Log10(num)) + 1; 
            
            if (digits % 2 == 0) 
                count++; 
        }
        
        return count;
    }

    /// <summary>
    /// Time Complexity : O(N*D)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int FindNumbers_iterative(int[] nums)
    {
        int count = 0; 
        
        foreach (int num in nums) 
        { 
            int x = num; 
            int digits = 0; 
            
            while (x > 0) 
            { 
                x /= 10; 
                digits++; 
            } 
            
            if (digits % 2 == 0) count++; 
        }
        
        return count;
    }

    /// <summary>
    /// Time Complexity : O(N*D)
    /// Spatial Complexity : O(N*D) or O(D)
    /// </summary>
    public static int FindNumbers_String(int[] nums)
    {
        int count = 0;
        foreach (var num in nums)
            if (num.ToString().Length % 2 == 0)
                count++;

        return count;
    }

    #endregion

    #region Helpers

    static string ShowArray(int[] nums) => "[" + string.Join(", ", nums) + "]";

    static void Print(int[] nums, Func<int[], int> method)
    {
        Console.WriteLine($"The array nums = {ShowArray(nums)}, and the number of numbers" +
                             $" containing even digits {method(nums)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(new int[] { 12, 345, 2, 6, 7896 }, FindNumbers_boundaries);
        Print(new int[] { 555, 901, 482, 1771 }, FindNumbers_boundaries);
    }

    #endregion
}
/*
   9. Palindrome Number

    Given an integer x, return true if x is a palindrome, and false otherwise.

    Example 1:

    Input: x = 121
    Output: true
    Explanation: 121 reads as 121 from left to right and from right to left.

    Example 2:

    Input: x = -121
    Output: false
    Explanation: From left to right, it reads -121. From right to left, it becomes 121-. 
                 Therefore it is not a palindrome.

    Example 3:

    Input: x = 10
    Output: false
    Explanation: Reads 01 from right to left.Therefore it is not a palindrome.
    
    
    Constraints: Math.Pow(-2,31) <= x <= Math.Pow(2,31) - 1       

    Follow up: Could you solve it without converting the integer to a string?
 */

namespace LeetCode.CSharp.Problems.Easy;

public static class P0009_Palindrome_Number
{
    #region Optimal Solution
    
    /// <summary>
    /// Time Complexity : O(log10(n)/2)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPalindrome_Half(int n)
    {
        if (n < 0 || (n % 10 == 0 && n != 0))
            return false;

        int revertedNumber = 0;
        
        while (n > revertedNumber)
        {
            revertedNumber = revertedNumber * 10 + n % 10;
            n /= 10;
        }
        
        return n == revertedNumber || n == revertedNumber / 10;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(log10(n))
    /// Spatial Complexity : O(1)
    /// </summary>
    public static bool IsPalindrome_Full(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        int rev = 0;
        int n = x;

        while (n > 0)
        {
            rev = rev * 10 + n % 10;
            n /= 10;
        }

        return (rev == x);
    }

    #endregion

    #region Helper

    static void Print(int number, Func<int, bool> palindromeMethod)
    {
        Console.WriteLine($"Is {number} a palindrome? : {palindromeMethod(number)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        // Test cases from the problem statement

        // Using the half method
        Print(121, IsPalindrome_Half);
        Print(-121, IsPalindrome_Half);
        Print(10, IsPalindrome_Half);

        // Using the full method
        Print(121, IsPalindrome_Full);
        Print(-121, IsPalindrome_Full);
        Print(10, IsPalindrome_Full);
    }

    #endregion
}
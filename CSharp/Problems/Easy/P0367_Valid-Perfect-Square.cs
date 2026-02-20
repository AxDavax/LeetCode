/*
    367. Valid Perfect Square
 
    Given a positive integer num, return true if num is a perfect square or false otherwise.

    A perfect square is an integer that is the square of an integer. 
    In other words, it is the product of some integer with itself.

    You must not use any built-in library function, such as sqrt.

 
    Example 1:

        Input: num = 16
        Output: true
        Explanation: We return true because 4 * 4 = 16 and 4 is an integer.

    Example 2:

        Input: num = 14
        Output: false
        Explanation: We return false because 3.742 * 3.742 = 14 and 3.742 is not an integer.
 

    Constraints:
        1 <= num <= 2^31 - 1
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0367_Valid_Perfect_Square
{
    #region Optimal Solution

    /// <summary>
    /// Time complexity : O(1)
    /// Spatial complexity : O(1)
    /// </summary>
    public static bool IsPerfectSquareO1(int num)
    {
        int root = (int)Math.Sqrt(num);
        return root * root == num;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time complexity : O(1)
    /// Spatial complexity : O(1)
    /// </summary>
    public static bool IsPerfectSquare(int num) => double.IsInteger(Math.Sqrt(num));

    #endregion

    #region Test
    
    public static void Test()
    {
        int numb = 80;
        Console.WriteLine($"Is {numb} a valid perfect square : {IsPerfectSquareO1(numb)}");
        Console.Read();
    }

    #endregion
}
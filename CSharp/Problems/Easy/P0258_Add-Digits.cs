/*
    258. Add Digits    

    Given an integer num, repeatedly add all its digits until the result has only one digit, 
    and return it.

 
    Example 1:

        Input: num = 38
        Output: 2
        Explanation: The process is
                     38-- > 3 + 8-- > 11
                     11-- > 1 + 1-- > 2
                     Since 2 has only one digit, return it.

    Example 2:

        Input: num = 0
        Output: 0


    Constraints:

        0 <= num <= 2^31 - 1


    Follow up: Could you do it without any loop/recursion in O(1) runtime?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0258_Add_Digits
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int AddDigits_Math(int num)
    {
        if (num == 0) return 0;

        return 1 + (num - 1) % 9;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(log(n))
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int AddDigits_Iterative(int num)
    {
        int n = num;
        int sum = 0;

        do
        {
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            n = sum;
            sum = 0;

        } while (n > 10);

        return n;
    }

    #endregion

    #region Test
    
    public static void Test()
    {
        int numb = 38;
        Console.WriteLine($"Adding digits of {numb} until one digit : {AddDigits_Math(numb)} remains !");
        Console.Read();
    }

    #endregion
}
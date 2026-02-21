/*
    191. Number of 1 Bits
 
    Given a positive integer n, write a function that returns the number of set bits 
    in its binary representation (also known as the Hamming weight).


    Example 1:

        Input: n = 11
        Output: 3
        Explanation:
            The input binary string 1011 has a total of three set bits.

    Example 2:

        Input: n = 128
        Output: 1
        Explanation:
        The input binary string 10000000 has a total of one set bit.

    Example 3:

        Input: n = 2147483645
        Output: 30
        Explanation:
            The input binary string 1111111111111111111111111111101 has a total of thirty set bits.

 
    Constraints:
        1 <= n <= 2^31 - 1


    Follow up: If this function is called many times, how would you optimize it?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0191_Number_of_1_Bits
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(k)
    /// Spatial Complexity : O(1)
    /// k is the number of set bits in the binary representation of n
    /// </summary>
    public static int HammingWeight_Bitwise(int n)
    {
        int res = 0;

        while (n > 0)
        {
            res++;
            n &= (n - 1);
        }
        
        return res;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(log(n))
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int HammingWeight_Iterative(int n)
    {
        int nb1 = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
                nb1++;

            n /= 2;
        }

        return nb1;
    }

    #endregion

    #region Helper

    public static void Print(int n, Func<int, int> method)
    {
        Console.WriteLine($"The number of ones in the binary representation of {n} is {method(n)}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(11, HammingWeight_Bitwise);           // output: 3
        Print(128, HammingWeight_Bitwise);          // output: 1
        Print(2147483645, HammingWeight_Bitwise);   // output: 30
    }

    #endregion
}
/*
    190. Reverse Bits 

    Reverse bits of a given 32 bits signed integer.

 
    Example 1:

        Input: n = 43261596
        Output: 964176192
        Explanation:    Integer     Binary
                       43261596     00000010100101000001111010011100
                      964176192     00111001011110000010100101000000

    Example 2:
        Input: n = 2147483644
        Output: 1073741822
        Explanation:    Integer     Binary
                     2147483644     01111111111111111111111111111100
                     1073741822     00111111111111111111111111111110

    Constraints:

        0 <= n <= 2^31 - 2
        n is even.


    Follow up: If this function is called many times, how would you optimize it?
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0190_Reverse_Bits
{
    #region Optimal Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int ReverseBits_Bitwise(int n)
    {
        int res = 0;

        // Nous traitons exactement 32 bits
        for (int i = 0; i < 32; i++)
        {
            res <<= 1;         // Décale le résultat pour faire de la place
            res |= (n & 1);    // Ajoute le bit de poids faible de n à res
            n >>= 1;           // Passe au bit suivant 
        }

        return res;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Complexité temporelle : O(1)
    /// Complexité spatialle : O(1)
    /// </summary>
    public static int ReverseBits_Pow(int n)
    {
        int sum = 0, i = 31;

        while (n > 0)
        {
            if (n % 2 == 1) sum += (int)Math.Pow(2, i);

            n /= 2;
            i--;
        }

        return sum;
    }

    #endregion

    #region Test

    public static void Test()
    {
        int n = 600;
        Console.WriteLine($"The reversed of {n} is : {ReverseBits_Bitwise(n)} !");
        Console.Read();
    }

    #endregion
}
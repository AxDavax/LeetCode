/*
    728. Self Dividing Numbers

    A self-dividing number is a number that is divisible by every digit it contains.

    For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, 
    and 128 % 8 == 0.
    A self-dividing number is not allowed to contain the digit zero.

    Given two integers left and right, return a list of all the self-dividing numbers 
    in the range [left, right] (both inclusive).

 
    Example 1:

        Input: left = 1, right = 22
        Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
    
    Example 2:

        Input: left = 47, right = 85
        Output: [48, 55, 66, 77]


    Constraints:
        1 <= left <= right <= 10^4
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0728_Self_Dividing_Numbers
{
    #region Solution

    /// <summary>
    /// Complexité temporelle : O(n * d) 
    /// Complexité spatialle : O(n)
    /// où n est la taille de l'intervalle [left, right] 
    /// d est le nombre de chiffres dans le nombre le plus grand de l'intervalle
    /// </summary>
    public static IList<int> SelfDividingNumbers(int left, int right)
    {
        var result = new List<int>();
        
        for (int i = left; i <= right; i++)
        {
            if (IsSelfDividing(i))
                result.Add(i);
        }

        return result;
    }

    private static bool IsSelfDividing(int n)
    {
        int num = n;

        while (num > 0)
        {
            int digit = num % 10;
            
            if (digit == 0 || n % digit != 0)
                return false;
            
            num /= 10; 
        }

        return true;
    }

    #endregion

    #region Helpers

    static string ShowList(IList<int> nums) => "[" + string.Join(", ", nums) + "]";

    public static void Print(int left, int right)
    {
        Console.WriteLine($"From {left} to {right} this is the list of self-dividing" +
                $"numbers \n list : {ShowList(SelfDividingNumbers(left, right))}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(1, 22); // [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
        Print(47, 85); // [48, 55, 66, 77]
    }

    #endregion
}
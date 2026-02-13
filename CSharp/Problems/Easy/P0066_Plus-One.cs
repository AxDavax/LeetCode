/*
    66. Plus One

    You are given a large integer represented as an integer array digits, 
    where each digits[i] is the i^th digit of the integer. 
    The digits are ordered from most significant to least significant in left-to-right order. 
    The large integer does not contain any leading 0's.

    Increment the large integer by one and return the resulting array of digits.

 
    Example 1:

        Input: digits = [1,2,3]
        Output: [1,2,4]
        Explanation: The array represents the integer 123.
                     Incrementing by one gives 123 + 1 = 124.
                     Thus, the result should be [1,2,4].

    Example 2:

        Input: digits = [4,3,2,1]
        Output: [4,3,2,2]
        Explanation: The array represents the integer 4321.
                     Incrementing by one gives 4321 + 1 = 4322.
                      Thus, the result should be [4,3,2,2].

    Example 3:

        Input: digits = [9]
        Output: [1,0]
        Explanation: The array represents the integer 9.
                     Incrementing by one gives 9 + 1 = 10.
                     Thus, the result should be [1,0].
 

    Constraints:

        1 <= digits.length <= 100
        0 <= digits[i] <= 9
        digits does not contain any leading 0's.
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0066_Plus_One
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : in worst cases O(n) , O(1) otherwise
    /// Spatial Complexity : in worst cases O(n), O(1) otherwise
    /// </summary>
    public static int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }

        int[] newDigits = new int[digits.Length + 1];
        newDigits[0] = 1;
        return newDigits;
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : in worst cases O(n) , O(1) otherwise
    /// Spatial Complexity : in worst cases O(n), O(1) when no carry is needed
    /// </summary>
    public static int[] PlusOneLL(int[] digits)
    {
        int i = digits.Length - 1;
        int lstDigit = digits[i];

        if (lstDigit == 9)
        {
            LinkedList<int> res = new LinkedList<int>();
            int ret = 1;

            while (i-- >= 0)
            {
                if (digits[i] + ret > 9)
                {
                    res.AddFirst(0);
                    ret = 1;
                }
                else
                {
                    res.AddFirst(digits[i] + ret);
                    ret = 0;
                }
            }

            if (ret > 0) res.AddFirst(1);

            return res.ToArray();
        }
        else
        {
            digits[i] = lstDigit + 1;
            return digits;
        }
    }

    #endregion

    #region Test

    public static void Test()
    {
        var testCases = new[]
        {
            new { Digits = new[] { 1, 2, 3 }, Expected = new[] { 1, 2, 4 } },
            new { Digits = new[] { 4, 3, 2, 1 }, Expected = new[] { 4, 3, 2, 2 } },
            new { Digits = new[] { 9 }, Expected = new[] { 1, 0 } },
            new { Digits = new[] { 9, 9 }, Expected = new[] { 1, 0, 0 } },
            new { Digits = new[] { 8, 9 }, Expected = new[] { 9, 0 } },
        };
       
        foreach (var testCase in testCases)
        {
            var result = PlusOne(testCase.Digits);
            Console.WriteLine($"Input: [{string.Join(", ", testCase.Digits)}], " +
                              $"Output: [{string.Join(", ", result)}], " +
                              $"Expected: [{string.Join(", ", testCase.Expected)}]");
        }
    }

    #endregion
}
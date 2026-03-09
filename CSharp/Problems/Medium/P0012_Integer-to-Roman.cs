/*
    12. Integer to Roman

    Seven different symbols represent Roman numerals with the following values:

    Symbol	Value
    I	1
    V	5
    X	10
    L	50
    C	100
    D	500
    M	1000
    Roman numerals are formed by appending the conversions of decimal place values from highest to lowest. Converting a decimal place value into a Roman numeral has the following rules:

    If the value does not start with 4 or 9, select the symbol of the maximal value that can be subtracted from the input, append that symbol to the result, subtract its value, and convert the remainder to a Roman numeral.
    If the value starts with 4 or 9 use the subtractive form representing one symbol subtracted from the following symbol, for example, 4 is 1 (I) less than 5 (V): IV and 9 is 1 (I) less than 10 (X): IX. Only the following subtractive forms are used: 4 (IV), 9 (IX), 40 (XL), 90 (XC), 400 (CD) and 900 (CM).
    Only powers of 10 (I, X, C, M) can be appended consecutively at most 3 times to represent multiples of 10. You cannot append 5 (V), 50 (L), or 500 (D) multiple times. If you need to append a symbol 4 times use the subtractive form.
    Given an integer, convert it to a Roman numeral.


    Example 1:

        Input: num = 3749
        Output: "MMMDCCXLIX"
    
        Explanation:

            3000 = MMM as 1000 (M) + 1000 (M) + 1000 (M)
             700 = DCC as 500 (D) + 100 (C) + 100 (C)
              40 = XL as 10 (X) less of 50 (L)
               9 = IX as 1 (I) less of 10 (X)
            Note: 49 is not 1 (I) less of 50 (L) because the conversion is based on decimal places
    
    Example 2:

        Input: num = 58
        Output: "LVIII"

        Explanation:

            50 = L
             8 = VIII
    
    Example 3:

        Input: num = 1994
        Output: "MCMXCIV"

        Explanation:

            1000 = M
             900 = CM
              90 = XC
               4 = IV
 
    Constraints:
        
        1 <= num <= 3999
 
*/

using System;

namespace LeetCode.CSharp.Problems.Medium;

public static class P0012_Integer_to_Roman
{
    #region Optimal Solution

    private static readonly int[] Values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private static readonly string[] Symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>
    public static string IntToRoman_Iterative(int num)
    {
        Span<char> res = stackalloc char[15];
        int pos = 0;

        for (int i = 0; i < Values.Length; i++) 
        {
            while (num >= Values[i]) 
            {
                string s = Symbols[i];

                for(int j = 0; j < s.Length; j++) 
                    res[pos++] = s[j];

                num -= Values[i];
            }
        }

        return new string(res[..pos]);
    }

    #endregion

    #region Alternative Solution

    /// <summary>
    /// Time Complexity : O(1) 
    /// Spatial Complexity : O(1)
    /// </summary>

    public static string IntToRoman_Dict(int num)
    {
        var dict = new Dictionary<int, char>
        {
            { 1, 'I' }, { 5, 'V' },
            { 10, 'X' }, { 50, 'L' },
            { 100, 'C' }, { 500, 'D' },
            { 1000, 'M' }
        };

        int temp = num, mult = 1;
        Span<char> res = stackalloc char[20];
        int index = 19;

        var keys = dict.Keys.OrderBy(k => k).ToArray();

        while (temp > 0) 
        {
            int digit = temp % 10;
            int value = digit * mult;

            if(digit != 0)
            {
                if (digit == 4)
                {
                    res[index--] = dict[mult * 5];
                    res[index--] = dict[mult];
                }
                else if (digit == 9)
                {
                    res[index--] = dict[mult * 10];
                    res[index--] = dict[mult];
                }
                else
                {
                    int remaining = value;
                    while (remaining > 0)
                    {
                        int key = 1;

                        for(int i = keys.Length -1; i >= 0; i--)
                        {
                            if (keys[i] <= remaining)
                            {
                                key = keys[i]; 
                                break;
                            }
                        }

                        res[index--] = dict[key];
                        remaining -= key;
                    }
                }
            }

            temp /= 10;
            mult *= 10; 
        }

        return new string(res[(index + 1)..]);
    }

    #endregion

    #region Helper

    static void Print(int n, Func<int, string> method)
    {
        Console.WriteLine($"{n} in roman letters : {method(n)}");
        Console.ReadLine();
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(3749, IntToRoman_Iterative);
        Print(58, IntToRoman_Iterative);
        Print(1994, IntToRoman_Iterative);

        Console.ReadLine();

        Print(3749, IntToRoman_Dict);
        Print(58, IntToRoman_Dict);
        Print(1994, IntToRoman_Dict);

        Console.ReadLine();
        Print(3888, IntToRoman_Iterative);
        Print(3999, IntToRoman_Iterative);
    }

    #endregion
}
/*
    67. Add Binary    

    Given two binary strings a and b, return their sum as a binary string. 

    Example 1:

        Input: a = "11", b = "1"
        Output: "100"
    
    Example 2:

        Input: a = "1010", b = "1011"
        Output: "10101"


    Constraints:

        1 <= a.length, b.length <= 104
        a and b consist only of '0' or '1' characters.
        Each string does not contain leading zeros except for the zero itself.
*/

using System.Text;

namespace LeetCode.CSharp.Problems.Easy;

public static class P0067_Add_Binary
{
    /// <summary>
    /// Complexité temporelle : O(max(m,n))
    /// Complexité spatialle : O(max(m,n))
    /// </summary>
    public static string AddBinaryBit(string a, string b)
    {
        StringBuilder res = new StringBuilder();
        int i = a.Length - 1, j = b.Length - 1, ret = 0, sum = 0;

        while (i >= 0 || j >= 0 || ret > 0)
        {
            sum = ret;

            if (i >= 0) 
                sum += a[i--] - '0';

            if (j >= 0) 
                sum += b[j--] - '0';

            res.Insert(0, sum % 2);
            ret = sum / 2;
        }

        return res.ToString();
    }

    /// <summary>
    /// Complexité temporelle : O(max(m,n))
    /// Complexité spatialle : O(max(m,n))
    /// </summary>
    public static string AddBinaryOptimized(string a, string b)
    {
        StringBuilder res = new StringBuilder();
        int i = a.Length - 1, j = b.Length - 1, ret = 0, sum = 0;

        while (i >= 0 || j >= 0 || ret > 0)
        {
            sum = ret;

            if (i >= 0) sum += a[i--] - '0';

            if (j >= 0) sum += b[j++] - '0';

            // Ajouter le bit à la fin
            res.Append(sum % 2);
            ret = sum / 2;
        }

        // Inverser la chaîne une seule fois à la fin
        char[] charArray = res.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static void Test()
    {
        string a = "1010", b = "1011";
        Console.WriteLine($"{a} + {b} = {AddBinaryBit(a, b)} in bits"); 
        Console.Read();
    }
}
/*
    412. Fizz Buzz
    
    Given an integer n, return a string array answer (1-indexed) where:

        answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
        answer[i] == "Fizz" if i is divisible by 3.
        answer[i] == "Buzz" if i is divisible by 5.
        answer[i] == i (as a string) if none of the above conditions are true.
 

    Example 1:

        Input: n = 3
        Output: ["1","2","Fizz"]
    
    Example 2:

        Input: n = 5
        Output: ["1","2","Fizz","4","Buzz"]
    
    Example 3:

        Input: n = 15
        Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
 

    Constraints:

        1 <= n <= 10^4
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0412_Fizz_Buzz
{
    #region Solution

    /// <summary>
    /// Time complexity : O(n)
    /// Spatial complexity : O(n)
    /// <summary> 
    public static IList<string> FizzBuzz(int n)
    {
        var list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            bool fizz = i % 3 == 0;
            bool buzz = i % 5 == 0;

            if (fizz && buzz)
                list.Add("FizzBuzz");
            else if (fizz)
                list.Add("Fizz");
            else if (buzz)
                list.Add("Buzz");
            else
                list.Add(i.ToString());
        }

        return list;
    }

    #endregion

    #region Helpers
    
    static string ShowArray(string[] nums) => "[" + string.Join(", ", nums) + "]";
    
    static void Print(int n)
    {
        Console.WriteLine($"input : {n}");
        Console.WriteLine($"output : {ShowArray(FizzBuzz(n).ToArray())}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(3);
        Print(5);
        Print(15);
    }

    #endregion
}
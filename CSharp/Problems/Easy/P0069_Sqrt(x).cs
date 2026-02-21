/*
    69. Sqrt(x) 

    Given a non-negative integer x, return the square root of x rounded down to the nearest integer. 
    The returned integer should be non-negative as well.

    You must not use any built-in exponent function or operator.

    For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
 

    Example 1:

        Input: x = 4
        Output: 2
        Explanation: The square root of 4 is 2, so we return 2.

    Example 2:

        Input: x = 8
        Output: 2
        Explanation: The square root of 8 is 2.82842..., and since we round it down 
        to the nearest integer, 2 is returned.
 

    Constraints:

        0 <= x <= 2^31 - 1
*/

namespace LeetCode.CSharp.Problems.Easy;
public static class P0069_Sqrt_x_
{
    #region Optimal Solution

    /// <summary>
    /// Time Complexity : O(log(log x))
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int MySqrt_Newton(int x)
    {
        if(x < 2) return x;

        long guess = x;

        while(guess * guess > x)
            guess = (guess + x/guess) / 2;

        return (int)guess;
    }

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Time Complexity : O(log x)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int MySqrt_Bitwise(int x)
    {
        if (x < 2) return x; 
        
        int result = 0; 
        
        int bit = 1 << 30; // Le plus grand bit possible pour un int 
        
        // Trouver le plus grand bit <= x 
        while (bit > x) 
            bit >>= 2; 
        
        while (bit != 0) 
        { 
            if (x >= result + bit) 
            { 
                x -= result + bit; 
                result = (result >> 1) + bit; 
            } 
            else 
                result >>= 1; 
            
            bit >>= 2; 
        } 
        
        return result; 
    }

    /// <summary>
    /// Time Complexity : O(log x)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int MySqrt_BinarySearch(int x)
    {
        if (x < 2) return x;

        long left = 1, right = x / 2, mid, result = 0;

        while (left <= right)
        {
            mid = left + (right - left) / 2;
            long sqrt = mid * mid;

            if (sqrt == x)
                return (int)mid;
            
            if (sqrt < x)
            {
                result = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return (int)result;
    }

    /// <summary>
    /// Time Complexity : O(√x)
    /// Spatial Complexity : O(1)
    /// </summary>
    public static int MySqrt_Linear(int x)
    {
        long i = 0;
        for (i = 1; i * i <= x; i++)
            if (i * i == x)
                return (int)i;

        return (int)i - 1;
    }

    #endregion

    #region Helper

    public static void Print(int n, Func<int,int> method)
    {
        Console.WriteLine($"The square root of {n} is {method(n)}");
    }

    #endregion 

    #region Test

    public static void Test()
    {
        // MySqrt_Newton
        Print(4, MySqrt_Newton);
        Print(8, MySqrt_Newton);
        Print(63, MySqrt_Newton);

        // MySqrt_Bitwise
        Print(4, MySqrt_Bitwise);
        Print(8, MySqrt_Bitwise);
        Print(63, MySqrt_Bitwise);

        // MySqrt_BinarySearch
        Print(4, MySqrt_BinarySearch);
        Print(8, MySqrt_BinarySearch);
        Print(63, MySqrt_BinarySearch);

        // MySqrt_Linear
        Print(4, MySqrt_Linear);
        Print(8, MySqrt_Linear);
        Print(63, MySqrt_Linear);
    }

    #endregion
}
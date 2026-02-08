/*
    1207. Unique Number of Occurrences
    
    Given an array of integers arr, return true if the number of occurrences of each value 
    in the array is unique or false otherwise.

    Example 1:

        Input: arr = [1, 2, 2, 1, 1, 3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. 
                     No two values have the same number of occurrences.
    
    Example 2:

        Input: arr = [1, 2]
        Output: false
    
    Example 3:

        Input: arr = [-3, 0, 1, -3, 1, 1, 1, -3, 10, 0]
        Output: true

    Constraints:

    1 <= arr.length <= 1000
    - 1000 <= arr[i] <= 1000
*/

namespace LeetCore.CSharp.Problems.Easy;

public static class P1207_Unique_Number_Of_Occurences
{
    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(u)
    /// </summary>
    public static bool UniqueOccur(int[] arr)
    {
        var dict = new Dictionary<int, int>();

        foreach (int i in arr)
        {
            if (dict.ContainsKey(i))
                dict[i] += 1;
            else
                dict[i] = 1;
        }

        var counter = new Dictionary<int, int>();

        foreach (var item in dict)
        {
            if (!counter.TryAdd(item.Value, 0))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Complexité temporelle : O(n)
    /// Complexité spatialle : O(u)
    /// </summary>
    public static bool UniqueOccurLinq(int[] arr)
    {
        var dict = arr.GroupBy(elem => elem)
                      .ToDictionary(group => group.Key, group => group.Count());

        var counter = new HashSet<int>();

        foreach (var count in dict.Values)
            if (!counter.Add(count)) return false;

        return true;
    }

    public static void Test()
    {
        int[] nums = { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 };

        string showArray = "{" + string.Join(",", nums) + "}";

        Console.WriteLine($"Does the array nums = {showArray}, " +
            $"has unique number of occurences : {UniqueOccur(nums)}");
    }
}
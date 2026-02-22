/*
    500. Keyboard Row
    
    Given an array of strings words, return the words that can be typed using letters of 
    the alphabet on only one row of American keyboard like the image below.

    Note that the strings are case-insensitive, both lowercased and uppercased of 
    the same letter are treated as if they are at the same row.

    In the American keyboard:

    the first row consists of the characters "qwertyuiop",
    the second row consists of the characters "asdfghjkl", and
    the third row consists of the characters "zxcvbnm".

    Example 1:

        Input: words = ["Hello", "Alaska", "Dad", "Peace"]
        Output: ["Alaska", "Dad"]
        Explanation:
            Both "a" and "A" are in the 2nd row of the American keyboard due 
            to case insensitivity.

    Example 2:

        Input: words = ["omk"]
        Output: []

    Example 3:

        Input: words = ["adsdf", "sfd"]
        Output: ["adsdf", "sfd"]


    Constraints:

        1 <= words.length <= 20
        1 <= words[i].length <= 100
        words[i] consists of English letters (both lowercase and uppercase). 
*/

namespace LeetCode.CSharp.Problems.Easy;

public static class P0500_Keyboard_Row
{
    #region Optimal Solution

    /// <summary>
    /// Time complexity : O(N*M) 
    /// N is the total number of words in the input array words (words.Length)
    /// M is the maximum length of an individual word
    /// Spatial complexity : O(1)
    /// using array of 26 entries
    /// </summary>
    public static string[] FindWords_Iterative(string[] words)
    {
        var list = new List<string>();
        bool inSameRow;
        int rowLtr;
        foreach (string word in words)
        {
            inSameRow = true;
            rowLtr = LtrRow(word[0]);
            for (int i = 0; i < word.Length; i++)
            {
                if (!(LtrRow(word[i]) == rowLtr))
                {
                    inSameRow = false;
                    break;
                }
            }

            if (inSameRow) list.Add(word);
        }

        return list.ToArray();
    }

    static int LtrRow(char ltr)
    {
        ltr = char.ToLower(ltr);
        return rowMap[ltr - 'a'];
    }

    static readonly int[] rowMap = new int[26]
    {
        2,3,3,2,1,2,2,2,1,2,2,2,3,3,1,1,1,1,2,1,1,3,1,3,1,3
    };

    #endregion

    #region Alternative Solutions

    /// <summary>
    /// Time complexity : O(N*M) 
    /// N is the total number of words in the input array words (words.Length)
    /// M is the maximum length of an individual word
    /// Spatial complexity : O(K)
    /// K is the number of words that satisfy the condition
    /// (i.e., words that can be typed using only one row of the keyboard).
    /// </summary>
    public static string[] FindWords_Dict(string[] words)
    {
        List<string> results = new();
        foreach (string word in words)
        {
            int row = letterMappings[(char)(word[0] | 0x20)];

            for (int i = 1; i < word.Length; i++)
                if (letterMappings[(char)(word[i] | 0x20)] != row)
                    goto exit;

            results.Add(word);
            exit: { }
        }

        return results.ToArray();
    }

    static Dictionary<char, int> letterMappings = new() {
        {'a', 2}, {'b', 3}, {'c', 3}, {'d', 2}, {'e', 1},
        {'f', 2}, {'g', 2}, {'h', 2}, {'i', 1}, {'j', 2},
        {'k', 2}, {'l', 2}, {'m', 3}, {'n', 3}, {'o', 1},
        {'p', 1}, {'q', 1}, {'r', 1}, {'s', 2}, {'t', 1},
        {'u', 1}, {'v', 3}, {'w', 1}, {'x', 3}, {'y', 1},
        {'z', 3}
    };


    /// <summary>
    /// Time complexity : O(N*M) 
    /// N is the total number of words in the input array words (words.Length)
    /// M is the maximum length of an individual word
    /// Spatial complexity : O(K)
    /// K is the number of words that satisfy the condition
    /// (i.e., words that can be typed using only one row of the keyboard).
    /// </summary>
    public static string[] FindWords_Hash(string[] words)
    {
        var list = new List<string>();

        var row1 = new HashSet<char>("qwertyuiopQWERTYUIOP");
        var row2 = new HashSet<char>("asdfghjklASDFGHJKL");
        var row3 = new HashSet<char>("zxcvbnmZXCVBNM");

        bool inSameRow;
        ISet<char> targetRow;

        foreach (string word in words)
        {
            if (row1.Contains(word[0]))
                targetRow = row1;
            else if (row2.Contains(word[0]))
                targetRow = row2;
            else
                targetRow = row3;

            inSameRow = true;

            foreach (char c in word)
            {
                if (!targetRow.Contains(c))
                {
                    inSameRow = false;
                    break;
                }
            }

            if (inSameRow) list.Add(word);
        }

        return list.ToArray();
    }

    #endregion

    #region Helpers

    static string ShowArray(string[] nums) => "[" + string.Join(", ", nums) + "]";

    static void Print(string[] words, Func<string[], string[]> method)
    {
        Console.WriteLine($"The array : {ShowArray(words)} will result of the next array of words \n" +
                $"typed by using only the same row of the keyboard : {ShowArray(method(words))}");
    }

    #endregion

    #region Test

    public static void Test()
    {
        Print(new string[] { "Hello", "Alaska", "Dad", "Peace" }, FindWords_Iterative);
        Print(new string[] { "omk" }, FindWords_Iterative);
        Print(new string[] { "adsdf", "sfd" }, FindWords_Iterative);
    }

    #endregion
}
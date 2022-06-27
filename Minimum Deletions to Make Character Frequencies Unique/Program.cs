using System;
using System.Collections.Generic;

namespace Minimum_Deletions_to_Make_Character_Frequencies_Unique
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "fdaecbacbdfaecbacbde";
      Solution sol = new Solution();
      var answer = sol.MinDeletions_UsingDic(s);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int MinDeletions(string s)
    {
      // count the frequency of each characters
      int[] frequency = new int[26];
      // O(N)
      for (int i = 0; i < s.Length; i++)
      {
        frequency[s[i] - 'a']++;
      }

      int count = 0;
      // This set we have used to identify when duplicate frequency element is present or not ? If present
      // we will reduce its frequency by one and also which will increment its delete count
      // reduce until the frequency is not yet seen
      // Space O(N)
      HashSet<int> visited = new HashSet<int>();
      // O(N + 26*26) - 26 * 26 in worst case when all the freqency for all english 26 chars are same
      for (int i = 0; i < 26; i++)
      {
        // if any frequency is more than zero and also its present in the set
        while (frequency[i] > 0 && !visited.Add(frequency[i]))
        {
          // reduce its frequency by one such that it become unique
          // until it is unique will be inside while loop
          frequency[i]--;
          count++;
        }
      }

      return count;
    }

    public int MinDeletions_UsingDic(string s)
    {
      Dictionary<char, int> frequency = new Dictionary<char, int>();
      foreach (char c in s)
      {
        if (!frequency.ContainsKey(c)) frequency.Add(c, 0);
        frequency[c]++;
      }

      int count = 0;
      HashSet<int> visited = new HashSet<int>();
      foreach (var v in frequency.Values)
      {
        int t = v;
        while (t > 0 && !visited.Add(t))
        {
          t--;
          count++;
        }
      }

      return count;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CountLetters
{
    public class CountLetters
    {
        public Dictionary<string, int> Letters(string str)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (counts.ContainsKey(str[i].ToString()))
                    counts[str[i].ToString()]++;
                else
                    counts.Add(str[i].ToString(), 1);
            }

            foreach (var count in counts)
                Console.WriteLine($"{count.Key} = {count.Value}");

            return counts;
        }
    }
}

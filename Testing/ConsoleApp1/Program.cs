using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ssfarekjaasd";
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
        }
    }
}

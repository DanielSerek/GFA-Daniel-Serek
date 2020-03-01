using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string hungarian = "bemutatkozik";
            string teve = hungarian;
            int length = teve.Length;
            for (int i = 0; i < length; i++)
            {
                char c = teve[i];
                if (IsVowel(c))
                {
                    teve = string.Join(c + "v" + c, teve);
                    i += 2;
                    length += 2;
                }
            }
        }

        public static bool IsVowel(char c)
        {
            return (new List<char>() { 'a', 'u', 'o', 'e', 'i' }).Contains(c);
        }
    }
}

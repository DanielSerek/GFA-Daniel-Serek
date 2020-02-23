using System;
using System.Collections.Generic;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("goddog: " + isPalindrome("goddog"));
            Console.WriteLine("gobdog: " + isPalindrome("gobdog"));

            outputStringList(searchPalindrome("dog goat dad duck doodle never"));
            outputStringList(searchPalindrome("apple"));
            outputStringList(searchPalindrome("racecar"));
            outputStringList(searchPalindrome(""));
        }

        static void outputStringList(List<string> input)
        {
            Console.Write("[");
            for (int i = 0; i < input.Count; i++)
            {
                Console.Write("\"" + input[i] + "\"");
                if (i < input.Count - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }

        static List<string> searchPalindrome(string input)
        {
            List<string> output = new List<string>();
            for (int l = 3; l <= input.Length; l++)
            {
                for (int i = 0; i <= input.Length - l; i++)
                {
                    string sub = input.Substring(i, l);
                    if (isPalindrome(sub))
                    {
                        output.Add(sub);
                        //Console.WriteLine(sub);
                    }
                }
            }
            return output;
        }
        static bool isPalindrome(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
            /*
            bool pal = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    pal = false;
                }
            }
            return pal;
            
            
            int i;
            for (i = 0; i < input.Length; i++)
            {
                if(input[i] != input[input.Length - 1 - i])
                {
                    break;
                }
            }
            return i == input.Length;
            */

        }
    }
}

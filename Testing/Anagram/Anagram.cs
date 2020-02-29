using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram
{
    class Anagram
    {
        //public bool TestAnagram(string str1, string str2)
        //{
        //    for (int i = 0; i < str1.Length || i < str2.Length; i++)
        //    {
        //        if (str1[i] != str1[str1.Length - i - 1]) return false;
        //        if (str2[i] != str2[str2.Length - i - 1]) return false;
        //    }
        //    return true;
        //}


        /*
            char[] wordARr = word1.ToCharArray();
            Array.Reverse(wordARr);
            return wordARr.ToString();
        */


        public bool TestAnagram(string str1, string str2)
        {
            string reversedWord = "";

            for (int i = str2.Length - 1; i >= 0; i--)
            {
                reversedWord += str2[i];
            }

            Console.WriteLine(reversedWord);

            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != reversedWord[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

    }
}

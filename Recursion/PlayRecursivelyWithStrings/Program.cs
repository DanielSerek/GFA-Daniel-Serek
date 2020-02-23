using System;
using System.Text;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a string, compute recursively(no loops) a
            //    new string where all the lowercase 'x' 
            //    chars have been changed to 'y' chars.

            string word = "luxus";

            Console.WriteLine(ChangeLetter(word));
            Console.WriteLine(RecursivelyChangeLetter(word));

            //Given a string, compute recursively a new string where all the
            //    'x' chars have been removed.

            //Given a string, compute recursively a new string where all the 
            //    adjacent chars are now separated by a *


            Console.ReadLine();
        }
        public static string ChangeLetter(string word)
        {
            StringBuilder newWord = new StringBuilder();
            //int i;
            //if (i < word.Length)
            //{
            //    return 0;
            //}
            //ChangeLetter(word.Substring(i+1,1));

            for (int i = 0; i <= word.Length - 1; i++)
            {
                if (word.Substring(i, 1) == "x")
                {
                    newWord.Append("y");
                }
                else
                {
                    newWord.Append(word.Substring(i, 1));
                }

            }

            return newWord.ToString();

        }

        public static string RecursivelyChangeLetter(string word)
        {
            StringBuilder newWord = new StringBuilder();

            if (0 == word.Length)
            {
                return "";
            }
            else
            {
                if (word.Substring(0, 1) == "x")
                {
                    newWord.Append("y");
                }
                else
                {
                    newWord.Append(word.Substring(0, 1));
                }

                RecursivelyChangeLetter((word.Substring(1)));
                return newWord.ToString();
            }
        }
    }
}

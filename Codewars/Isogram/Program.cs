using System;
using System.Collections;

namespace Isogram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test;
            test = IsIsogram("moose");
            Console.WriteLine(test);
            
            



        }

        public static bool IsIsogram(string str)
        {
            // Code on you crazy diamond!  
            str = str.ToLower();
            
            Console.WriteLine(str);


            char[] characters = str.ToCharArray();   //Convert string to char array
            Array.Sort(characters);                  //Sort the char array

            for (int i = 0; i < characters.Length - 1; i++)
            {
                if (characters[i] == characters[i + 1])
                {
                    return false;
                }
            }

            return true;

        }

    }
    
}

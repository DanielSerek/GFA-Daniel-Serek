using System;

namespace Exercise7
{
    class Program
    {
        /*
            //  Create a function that takes a number and an array of integers as a parameter
            //  Returns the indices of the integers in the array of which the first number is a part of
            //  Or returns an empty array if the number is not part of any of the integers in the array

            //  Example:
            Console.WriteLine(SubInt(1, new int[] {1, 11, 34, 52, 61}));
            //  should print: `[0, 1, 4]`
            Console.WriteLine(SubInt(9, new int[] {1, 11, 34, 52, 61}));
            //  should print: '[]' 
             
        */

        static void Main(string[] args)
        {
            // zadání
            int[] s = { 5, 11, 34, 52, 11, 61 };
            int dig = 5;
            char znak = (char)(dig + 0x30);
            
            int[] pole2 = SubInt(znak, s);

            foreach (int i in pole2)
            {
                Console.Write(i+" ");
            }

        }

        static int[] SubInt(char num, int[] s)
        {
            // inicializace proměnných
            int delkaPole = 0;
            int j = 0;

            // zjištění délky nového pole s indexy
            for (int i = 0; i < s.Length; i++)
            {
                string numberStr = s[i].ToString();

                foreach (char c in numberStr)
                {
                    if (c == num)
                    {
                        delkaPole++;
                        break;
                    }
                }
            }

            // vytvoření nového pole s indexy
            int[] indexy = new int[delkaPole];

         
            // naplnění nového pole indexy hodnotami
            for (int i = 0; i < s.Length; i++)
            {
                string numberStr = s[i].ToString();

                foreach (char c in numberStr)
                {
                    if (c == num)
                    {
                        indexy[j] = i;
                        j++;
                        break;
                    }
                }
            }

            return indexy;

        }

    }
}

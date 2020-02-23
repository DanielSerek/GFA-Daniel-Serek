using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            // assignment
            int[] s = { 5, 11, 34, 52, 11, 61, 58, 52, 99, 11, 11 };
            foreach (int i in s)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            int[] novePole = Unique(s);

            // print the new array
            for (int i = 0; i < novePole.Length; i++)
            {
                Console.Write(novePole[i] + " ");
            }

        }

        static int[] Unique(int[] s)
        {
            // ascending array sorting
            Array.Sort(s);


            // print the existing array 
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + " ");
            }
            Console.WriteLine("\n");


            // determine the length of the future array
            int delkaPole = 0;
            int j = 0;
            while (j < s.Length - 1)
            {
                if (s[j] != s[j + 1])
                {
                    delkaPole++;
                }
                j++;
            }


            // fill the new array with numbers
            int[] novePole = new int[delkaPole + 1];
            int x = 1;
            j = 0;
            novePole[0] = s[0];

            while (j < s.Length - 1)
            {
                if (s[j] != s[j + 1])
                {
                    novePole[x] = s[j + 1];
                    x++;
                }
                j++;
            }
            return novePole;
            
        }
    }
}





  


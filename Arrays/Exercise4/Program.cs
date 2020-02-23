using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {

            // PRINT ONE ELEMENT FROM AN ARRAY
            int[] s = { 1, 2, 3, 8, 5, 6 };
            s[3] = 4;
            Console.WriteLine(s[3]);


            // INCREMENT ELEMENT IN AN ARRAY
            int[] t = { 1, 2, 3, 4, 5 };
            t[3]++;
            Console.WriteLine(t[3]);


            // PRINT OUT AN ARRAY
            int[] numbers = { 4, 5, 6, 7 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();


            // TWO DIMENSIONAL ARRAY
            int[,] matrix = new int[4, 4];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;             
                    }
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // ARRAY ELEMENTS ALTERATION

            int[] numList = { 3, 4, 5, 6, 7 };

            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = numList[i] * 2;
                Console.Write(numList[i]+" ");
            }

            Console.WriteLine();
            Console.WriteLine();


            // PRINT OUT JAGGED ARRAY
            string[][] colors = new string[3][];
            colors[0] = new []{ "lime", "forest green" , "olive", "pale green", "spring green" };
            colors[1] = new []{ "orange red", "red", "tomato" };
            colors[2] = new []{ "orchid", "violet", "pink", "hot pink" };

            for(int i = 0; i < colors.Length; i++)
            { 
                for(int j = 0; j < colors[i].Length; j++)
	            {
                    Console.Write(colors[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();


            // APPEND LETTERS TO THE STRINGS IN AN ARRAY
            string[] animals = { "koal", "pand", "zebr" };
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i] += "a";
                Console.WriteLine(animals[i]);
            }

            Console.WriteLine();
            Console.WriteLine();


            // SWAP ELEMENTS IN AN ARRAY
            string[] abc = {"first", "second", "third"};
            string temp = abc[0];
            abc[0] = abc[2];
            abc[2] = temp;

            for (int i = 0; i < abc.Length; i++)
            {
                Console.Write(abc[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();


            // SUM OF ARRAY ELEMENTS
            int[] ai = { 3, 4, 5, 6, 7 };
            int sum = 0;

            for (int i = 0; i < ai.Length; i++)
            {
                Console.Write(ai[i] + " ");
                sum += ai[i];
            }
            Console.WriteLine();
            Console.WriteLine("Total sum: " + sum);

            Console.WriteLine();
            Console.WriteLine();


            // REVERSE ARRAY ELEMENTS
            int[] aj = { 3, 4, 5, 6, 7 };
            int value = 0;

            for (int i = 0; i < aj.Length/2; i++)
            {
                value = aj[i];
                aj[i] = aj[aj.Length - 1 - i];
                aj[aj.Length - 1 - i] = value;
            }

            // Array.Reverse(aj);

            for (int i = 0; i < aj.Length; i++)
            {
                Console.Write(aj[i] + " ");
            }













}
    }
}

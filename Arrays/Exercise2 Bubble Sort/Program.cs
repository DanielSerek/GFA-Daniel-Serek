using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bubble Sort


            // Assignment and array print out
            int[] pole = { 4, 5, 63, 2, 83, 22, 23, 2 };

            foreach (int i in pole)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine("\n");

            // Bubble Sort
            for (int i = 0; i < pole.Length; i++)
            {
                for (int j = 0; j < pole.Length - 1 - i; j++)
                {
                    int temp;
                    if (pole[j] > pole[j+1])
                    {
                        temp = pole[j];
                        pole[j] = pole[j + 1];
                        pole[j + 1] = temp;
                    }
                }
            }


            // New field print out
            foreach (int i in pole)
            {
                Console.Write(i + " ");
            }

        }
    }
}

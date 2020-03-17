using System;

namespace IsSymmetric
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] input =
            {
                {1, 0, 1},
                {0, 2, 2},
                {1, 2, 5}
            };

            int N = input.GetLength(0);
            Console.WriteLine(IsSymmetric(input, N));
        }

        static bool IsSymmetric(int[,] matrix, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] != matrix[j, i]) return false;
                }
            }
            return true;
        }
    }
}

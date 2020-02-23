using System;

namespace MatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {

            // Define matrix
            Console.Write("Define n x n matrix: ");
            int n = Int32.Parse(Console.ReadLine());

            // Create and fill matrix with the numbers
            int[,] matrix = new int[n, n];
            int x = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = x;
                    x++;
                }
            }

            printMatrix(matrix);
            Console.WriteLine();
            matrix = rotateMatrix(matrix);
            printMatrix(matrix);
        }

        static int[,] rotateMatrix(int[,] inputMatrix)
        {
            int n = inputMatrix.GetLength(0);
            int[,] rotatedMatrix = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    rotatedMatrix[i, j] = inputMatrix[n - j - 1, i];
                }
            }
            
            return rotatedMatrix;
        }

        static void printMatrix (int [,] inputMatrix)
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    Console.Write(inputMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }


    }
}

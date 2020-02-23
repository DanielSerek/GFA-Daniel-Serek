using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me a number: ");
            int N = Int32.Parse(Console.ReadLine());
            if (N % 2 == 0) N++;
            int M = N / 2;

            for (int i = 0; i < N; i++)
            {
                int DV = Math.Abs(M - i);
                for (int j = 0; j < N; j++)
                {
                    int DH = Math.Abs(M - j);

                
                Console.Write(((DH + DV)<=M)?"*":" ");
                 //   if ((DH + DV) <= M)
                 //   {
                 //       Console.Write("*");
                 //   }
                 //else
                 //   {
                 //       Console.Write(" ");
                 //   }
                }
                Console.WriteLine();
            }
        }
    }
}

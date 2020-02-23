using System;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GCD(54, 24));
        }



        static int GCD(int n1, int n2)
        {
            if (n2 == 0) return n1;
            else
            {
                Console.WriteLine($"Not yet. {n1} / {n2} has a remainder {n1 % n2}");
                return GCD(n2, n1 % n2);
            }
        }

        
    }
}

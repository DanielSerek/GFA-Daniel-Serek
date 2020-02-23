using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole1 = { 1, 2, 3 };
            int[] pole2 = { 4, 5 };

            if (pole1.Length < pole1.Length)
            {
                Console.WriteLine("Pole 2 je delší");
            }
            else
            {
                Console.WriteLine("Pole 1 je delší");
            }
        }
    }
}

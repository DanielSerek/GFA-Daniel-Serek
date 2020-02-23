using System;

namespace Number_Adder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddNumber(15000));

        }


        public static int AddNumber(int n)
        {
            if (n == 1) return n = 1;
            else return n += AddNumber(n - 1);
        }

    }
}

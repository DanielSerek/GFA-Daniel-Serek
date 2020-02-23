using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumDigits(124)); 
        }

        public static int SumDigits(int number)
        {
            //Console.WriteLine((n / 1) % 10);
            //Console.WriteLine((n / 10) % 10);
            //Console.WriteLine(((n / 100) % 10));
            
            if ((number / 10) == 0) return number % 10;
            else return number % 10 + SumDigits(number / 10);

            //do
            //{
            //num += (n / x) % 10;
            //x *= 10;
            //} while (n / x != 0);
            
        }
        

    }
}

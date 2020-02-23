using System;

namespace DivideByZero
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a function that takes a number
            // divides ten with it,
            // and prints the result.
            // It should print "fail" if the parameter is 0

            int num = 0;
            Console.Write("Give me a number that you like to divide 10 with: ");
            num = Int32.Parse(Console.ReadLine());
            
            if (Divide(num) != -1)
            {
                Console.WriteLine($"The result is: {Divide(num)}");
            }
        }

        static int Divide (int num)
        {
            int result;
            try
            {
                result = 10 / num;
                return result;                   
            }
            catch (DivideByZeroException)
            {
                Console.Write("Fail");
                return -1;
            }
        }
    }
}

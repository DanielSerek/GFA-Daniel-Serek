using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me first number: ");
            int firstNumber = Int32.Parse(Console.ReadLine());

            Console.Write("Give me first number: ");
            int secondNumber = Int32.Parse(Console.ReadLine());

            if (firstNumber >= secondNumber)
            {
                Console.WriteLine("The second number should be bigger.");
            }

            else
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    Console.WriteLine(i);
                }
            }
            
        }
    }
}

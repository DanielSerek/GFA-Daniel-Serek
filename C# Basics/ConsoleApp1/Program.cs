using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);

            Console.WriteLine("Guess a number between 1 and 100!");
            int guess;
            do
            {
                guess = Int32.Parse(Console.ReadLine());

                if (guess < number)
                {
                    Console.WriteLine("The stored number is higher.");
                }

                else if (guess > number)
                {
                    Console.WriteLine("The stored number is lower.");
                }

                else
                {
                    Console.WriteLine($"You found number: {number}");
                }

            }
            while (number != guess);

        }
    }
}

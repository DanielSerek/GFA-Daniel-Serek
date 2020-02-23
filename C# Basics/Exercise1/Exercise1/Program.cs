using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Give me a number: ");
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"You wrote the number: {number}");

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{i} * {number} = {i * number}");
            }

            Console.ReadLine();
        }
    }
}

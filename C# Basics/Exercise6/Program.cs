using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me a number: ");
            int totalNumber = Int32.Parse(Console.ReadLine());
            double sum = 0;
            int i = 1;
            double average;

            do
            {
                Console.Write($"Tell me {i}.number: ");
                int number = Int32.Parse(Console.ReadLine());
                sum += number;
                i++;
                ;
            }
            while (i != totalNumber + 1);

            average = sum / totalNumber;

            Console.WriteLine($"The sum of the entered numbers is: {sum}");
            Console.WriteLine($"The average of the numbers is: {average}");
            Console.ReadLine();
        }
    }
}

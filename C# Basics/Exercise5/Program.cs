using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {

            string diagonal = "";
            Console.Write("Give me a number: ");
            int linesNumber = Int32.Parse(Console.ReadLine());

            string result = new String('-', 5);


            for (int i = 1; i <= linesNumber; i++)
            {
                if (i == 1 || i == (linesNumber + 1)/2 || i == linesNumber)
                {
                    diagonal = new string('*', linesNumber);
                    Console.WriteLine(diagonal);
                }

                else if (i >= 1 && i <= (linesNumber / 2))
                {             
                    diagonal = new string('*', i) + new string(' ', linesNumber - i - 1) + new string('*', 1); ;
                    Console.WriteLine(diagonal);
                }

                else
                {
                    diagonal = new string('*', 1) + new string(' ', i - 2) + new string('*', linesNumber - i + 1); ;
                    Console.WriteLine(diagonal);
                }


            }
        }
    }
}

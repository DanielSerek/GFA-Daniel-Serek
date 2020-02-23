using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            string triangle = "";

            Console.Write("Give me a number: ");
            int number = Int32.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {        
                triangle += "*";
                Console.WriteLine(triangle);
            }
            
        }
    }
}

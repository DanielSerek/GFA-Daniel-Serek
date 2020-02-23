using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int baseNum = 123;
            Console.WriteLine($"The double number of {baseNum} is: {Doubling(baseNum)}");
            Console.WriteLine("\n\n");

            string al = "Daniel";
            Greet(al);
            Console.WriteLine("\n\n");

            string typo = "Chinchill";
            Console.WriteLine(AppendAFunc(typo));
            Console.WriteLine("\n\n");


            int number = 5;
            Console.WriteLine(sum(number));
            Console.WriteLine("\n\n");

            int number2 = 4;
            Console.WriteLine(fact(number2));
            Console.WriteLine("\n\n");
        }
    

        // FACTORIAL FUNCTION
        static int fact(int num2)
        {
            int faktorial = 1;

            for (int i = 1; i <= num2; i++)
            {
                faktorial *= i;
            }
            return faktorial;
        }


        // SUM NUMBERS
        static int sum(int num1)
        {
            int total = 0;
            for (int i = 0; i <= num1; i++)
            {
                total += i;
            }
            return total;
        }


        // DOUBLE THE NUMBER FUNCTION
        static int Doubling(int cislo)
        {
            return cislo * cislo;
        }


        // GREETING FUNCTION
        static void Greet(string name)
        {
            Console.WriteLine($"Greetings dear, {name}");
        }


        // APPENDAFUNC
        static string AppendAFunc(string retezec)
        {
            retezec += "a";
            return retezec;
        }

    }
}

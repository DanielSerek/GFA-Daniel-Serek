using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human("John", 37, 95);

            Console.WriteLine("Is our human nameless? " + human.IsNameLess());
            Console.WriteLine("Our human is {0} and he is {1} old", human.Name, human.Age);
            Console.WriteLine("Is our human smart: " + human.IsSmart());

            human.BeSmarter();
            Console.WriteLine("Is our human smart now? " + human.IsSmart());

            Console.ReadLine();
        }
    }
}

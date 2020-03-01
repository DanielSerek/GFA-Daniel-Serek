using System;

namespace AnimalWithTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Animal("Fiona", 33, 22);
            Animal dog = new Animal("Frodo", 12, 12);

            cat.SayStatus();
            cat.Eat();
            cat.SayStatus();

            Console.WriteLine($"Whoof, I am {dog.Name}");
        }
    }
}

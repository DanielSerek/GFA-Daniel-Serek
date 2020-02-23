using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    class Animal
    {
        public string Name;
        public int Hunger;
        public int Thirst;


        public Animal(string name, int hunger, int thirst)
        {
            Name = name;
            Hunger = hunger;
            Thirst = thirst;
        }

        
        public void Eat()
        {
            Console.WriteLine($"{Name} eating...");
            Hunger -= 1;
        }

        public void Drink()
        {
            Console.WriteLine($"{Name} drinking..." );
            Thirst -= 1;
        }

        public void Play()
        {
            Console.WriteLine($"{Name} playing...");
            Thirst += 1;
            Hunger += 1;
        }

        public void SayStatus()
        {
            Console.WriteLine($"I am {Name}, my hunger is {Hunger} and my thirst is {Thirst}.");
        }





    }
}

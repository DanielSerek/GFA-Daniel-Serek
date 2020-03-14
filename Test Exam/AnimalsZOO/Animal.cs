using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public abstract class Animal
    {

        public string Name;
        public bool Herbivore;
        public int MaxFeed;
        public int CurrentFeed;
        public int ConsumedFood;
        public int ConsumeLevel;

        public Animal(string name)
        {
            Name = name;
            ConsumedFood = 0;
        }

        public bool IsHerbivore() => Herbivore;

        public int GetHunger() => MaxFeed - CurrentFeed;

        public void Eat(int food)
        {
            if (food + this.CurrentFeed > this.MaxFeed)
                Console.WriteLine($"You can't feed the animal so much! The maximum feed can be {this.MaxFeed - this.CurrentFeed}");
            else
            {
                this.CurrentFeed += food;
                this.ConsumedFood += food;
            }
        }

        public int Live()
        {
            CurrentFeed -= ConsumeLevel;
            return ConsumeLevel;
        }

        public int Run()
        {
            CurrentFeed -= 3 * ConsumeLevel;
            return 3 * ConsumeLevel;
        }
        
        public string GetStatus()
        {
            return $"The animal name is {this.Name}, it's hunger level is " +
                $"{this.GetHunger()} and it is {((this.Herbivore) ? "herbivore" : "carnivore")}";
        }
    }
}

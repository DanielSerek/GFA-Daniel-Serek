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

        public Animal(string name, int currentFeed)
        {
            Name = name;
            CurrentFeed = currentFeed;
            ConsumedFood = 0;
        }

        public bool IsHerbivore() => Herbivore;

        public int GetHunger() => MaxFeed - CurrentFeed;

        /*The Animal
Each animal should have a name and a boolean value if it is herbivore
Each animal should store how much food they able to eat and a current belly level as integers
Each animal should store a level how much food they consume from the belly while they live
It should have an IsHerbivore method that returns if it is herbivore
It should have an GetHunger  method that returns how much food the animal needs to be full
It should have an Eat  method that takes food as integer and fills the belly with that amount. it throws an error if the food is more than it is able to eat
It should have a Live  method that returns how much food it consumed
It should have a Run  method works like Live but consumes 3 times more food
It should have a GetStatus method that returns a string that states the name and the hungerlevel and wether the animal is herbivore*/

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

        public int Live() => ConsumeLevel;

        public int Run() => 3 * ConsumeLevel; 
        
        public string GetStatus()
        {
            return $"The animal name is {this.Name}, it's hunger level is " +
                $"{this.GetHunger()} and it is {((this.Herbivore) ? "herbivore" : "carnivore")}";
        }
    }
}

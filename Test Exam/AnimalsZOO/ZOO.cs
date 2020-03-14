using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public class ZOO
    {
        public int Meat;
        public int Vegetables;
        public int Shit;
        public List<Animal> Animals;

        public ZOO(int meat, int vegetables)
        {
            Meat = meat;
            Vegetables = vegetables;
            Shit = 0;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void FeedAllAnimals()
        {
            foreach (var animal in Animals)
            {
                if(animal.Herbivore && Vegetables > 0)
                {
                    if (Vegetables < animal.GetHunger()) animal.CurrentFeed += Vegetables;
                    else animal.CurrentFeed += animal.GetHunger();
                }
                
                if (!animal.Herbivore && Meat > 0)
                {
                    if (Meat < animal.GetHunger()) animal.CurrentFeed += Meat;
                    else animal.CurrentFeed += animal.GetHunger();
                }
            }
        }

        public void RefillFood(int meat, int vegetables)
        {
            Meat += meat;
            Vegetables += vegetables;
        }

        /*It should have a SpendNormalDay method that calls the Live and Run methods of each animals and aggregates all the consumed foods as shit into the shit levels
It should have a SpendQuarantineDay method that does the same as SpendNormalDay just only calls the Live  method
It should have a GetTheFullestStatus method that returns the status of the animal that is the least hungry, it should take a filterHerbivore parameter and if that is true it should only search between the carnivores*/
        
        public void SpendNormalDay()
        {
            foreach (var animal in Animals)
            {
                animal.Live();
                animal.Run();
            }
        }

    }
}

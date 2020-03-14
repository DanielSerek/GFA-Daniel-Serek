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
                if (animal.IsHerbivore() && Vegetables > 0)
                {
                    if (Vegetables < animal.GetHunger()) animal.CurrentFeed += Vegetables;
                    else animal.CurrentFeed += animal.GetHunger();
                }

                if (!animal.IsHerbivore() && Meat > 0)
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


        public void SpendNormalDay()
        {
            foreach (var animal in Animals)
            {
                Shit += animal.Live();
                Shit += animal.Run();
            }
        }

        public void SpendQuarantineDay()
        {
            foreach (var animal in Animals)
            {
                Shit += animal.Live();
            }
        }

        public string GetFullestStatus(bool filterHerbivore)
        {
            int index = 0;
            // I need to fill the first value into difference variable
            int j = 0;
            int difference = 0;
            do
            {
                if (Animals[j].Herbivore == filterHerbivore)
                {
                    difference = Animals[j].GetHunger();
                    break;
                }
                if (Animals[j].Herbivore != filterHerbivore)
                {
                    difference = Animals[j].GetHunger();
                    break;
                }
                j++;
            } while (j < Animals.Count);



            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].GetHunger() < difference && Animals[i].Herbivore == filterHerbivore)
                {
                    difference = Animals[i].GetHunger();
                    index = i;
                }
                else if(Animals[i].GetHunger() < difference && Animals[i].Herbivore != filterHerbivore) 
                {
                    difference = Animals[i].GetHunger();
                    index = i;
                }
            }
            return Animals[index].GetStatus();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Protection
{
    public class Animal_shelter 
    {
        public int Budget;
        public List<Animal> Animals =  new List<Animal>();
        public List<string> Adopters = new List<string>();

        public int Rescue(Animal animal)
        {
            Animals.Add(animal);
            return Animals.Count;
        }

        public int Heal()
        {
            int count = 0;
            foreach (var animal in Animals) // How to replace with Linq?
            {
                if (!animal.IsHealthy)
                {
                    animal.IsHealthy = true;
                    count++;
                    break;
                }
            }
            return count;
        }

        public void AddAdopter(string name)
        {
            Adopters.Add(name);
        }

        public void FindNewOwner()
        {
            Random random = new Random();
            var newAdopter = random.Next(0, Adopters.Count);
            var animalToBeAdopted = random.Next(0, Animals.Count);
            Adopters.RemoveAt(newAdopter);
            Animals.RemoveAt(animalToBeAdopted);
        }

        public int EarnDonation(int amount)
        {
            Budget += amount;
            return Budget; 
        }

        public override string ToString()
        {
            string newString;
            newString = $"\nBudget: {this.Budget} €,\nThere are: {Animals.Count} and {Adopters.Count} potential adopter(s)";
            foreach (var animal in Animals)
            {
                newString += $"\n{animal.AnimalName} " + (!animal.IsHealthy ? $"is not healthy (healing would cost: {animal.HealCost}€) and not adoptable" : "is healthy and adoptable");
            }

            //StringBuilder newString = new StringBuilder();
            //newString.Append($"\nBudget: {this.Budget} €,\nThere are: {Animals.Count} and {Adopters.Count} potential adopter(s)");
            //foreach (var animal in Animals)
            //{
            //    newString.Append($"\n{animal.AnimalName} " + (!animal.IsHealthy ? $"is not healthy (healing would cost: {animal.HealCost}€) and not adoptable" : "is healthy and adoptable"));
            //}

            return newString;
        }
    }
}

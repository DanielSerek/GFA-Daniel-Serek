using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Protection
{
    public class Animal
    {
        public string AnimalName;
        public string OwnerName;
        public bool IsHealthy;
        public int HealCost;
       
        public Animal(string animalName, string ownerName, bool isHealthy)
        {
            AnimalName = animalName;
            OwnerName = ownerName;
            IsHealthy = isHealthy;
        }

        public void Heal()
        {
            IsHealthy = true;
        }

        public bool IsAdoptable()
        {
            if (IsHealthy) return true;
            else return false;
        }

        public override string ToString()
        {
            string str;
            if (!IsHealthy) str = ($"{AnimalName} is not healthy ({HealCost}€), and not adoptable");
            else str = ($"{AnimalName} is healthy, and adoptable");
            return str;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Protection
{
    class Dog : Animal
    {
        public Dog(string animalName, string ownerName, bool isHealthy) : base(animalName, ownerName, isHealthy)
        {
            Random random = new Random();
            HealCost = random.Next(1, 8);
        }
    }
}

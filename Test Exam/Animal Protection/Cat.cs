using System;
using System.Collections.Generic;
using System.Text;

namespace Animal_Protection
{
    internal class Cat : Animal
    {
        public Cat(string animalName, string ownerName, bool isHealthy) : base(animalName, ownerName, isHealthy)
        {
            Random random = new Random();
            HealCost = random.Next(0, 6);
        }
    }
}

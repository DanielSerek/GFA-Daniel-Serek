using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public class Wolf : Animal
    {
        public Wolf(string name, int currentFeed) : base(name, currentFeed)
        {
            Herbivore = false;
            MaxFeed = 5;
            ConsumeLevel = 1;
        }
    }
}

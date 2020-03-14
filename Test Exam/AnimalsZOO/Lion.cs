using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public class Lion : Animal
    {
        public Lion(string name, int currentFeed) : base(name, currentFeed)
        {
            Herbivore = false;
            MaxFeed = 10;
            ConsumeLevel = 2;
        }
    }
}

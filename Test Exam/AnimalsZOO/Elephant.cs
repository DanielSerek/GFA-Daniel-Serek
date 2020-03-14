using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public class Elephant : Animal
    {
        public Elephant(string name) : base(name)
        {
            Herbivore = true;
            MaxFeed = 40;
            ConsumeLevel = 5;
        }
    }
}

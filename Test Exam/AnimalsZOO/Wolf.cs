using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public class Wolf : Animal
    {
        public Wolf(string name) : base(name)
        {
            Herbivore = false;
            MaxFeed = 5;
            ConsumeLevel = 1;
        }
    }
}

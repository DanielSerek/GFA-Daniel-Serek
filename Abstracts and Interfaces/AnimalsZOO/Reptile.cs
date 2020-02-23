using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    class Reptile : Animal
    {

        public Reptile(string name)
        {
            Name = name;
        }

        public override string WantChild()
        {
            return "an egg!";
        }
    }
}

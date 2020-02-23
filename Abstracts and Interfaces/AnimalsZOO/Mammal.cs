using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    class Mammal : Animal
    {
    
        public Mammal(string name)
        {
            Name = name;
        }

        public override string WantChild()
        {
            return "my uterus!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    class Bird : Animal, IFlyable
    {

        public Bird(string name)
        {
            Name = name;
        }

        public void Fly()
        {
            Console.WriteLine($"The {Name} is flying.");
        }

        public void Land()
        {
            Console.WriteLine($"The {Name} is landing.");
        }

        public void TakeOff()
        {
            Console.WriteLine($"The {Name} is taking off.");
        }

        public override string WantChild()
        {
            return "an egg!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    class ZOO
    {
        static void Main(string[] args)
        {
            var reptile = new Reptile("Crocodile");
            var mammal = new Mammal("Koala");
            var bird = new Bird("Parrot");

            Console.WriteLine("Who want a baby?");
            Console.WriteLine(reptile.GetName() + ", " + reptile.WantChild());
            Console.WriteLine(mammal.GetName() + ", " + mammal.WantChild());
            Console.WriteLine(bird.GetName() + ", " + bird.WantChild());

            bird.TakeOff();
            bird.Fly();
            bird.Land();

        }
    }
}

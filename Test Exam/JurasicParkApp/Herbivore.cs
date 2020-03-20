using System;
using System.Collections.Generic;
using System.Text;

namespace JurasicParkApp
{
    public class Herbivore : Dinosaur
    {
        public Herbivore(Name name, int water) : base(name, water)
        {
        }

        public Herbivore(Name name, int water, int weight) : base(name, water, weight)
        {
        }

        public override void Pet()
        {
            Console.WriteLine("Lovely animal, isn't it?");
        }

        public override void Roar()
        {
            Console.WriteLine("Roar");
        }
    }
}

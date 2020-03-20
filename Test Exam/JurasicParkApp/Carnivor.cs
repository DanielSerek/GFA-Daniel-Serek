using System;
using System.Collections.Generic;
using System.Text;

namespace JurasicParkApp
{
    public class Carnivor : Dinosaur
    {
        public Carnivor(Name name, int water) : base(name, water)
        {
        }

        public Carnivor(Name name, int water, int weight): base(name, water, weight)
        {
        }

        public override void Pet()
        {
            Console.WriteLine("Are you crazy? He chop your arm!");
        }

        public override void Roar()
        {
            Console.WriteLine("Roar");
        }
    }
}

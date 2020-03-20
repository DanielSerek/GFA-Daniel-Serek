using System;
using System.Collections.Generic;
using System.Text;

namespace JurasicParkApp
{
    public class Water : Dinosaur
    {
        public Water(Name name, int water) : base(name, water)
        {
        }

        public Water(Name name, int water, int weight) : base(name, water, weight)
        {
        }

        public override void Pet()
        {
            Console.WriteLine("Get some air, man!");
        }

        public override void Roar()
        {
            Console.WriteLine("Glo glo glo");
        }
    }
}

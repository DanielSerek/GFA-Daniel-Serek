using System;
using System.Collections.Generic;
using System.Text;

namespace GardenApplication
{
    public class Flower : Plant
    {
        public Flower(string color) : base(color)
        {
            Color = color;
            MinWater = 5;
            Absorption = 0.75f;
            CurrentWater = 0;
        }

        public override void Status()
        {
            if (NeedsWater()) Console.WriteLine($"The {Color} Flower needs water.");
            else Console.WriteLine($"The {Color} doesnt need water.");
        }
    }
}

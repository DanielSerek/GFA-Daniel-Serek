using System;
using System.Collections.Generic;
using System.Text;

namespace GardenApplication
{
    class Tree : Plant
    {
        public Tree(string color) : base(color)
        {
            Color = color;
            MinWater = 10;
            Absorption = 0.4f;
            CurrentWater = 0;
        }

        public override void Status()
        {
            if (NeedsWater()) Console.WriteLine($"The {Color} Tree needs water.");
            else Console.WriteLine($"The {Color} Tree doesnt need water.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Garden
{
    /// <summary>
    /// Flower class is a child class of Plant class
    /// </summary>
    class Flower : Plant
    {
        // Constructor for Flowers, defines also minimum water level which a flower needs
        public Flower(string color, float waterLevel) : base(color, waterLevel)
        {
            MinWater = 5f;
        }

        // Print whether the individual item needs watering
        public override void Print()
        {
            if (this.WaterLevel < MinWater)
            {
                Console.WriteLine($"The {Color} Flower needs water");
            }
            else
            {
                Console.WriteLine($"The {Color} Flower doesn't need water");
            }
        }
        // Check whether the current water level is lower than minimum water level, return boolean values
        public override bool CheckWaterNeed()
        {
            if (this.WaterLevel < MinWater) return true;
            else return false;
        }

        // Waters a flower according to the water share for individual plants
        public override void Water(float waterInput)
        {
            WaterLevel += waterInput * 0.75f;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Garden
{
    /// <summary>
    /// Tree class is a child class of Plant class
    /// </summary>
    class Tree : Plant
    {
        // Constructor for Trees, defines also minimum water level which a tree needs
        public Tree(string color, float waterLevel) : base (color, waterLevel)
        {
            MinWater = 10f;
        }

        // Print whether the individual item needs watering
        public override void Print()
        {
            if (this.WaterLevel < MinWater)
            {
                Console.WriteLine($"The {Color} Tree needs water");
            }
            else
            {
                Console.WriteLine($"The {Color} Tree doesn't need water");
            }
        }

        // Check whether the current water level is lower than minimum water level, return boolean values
        public override bool CheckWaterNeed()
        {
            if (this.WaterLevel < MinWater) return true;
            else return false;
        }

        // Waters a tree according to the water share for individual plants
        public override void Water(float waterInput)
        {
            WaterLevel += waterInput * 0.4f;
        }
    }
}

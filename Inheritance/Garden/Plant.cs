using System;
using System.Collections.Generic;
using System.Text;

namespace Garden
{
    /// <summary>
    /// Plant class is a parent class for Flower and Tree
    /// </summary>
    class Plant
    {
        public string Color;
        public float WaterLevel;
        protected float MinWater;

        // Constructor for Plant class
        public Plant(string color, float waterLevel)
        {
            Color = color;
            WaterLevel = waterLevel;
            MinWater = 5f;
        }

        // Print whether the individual item needs watering
        public virtual void Print()
        {
            if (this.WaterLevel < MinWater)
            {
                Console.WriteLine($"The {Color} Plant needs water");
            }
            else
            {
                Console.WriteLine($"The {Color} Plant doesn't need water");
            }
        }

        // Check whether the current water level is lower than minimum water level, return boolean values
        public virtual bool CheckWaterNeed()
        {
            if (this.WaterLevel < MinWater) return true;
            else return false;
        }
        // Waters a plant according to the water share for individual plants
        public virtual void Water(float waterInput)
        {
            WaterLevel += waterInput;
        }

    }
}

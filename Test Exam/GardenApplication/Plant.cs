using System;
using System.Collections.Generic;
using System.Text;

namespace GardenApplication
{
    public abstract class Plant
    {
        public string Color;
        public double CurrentWater;
        public int MinWater;
        public double Absorption;

        public Plant(string color)
        {
            Color = color;
        }

        public bool NeedsWater()
        {
            if (CurrentWater < MinWater) return true;
            else return false;
        }

        public abstract void Status();
    }

    

    
}

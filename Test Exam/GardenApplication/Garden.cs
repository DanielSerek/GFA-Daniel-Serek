using System;
using System.Collections.Generic;
using System.Text;

namespace GardenApplication
{
    class Garden
    {
        public List<Plant> Plants;
        public double Absorption;

        public Garden()
        {
            Plants = new List<Plant>();
        }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }

        public void WaterGarden(int water)
        {
            Console.WriteLine($"Watering with {water}");
            int plantsNeedingWater = 0;

            for (int i = 0; i < Plants.Count; i++)
            {
                if (Plants[i].NeedsWater())
                {
                    plantsNeedingWater++;
                }
            }
            int waterShare = water / plantsNeedingWater;
            for (int i = 0; i < Plants.Count; i++)
            {
                if (Plants[i].NeedsWater())
                {
                    Plants[i].CurrentWater += waterShare * Plants[i].Absorption;
                }
            }
        }

        public void PrintAll()
        {
            foreach (var plant in Plants)
            {
                plant.Status();
            }
        }
        

    }
}

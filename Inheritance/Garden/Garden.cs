using System;
using System.Collections.Generic;
using System.Text;

namespace Garden
{
    class Garden
    {
        // Declaration of the list of plants
        public List<Plant> Plants;

        // Constructor for Garden class, creates a list of Plants
        public Garden()
        {
            Plants = new List<Plant>();
        }

        public void Add(Plant plant)
        {
            Plants.Add(plant);
        }

        // Print status of all plants
        public void PrintAll()
        {
            for (int i = 0; i < Plants.Count; i++)
            {
                Plants[i].Print(); // Print method is declared in classes Plant, Flower and Tree
            }
            Console.WriteLine("\n");
        }

        public void WaterGarden (int waterAmount)
        {
            // Print how much of water is applied on plants
            Console.WriteLine($"Watering with {waterAmount}");

            // Count how many plants need to be watered
            int plantsToBeWatered = 0;
            for (int i = 0; i < Plants.Count; i++)
            {
                if (Plants[i].CheckWaterNeed()) plantsToBeWatered++;  // CheckWaterNeeded method is declared in classes Plant, Flower and Tree
            }
            
            // Calculate amount of water for each plant
            float waterShareForEachPlant;
            if (plantsToBeWatered == 0) waterShareForEachPlant = 0;
            else
            {
                waterShareForEachPlant = waterAmount / plantsToBeWatered;
            }

            // Water the individual plants
            for (int i = 0; i < Plants.Count; i++)
            {
                if (Plants[i].CheckWaterNeed())    
                { 
                    Plants[i].Water(waterShareForEachPlant);   // Water method is declared in classes Plant, Flower and Tree
                }
            }
        }
    }
}

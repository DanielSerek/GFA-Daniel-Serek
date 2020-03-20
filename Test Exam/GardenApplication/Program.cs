using System;

namespace GardenApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Garden myGarden = new Garden();
            
            Plant blue = new Flower("Blue");
            Plant yellow = new Flower("Yellow");
            Plant purple = new Tree("Purple");
            Plant orange = new Tree("Tree");

            myGarden.AddPlant(blue);
            myGarden.AddPlant(yellow);
            myGarden.AddPlant(purple);
            myGarden.AddPlant(orange);

            myGarden.PrintAll();
            Console.WriteLine();

            myGarden.WaterGarden(40);
            myGarden.PrintAll();
            Console.WriteLine();

            myGarden.WaterGarden(70);
            myGarden.PrintAll();
        }
    }
}

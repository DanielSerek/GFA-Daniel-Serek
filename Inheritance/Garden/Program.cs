using System;
using System.Collections.Generic;


namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            Garden garden = new Garden();
            garden.Add(new Flower("yellow", 0));
            garden.Add(new Flower("blue", 0));
            garden.Add(new Tree("purple", 0));
            garden.Add(new Tree("orange", 0));
          
            garden.PrintAll();
            garden.WaterGarden(40);
            garden.PrintAll();
            garden.WaterGarden(70);
            garden.PrintAll();
        }
    }
}

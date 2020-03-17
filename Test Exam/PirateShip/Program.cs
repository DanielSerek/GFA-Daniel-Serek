using System;
using System.Collections.Generic;

namespace PirateShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Pirate Jack = new Captain("Jack", 10, false);
            Pirate pirate1 = new Pirate("Joe", 1, true);
            Pirate pirate2 = new Pirate("Peter", 3, false);
            Pirate pirate3 = new Pirate("Frank", 0, true);
            Pirate pirate4 = new Pirate("Harry", 7, false);
            Pirate pirate5 = new Pirate("James", 3, true);

            Ship ship = new Ship();
            ship.Pirates.Add(Jack);
            ship.Pirates.Add(pirate1);
            ship.Pirates.Add(pirate2);
            ship.Pirates.Add(pirate3);
            ship.Pirates.Add(pirate4);
            ship.Pirates.Add(pirate5);

            List<Pirate> poorPirates = ship.GetPoorPirates();
            foreach (var pirate in poorPirates)
            {
                Console.WriteLine(pirate.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(ship.GetGolds());
            Console.WriteLine();

            ship.PrepareForBattle();
            foreach (var pirate in ship.Pirates)
            {
                Console.WriteLine(pirate.ToString());
            }
            Console.WriteLine(ship.GetGolds());


            ship.LastDayOnTheShip();
            foreach (var pirate in ship.Pirates)
            {
                Console.WriteLine(pirate.ToString());
            }
            Console.WriteLine(ship.GetGolds());
        }
    }
}

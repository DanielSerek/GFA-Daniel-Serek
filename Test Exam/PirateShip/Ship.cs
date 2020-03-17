using System;
using System.Collections.Generic;
using System.Text;

namespace PirateShip
{
    class Ship
    {
        public List<Pirate> Pirates;

        public Ship()
        {
            Pirates = new List<Pirate>();
        }

        public List<Pirate> GetPoorPirates()
        {
            List<Pirate> poorPirates = new List<Pirate>();
            foreach (var pirate in Pirates)
            {
                if (pirate.WoodenLeg && pirate.Gold < 15) poorPirates.Add(pirate);
            }
            return poorPirates;
        }

        public int GetGolds()
        {
            int count = 0;
            foreach (var pirate in Pirates)
            {
                count += pirate.Gold;
            }
            return count;
        }

        public void LastDayOnTheShip()
        {
            foreach (var pirate in Pirates)
            {
                pirate.Party();
            }
        }

        public void PrepareForBattle()
        {
            for (int i = 0; i < 5; i++)
            {
                foreach (var pirate in Pirates)
                {
                    pirate.Work();
                }
            }
            LastDayOnTheShip();
        }
    }

}

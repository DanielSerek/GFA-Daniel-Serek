using System;
using System.Collections.Generic;
using System.Text;

namespace ThePirateShip
{
    class Ship
    {

        #region Properties and constructor
        public string ShipName;
        public Pirate Captain;

        public Ship(string shipName, Pirate captain)
        {
            ShipName = shipName;
            Captain = captain;
        }
        #endregion


        #region Fill a ship 
        /// <summary>
        /// Fill the ship with a captain, a random number of pirates and pirates (objects which are empty)
        /// </summary>
        /// <param name="captainName"></param>
        public void FillShip(Ship ship)
        {
            List<Pirate> pirates = new List<Pirate>();

            // Renders a random value of pirates and assigns it to the ship
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 15);
            

            // Fills the ship with pirates 
            for (int i = 1; i < randomNumber; i++)
            {
                pirates.Add (new Pirate("", ship, 0, false, false)); // !!! This is how to create void pirates !!!
            }

        }

        public void PresentShip()
        {
            Console.WriteLine($"I am {Captain.PirateName} and command pirates on {ShipName}.");
            Console.WriteLine($"{Captain.PirateName} consumed {Captain.RumShots} shots of Rum and " + ((Captain.PassedOut)? "am drunk" : "am sober."));


        }
        #endregion
    }
}

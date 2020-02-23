using System;

namespace ThePirateShip
{
    class Program
    {
        static void Main(string[] args)
        {
             
            Pirate Davy = new Pirate("Davy Jones", null, 0, false, false);
            Pirate Jack = new Pirate("Jack Sparrow", null, 0, false, false);
            Parrot Cotton = new Parrot("Cotton's Parrot");

            Davy.DrinkSomeRum();
            Davy.DrinkSomeRum();
            Davy.HowsItGoingMate();
            Davy.DrinkSomeRum();
            Davy.DrinkSomeRum();
            Davy.DrinkSomeRum();
            Davy.HowsItGoingMate();
            // Davy.Die();
            // Davy.DrinkSomeRum();
            // Davy.HowsItGoingMate();
            Console.WriteLine("\n");

            // Create a ship
            Ship BlackPearl = new Ship("Black Pearl", Jack);
            Ship FlyingDutchman = new Ship("Flying Dutchman", Davy);
            Davy.Ship = FlyingDutchman;
            Jack.Ship = BlackPearl;
            Console.WriteLine(Jack.Ship.ShipName);       // Trochu komplikované

            
   
            // Fill the ship with pirates (the name of the captain is in the bracket)
            BlackPearl.FillShip(BlackPearl);
            FlyingDutchman.FillShip(FlyingDutchman);

            // Present a ship - say the important information about the ship
            BlackPearl.PresentShip();
            



            // Fight between Davy and Jack - the method renders who dies
            Davy.Brawl(Jack);

            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ThePirateShip
{
    class Pirate
    {
        /*DrinkSomeRum() - intoxicates the Pirate some
        HowsItGoingMate() - when called, the Pirate replies, if DrinkSomeRun was called:-
        0 to 4 times, "Pour me anudder!"
        else, "Arghh, I'ma Pirate. How d'ya d'ink its goin?", the pirate passes out and sleeps it off.
        If you manage to get this far, then you can try to do the following.

        Die() - this kills off the pirate, in which case, DrinkSomeRum, etc. just result in he's dead.
        Brawl(x) - where pirate fights another pirate (if that other pirate is alive) and there's a 1/3 chance, 1 dies, the other dies or they both pass out.
        And... if you get that far...

        Add a parrot.*/

        #region class variables and constructor
        public string PirateName;
        public Ship Ship;
        public int RumShots;
        public bool PassedOut;
        public bool Dead;


        /// <summary>
        /// Constructor
        /// </summary>
        public Pirate(string pirateName, Ship ship, int rumshots, bool passedOut, bool dead)
        {
            PirateName = pirateName;
            Ship = ship;
            RumShots = rumshots;
            PassedOut = passedOut;
            Dead = dead;
        }
        #endregion

        #region drink Rum
        /// <summary>
        /// Lets pirate drink some Rum
        /// </summary>
        public void DrinkSomeRum()
        {
            if (this.Dead) Console.WriteLine($"The pirate {this.PirateName} is dead and can't drink any longer.");
            else
            {
                this.RumShots++;
                Console.WriteLine($"The pirate {this.PirateName} drank {this.RumShots} shots.");
            }
        }
        #endregion

        #region ask how the pirate is doing
        /// <summary>
        /// Asks a pirate how he is doing
        /// </summary>
        public void HowsItGoingMate()
        {
            if (this.Dead) Console.WriteLine($"The pirate {this.PirateName} is dead and you can't ask him.");
            else
            {
                if (this.RumShots <= 4) Console.WriteLine("Pour me anudder!");
                else
                {
                    Console.WriteLine("Arghh, I'ma Pirate. How d'ya d'ink its goin?");
                    this.PassedOut = true;
                }
            }
        }
        #endregion

        #region kill the pirate
        /// Let the called pirate die 
        public void Die()
        {
            this.Dead = true;
        }
        #endregion

        #region fight between two pirates
        /// <summary>
        /// Calls a fight between two pirates
        /// </summary>
        /// <param name="pirate"></param>
        public void Brawl(Pirate pirate)
        {
            Console.WriteLine($"Fight between {this.PirateName} and {pirate.PirateName}.");
            
            // Renders a random value to define who wins/loses
            Random rnd = new Random();
            int i = rnd.Next(1, 4);

            switch(i)
            {
                case 1:   // Your pirate died
                    this.Dead = true;
                    Console.WriteLine($"{this.PirateName} died.");
                    break;
                case 2:   // The other pirate died
                    pirate.Dead = true;
                    Console.WriteLine($"{pirate.PirateName} died.");
                    break;
                case 3:   // Both pirates died
                    pirate.Dead = true;
                    this.Dead = true;
                    Console.WriteLine("Both pirates died.");
                    break;
            }

        }
        #endregion


    }
}

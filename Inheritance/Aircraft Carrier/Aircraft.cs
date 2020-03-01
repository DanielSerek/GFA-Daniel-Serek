using System;
using System.Collections.Generic;
using System.Text;

namespace Aircraft_Carrier
{
    // The aircraft is a parent class of carrier
    public class Aircraft 
    {
        internal string AircraftName;
        internal int MaxAmmo;
        internal int BaseDamage;
        internal int CurrentAmmo;
        internal int AllDamage;

        // Constructor of the aircraft class 
        //public Aircraft(string aircraftName, int maxAmmo, int baseDamage, int currentAmmo, int allDamage) 
        //{
        //    AircraftName = aircraftName;
        //    MaxAmmo = maxAmmo;
        //    BaseDamage = baseDamage;
        //    CurrentAmmo = currentAmmo;
        //    AllDamage = allDamage;
        //}

        public Aircraft()
        {
        }

        // Returns damage caused by an individual aircraft
        public int Fight()
        {
            int damageDealt = CurrentAmmo * BaseDamage;
            CurrentAmmo = 0;
            AllDamage += damageDealt;
            return damageDealt;
        }

        // Refills an aircraft with the load and returns the remaining storage capacity
        public int Refill(int load)
        {
            // If the load is higher than aircraft MaxAmmo, I can fully load the aircraft
            if (load > MaxAmmo && CurrentAmmo <= 0)
            {
                CurrentAmmo += MaxAmmo;
                Console.WriteLine($"The {AircraftName} was fully loaded.");
                return load - MaxAmmo;
            }
            // If the load is lower than aircraft MaxAmmo, I load what I have in the variable load
            else if (load < MaxAmmo && CurrentAmmo <= 0)
            {
                CurrentAmmo += load;
                Console.WriteLine($"The {AircraftName} was loaded with {load} ammo.");
                return 0;
            }
            else return load;
        }

        // Returns the type of the aircraft as a string
        public string GetModel()
        {
            return AircraftName;
        }

        // Returns status of the aircraft as a string
        public string GetStatus()
        {
            Console.WriteLine("\n");
            return "Type " + AircraftName + ", Ammo: "
                   + CurrentAmmo + ", Base Damage: " + BaseDamage + ", All Damage: " + AllDamage;
        }

        // Returns if the aircraft is priority in the ammo fill queue
        public bool IsPriority()
        {
            if (CurrentAmmo == 0) return true;
            else return false;
        }

        /// <summary>
        /// Makes all aircrafts in the carrier free of ammo
        /// </summary>
        /// <param name="squadron"></param>
        public void ClearSquadronAmmo(List<Aircraft> squadron)
        {
            for (int i = 0; i < squadron.Count; i++)
            {
                squadron[i].CurrentAmmo = 0;
            }
        }
    }
}

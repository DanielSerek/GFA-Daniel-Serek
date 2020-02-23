using System;
using System.Collections.Generic;
using System.Text;

namespace Aircraft_Carrier
{   
    
    public class Carrier 
    {
        internal List<Aircraft> Aircrafts; 
        internal string CarrierName;
        internal int HP;
        internal int AmmoStorage;


        internal int TotalDamage
        {
            get
            {
                int damage = 0;
                for (int i = 0; i < Aircrafts.Count; i++)
                {
                    damage += Aircrafts[i].AllDamage;
                }
                return damage;
            }
        }

        // Construtor of the Carrier class
        public Carrier(string carrierName, int healthPoints, int ammoStorage) 
        {
            Aircrafts = new List<Aircraft>();
            CarrierName = carrierName;
            HP = healthPoints;
            AmmoStorage = ammoStorage;
        }


        /// <summary>
        /// Add an aircraft to its storage    
        /// </summary>
        /// <param name="aircraft"></param>
        public void Add(Aircraft aircraft)
        {
            Aircrafts.Add(aircraft);
        }


        /// <summary>
        /// Fight between aircrafts of the two carriers
        /// </summary>
        /// <param name="enemy"></param>
        public string FightBetweenCarriers(Carrier enemy)
        {
            // Checking whether player or enemy are alive
            if (this.HP <= 0) return "\nYou had already been destroyed!";
            else if (enemy.HP <= 0) return "\nYou can't kill dead ones!";

            // Check whether at least one squadron has ammo
            if (!CheckSquadronAmmo(this.Aircrafts) && !CheckSquadronAmmo(enemy.Aircrafts))
            {
                return "\nNo ammo, no fun! You both have no ammunition";
            }
            
            Console.WriteLine($"\nFight between {this.CarrierName} and {enemy.CarrierName} rages on!!!");

            // Deduction of damage caused to the player and enemy
            enemy.HP -= this.CalculateDamage();  
            this.HP -= enemy.CalculateDamage();
            Console.WriteLine($"Your HP is: {this.HP} and enemies HP is: {enemy.HP}. " +
                $"Your aircrafts caused {this.CalculateDamage()} and enemies aircrafts caused {enemy.CalculateDamage()} damage");

            // Clear all ammunition from the aircrafts
            ClearSquadronAmmo(enemy.Aircrafts);
            ClearSquadronAmmo(this.Aircrafts);


            // Checking whether you or enemy was destroyed
            if (enemy.HP <= 0) return $"Congratulations, you destroyed that bitch! {enemy.CarrierName}";
            if (this.HP <= 0) return "It's dead Jim";

            // Informing about who won the fight
            if ((enemy.CalculateDamage() < this.CalculateDamage())) return "You beated the enemy.";
            else if ((enemy.CalculateDamage() >= this.CalculateDamage())) return "The enemy beated you.";
            else return "The loss on both sides was equal. No winner";
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


        /// <summary>
        /// Check whether the carriers squadron has some ammo
        /// </summary>
        /// <param name="squadron"></param>
        /// <returns></returns>
        public bool CheckSquadronAmmo(List<Aircraft> squadron)
        {
            for (int i = 0; i < squadron.Count; i++)
            {
                if (squadron[i].CurrentAmmo != 0) return true;
            }
            return false;
        }


        /// <summary>
        /// Calculate damage caused by an individual carrier - could be defined using get in property or at least the method simplified?
        /// </summary>
        /// <returns></returns>
        public int CalculateDamage()
        {
            int damage = 0;
            for (int i = 0; i < Aircrafts.Count; i++)
            {
                damage += Aircrafts[i].BaseDamage * Aircrafts[i].CurrentAmmo; 
            }
            return damage;
        }


        /// <summary>
        /// Fills the aircraft with ammo and subtracts the needed ammo from the ammo storage
        /// </summary>
        public void Fill()
        {
            Console.WriteLine($"\nCarrier {CarrierName} is loading aircrafts...");
            try
            {
                // Throws an exception if CurrentAmmo <= 0
                if (AmmoStorage <= 0)
                {
                    throw new Exception($"No ammo left in the carrier {CarrierName}.");
                }

                // Fills priority aircrafts first 
                int i = 0;
                do
                {
                    if (Aircrafts[i].IsPriority()) AmmoStorage = Aircrafts[i].Refill(AmmoStorage); // Refills aircraft and returns the remanining AmmoStorage after loading
                    i++;
                } while (AmmoStorage > 0 && i < (Aircrafts.Count));

                // Fill the rest of the aircrafts, if any ammo is still available
                if (AmmoStorage > 0)
                {
                    for (int j = 0; j < Aircrafts.Count; j++)
                    {
                        if (!Aircrafts[j].IsPriority()) AmmoStorage = Aircrafts[j].Refill(AmmoStorage);
                    }
                }
                Console.WriteLine($"The remaining ammo storage is {AmmoStorage}.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }
        }


    }
}

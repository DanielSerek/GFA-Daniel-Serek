using System;
using System.Collections.Generic;
using System.Text;

namespace PirateShip
{
    public class Pirate
    {
        public string Name;
        public int Gold;
        public int HP;
        public bool WoodenLeg;

        public Pirate(string name, int gold, bool woodenLeg)
        {
            Name = name;
            Gold = gold;
            WoodenLeg = woodenLeg;
            HP = 10;
        }
        public virtual void Work()
        {
            Gold += 1;
            HP -= 1;
        }

        public virtual void Party()
        {
            HP += 1;
        }

        public override string ToString()
        {
            if (WoodenLeg) return $"Hello, I'm {Name}. I have a wooden leg and {Gold} golds.";
            else return $"Hello, I'm {Name}. I still have my real legs and {Gold} golds.*/";
        }
    }
}

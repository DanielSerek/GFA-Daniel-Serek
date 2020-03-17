using System;
using System.Collections.Generic;
using System.Text;

namespace PirateShip
{
    public class Captain : Pirate
    {
        public Captain(string name, int gold, bool woodenLeg) : base(name, gold, woodenLeg)
        {
        }

        public override void Work()
        {
            Gold += 5;
            HP -= 5;
        }

        public override void Party()
        {
            HP += 10;
        }
    }
}

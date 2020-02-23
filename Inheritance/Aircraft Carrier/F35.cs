using System;
using System.Collections.Generic;
using System.Text;

namespace Aircraft_Carrier
{
    class F35 : Aircraft
    {
        // Constructor for F35
        public F35() : base()
        {
            AircraftName = "F35";
            MaxAmmo = 12;
            BaseDamage = 50;
            CurrentAmmo = 0;
        }
    }
}

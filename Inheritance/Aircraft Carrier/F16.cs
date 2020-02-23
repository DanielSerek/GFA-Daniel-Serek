using System;
using System.Collections.Generic;
using System.Text;

namespace Aircraft_Carrier
{
    class F16 : Aircraft
    {
        // Constructor for F16
        public F16() : base()
        {
            AircraftName = "F16";
            MaxAmmo = 8;
            BaseDamage = 30;
            CurrentAmmo = 0;

        }

    }
}

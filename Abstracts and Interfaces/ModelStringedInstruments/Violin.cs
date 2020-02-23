using System;
using System.Collections.Generic;
using System.Text;

namespace ModelStringedInstruments
{
    class Violin : StringedInstrument
    {
        internal Violin()
        {
            instrumentName = "Violin"; 
            instrumentSound = "Screech";
            numberOfStrings = 4;
        }

        internal Violin(int stringsNumber)
        {
            instrumentName = "Violin"; 
            instrumentSound = "Screech";
            numberOfStrings = stringsNumber;
        }
        internal override int Sound()
        {
            return numberOfStrings;
        }
    }
}

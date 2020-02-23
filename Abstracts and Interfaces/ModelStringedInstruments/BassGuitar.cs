using System;
using System.Collections.Generic;
using System.Text;

namespace ModelStringedInstruments
{
    class BassGuitar : StringedInstrument
    {
        public BassGuitar()
        {
            instrumentName = "Bass Guitar"; 
            instrumentSound = "Duum-duum-duum";
            numberOfStrings = 4;
        }

        public BassGuitar(int stringsNumber)
        {
            instrumentName = "Bass Guitar";
            instrumentSound = "Duum-duum-duum";
            numberOfStrings = stringsNumber;
        }

        internal override int Sound()
        {
            return numberOfStrings;
        }
    }
}

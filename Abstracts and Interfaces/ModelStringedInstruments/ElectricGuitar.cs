using System;
using System.Collections.Generic;
using System.Text;

namespace ModelStringedInstruments
{
    internal class ElectricGuitar : StringedInstrument
    {
        public ElectricGuitar()
        {
            instrumentName = "Electric Guitar";
            instrumentSound = "Twang";
            numberOfStrings = 6;
        }
        public ElectricGuitar(int stringsNumber)
        {
            instrumentName = "Electric Guitar";
            instrumentSound = "Twang";
            numberOfStrings = stringsNumber;
        }
        internal override int Sound()
        {
            return numberOfStrings;
        }
    }
}

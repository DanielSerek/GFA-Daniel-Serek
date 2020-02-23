using System;
using System.Collections.Generic;
using System.Text;

namespace ModelStringedInstruments
{
    public abstract class StringedInstrument : Instrument
    {
        internal int numberOfStrings;

        internal abstract int Sound();

        internal override void Play()
        {
            Console.WriteLine($"{instrumentName}, a {this.Sound()}-stringed instrument that {instrumentSound}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ModelStringedInstruments
{
    public abstract class Instrument
    {
        internal string instrumentName;
        internal string instrumentSound;

        internal abstract void Play();
        
    }
}

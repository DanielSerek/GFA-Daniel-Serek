using System;
using System.Collections.Generic;
using System.Text;

namespace FleetOfThings
{
    public class Thing
    {
        private string name;
        private bool completed;

        public Thing(string name)
        {
            this.name = name;
        }

        public void Complete()
        {
            completed = true;
        }
    }
}

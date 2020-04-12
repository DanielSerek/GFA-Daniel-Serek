using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer
{
    public class Loot
    {
        public Position Position;
        public string Type;

        public Loot(Position position, string type)
        {
            Position = position;
            Type = type;
        }
    }
}

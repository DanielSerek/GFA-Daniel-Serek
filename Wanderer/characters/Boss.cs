using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer.characters
{
    class Boss : Character
    {
        public Boss(int posX, int posY, Map map, Drawer drawer, string id) : base(posX, posY, map, drawer, id)
        {
        }
    }
}

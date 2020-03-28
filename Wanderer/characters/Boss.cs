using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer.characters
{
    class Boss : Character
    {
        public Boss(int posX, int posY, Map map, Drawer drawer, string id) : base(posX, posY, map, drawer, id)
        {
            Random random = new Random();
            CurrentHP = 2 * GameControl.Level * random.Next(7) + random.Next(7);
            DP = GameControl.Level / 2 * random.Next(7) + random.Next(7) / 2;
            SP = GameControl.Level * random.Next(7) + GameControl.Level;
        }
    }
}

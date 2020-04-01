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
            MaxHP = 2 * GameControl.Level * random.Next(1, 7) + random.Next(1, 7);
            CurrentHP = MaxHP;
            DP = GameControl.Level / 2 * random.Next(1, 7) + random.Next(1, 7) / 2;
            SP = GameControl.Level * random.Next(1, 7) + GameControl.Level;
        }
    }
}

using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer
{
    public static class GameControl
    {
        public static int Level;
        


        static GameControl()
        {
            Level = 1;
        }

        
        
        public static void Battle(Character player, Character enemy)
        {
            if (enemy == null) return;

            int SV = 0;
            Random random = new Random();
            do
            {
                // Strike by a player
                SV = player.SP + 2 * random.Next(7);
                if (SV > enemy.DP) enemy.CurrentHP -= SV - enemy.DP;
                //if (!enemy.CheckCurrentHP()) break;

                // Strike by an enemy
                SV = enemy.SP + 2 * random.Next(7);
                if (SV > player.DP) player.CurrentHP -= SV - player.DP;
            } while (player.CurrentHP > 0 && enemy.CurrentHP > 0);

            player.CheckCurrentHP();
            enemy.CheckCurrentHP();
        }

    }
}

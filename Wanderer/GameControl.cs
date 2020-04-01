using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wanderer.characters;

namespace Wanderer
{
    public class GameControl
    {
        public static int Level;

        public Character player = null;
        public Character boss = null;
        public List<Character> skeletons = new List<Character>();

        private Map Map;
        private Drawer Drawer; // Dá se nějak vyhnout použití draweru? Potřebuji jej ale pro vykreslování skeletonů...

        public GameControl(Map map, Drawer drawer)
        {
            Level = 1;
            Map = map;
            Drawer = drawer;
            GeneratePlayer();
            GenerateSkeletons(3);
            GenerateBoss();
        }

        public void GeneratePlayer()
        {
            int x, y;
            Map.FindFreeCell(out x, out y);
            player = new Player(x, y, Map, Drawer, "player");
            Drawer.DrawImage(player, Drawer.ImgType.HeroDown);
        }

        public void GenerateSkeletons(int num)
        {
            // Generate skeletons 
            int x, y;
            for (int i = 0; i < num; i++)
            {
                // Find an empty random cell in the map
                do
                {
                    Map.RandomCell(out x, out y);
                } while (CheckCollissions(x, y));
                // Add Skeleton to the list of Skeletons
                skeletons.Add(new Skeleton(x, y, Map, Drawer, "skeleton" + i.ToString()));
                // Set Skeleton initial direction
                while (!skeletons[i].CheckDirection())
                {
                    skeletons[i].GenerateDirection();
                }
                Drawer.DrawImage("skeleton" + i.ToString(), Drawer.ImgType.Skeleton, x, y);
            }
        }

        public void GenerateBoss()
        {
            // Generate a boss
            int x, y;
            do
            {
                Map.RandomCell(out x, out y);
            } while (CheckCollissions(x, y));
            boss = new Boss(x, y, Map, Drawer, "boss");
            Drawer.DrawImage(boss, Drawer.ImgType.Boss);
        }

        public void MainWindow_Key(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    player.Move(Character.Direction.West);
                    SkeletonsMove();
                    break;
                case Key.Right:
                    player.Move(Character.Direction.East);
                    SkeletonsMove();
                    break;
                case Key.Up:
                    player.Move(Character.Direction.North);
                    SkeletonsMove();
                    break;
                case Key.Down:
                    player.Move(Character.Direction.South);
                    SkeletonsMove();
                    break;
                case Key.Space:
                    Battle(player, GetCharacter());
                    break;
            }
            Drawer.UpdateStatusText(player);
            CheckStatus();
        }



        // Check free place in the map, not to create two skeletons on the same tile
        private bool CheckCollissions(int x, int y)
        {
            bool collision = false;
            for (int i = 0; i < skeletons.Count; i++)
            {
                if (skeletons[i].PosX == x && skeletons[i].PosY == y)
                {
                    collision = true;
                }
                if (player.PosX == x && player.PosY == y)
                {
                    collision = true;
                }
            }
            return collision;
        }

        public void SkeletonsMove()
         {
            for (int i = 0; i < skeletons.Count; i++)
            {
                ((Skeleton)skeletons[i]).MoveSkeleton();
            }
        }

        // Get the character on the position where a player is
        public Character GetCharacter()
        {
            foreach (var skeleton in skeletons)
            {
                if (player.PosX == skeleton.PosX && player.PosY == skeleton.PosY) return skeleton;
            }
            if (player.PosX == boss.PosX && player.PosY == boss.PosY) return boss;
            return null;
        }

        public void Battle(Character player, Character enemy)
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

            if (player.CurrentHP <= 0) player.RemoveImage();
            if (enemy.CurrentHP <= 0 && enemy is Skeleton)
            {
                enemy.RemoveImage();
                skeletons.Remove(enemy);
            }
            if (enemy.CurrentHP <= 0 && enemy is Boss)
            {
                enemy.RemoveImage();
                boss = null;
            }
        }
        // Checks if conditions for next level were met and sets a new level
        private void CheckStatus()
        {
            if (skeletons.Count == 0 && boss == null)
            {
                Level++;
                GenerateSkeletons(Level + 2);
                GenerateBoss();

                Random random = new Random();
                int rnd = random.Next(1, 101);
                if (rnd <= 10) player.CurrentHP += player.MaxHP;
                if (rnd > 10 && rnd <= 40) player.CurrentHP += player.MaxHP / 3;
                if (rnd > 50) player.CurrentHP += player.MaxHP / 10;
            }
        }
    }
}

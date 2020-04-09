using System;
using System.Collections.Generic;
using Wanderer.characters;

namespace Wanderer
{
    public class GameControl
    {
        public static int Level;
        private bool levelPreparation = false;

        public Character Player = null;
        public Character Boss = null;
        public List<Character> Skeletons = new List<Character>();

        private Map map;
        private Drawer drawer; 

        public GameControl(Map map, Drawer drawer)
        {
            Level = 1;
            this.map = map;
            this.drawer = drawer;
            GenerateNewPlayer();
            GenerateBoss();
            GenerateSkeletons(3);
        }

        private void GenerateNewPlayer()
        {
            int x, y;
            map.FindFreeCell(out x, out y);
            Player = new Player(x, y, map, drawer, this, "Player");
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        private void GeneratePlayer()
        {
            int x, y;
            map.FindFreeCell(out x, out y);
            Player.PosX = x;
            Player.PosY = y;
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        private void GenerateSkeletons(int num)
        {
            // Generate Skeletons 
            int x, y;
            num = 1;
            for (int i = 0; i < num; i++)
            {
                // Find an empty random cell in the map
                do
                {
                    map.RandomCell(out x, out y);
                } while (CheckCollissions(x, y));

                // Add Skeleton to the list of Skeletons
                Skeletons.Add(new Skeleton(x, y, map, drawer, this, "Skeleton" + i.ToString()));
                // Set Skeleton initial direction
                while (!Skeletons[i].CheckDirection())
                {
                    if (!Skeletons[i].GenerateDirection()) break;
                }
                drawer.DrawImage("Skeleton" + i.ToString(), Drawer.ImgType.Skeleton, x, y);
                ((Skeleton)Skeletons[i]).NavigateEnemyToPlayer(Player, map);
            }
            
        }

        private void GenerateBoss()
        {
            // Generate a Boss
            int x, y;
            do
            {
                map.RandomCell(out x, out y);
            } while (CheckCollissions(x, y));
            Boss = new Boss(x, y, map, drawer, this, "Boss");
            drawer.DrawImage(Boss, Drawer.ImgType.Boss);
        }

        public void PlayerMove()
        {
            if (Player == null) return;
            Player.Move(Player.Dir);
        }

        public void BattlePlayer()
        {
            Battle(Player, GetCharacter());
        }

        public void ShowStatus()
        {
            drawer.UpdateStatusText(StatusText());
        }


        private string StatusText()
        {
            return $"Level: {Level}\nHealth Points: {Player.CurrentHP} / {Player.MaxHP}";
        }


        // Check free place in the map, not to create two Skeletons on the same tile
        private bool CheckCollissions(int x, int y)
        {
            bool collision = false;
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].PosX == x && Skeletons[i].PosY == y)
                {
                    collision = true;
                }
                if (Player.PosX == x && Player.PosY == y)
                {
                    collision = true;
                }
            }
            return collision;
        }

        public void DefinePathsForSkeletons()
        {
            for (int i = 0; i < Skeletons.Count; i++)
            {
                ((Skeleton)Skeletons[i]).NavigateEnemyToPlayer(Player, map);
            }
        }

        public void MoveSkeletons()
        {
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (((Skeleton)Skeletons[i]).PathPositions.Count <= 0) ((Skeleton)Skeletons[i]).NavigateEnemyToPlayer(Player, map);
                ((Skeleton)Skeletons[i]).SetDirection();
                Skeletons[i].Move(Skeletons[i].Dir);
            }
        }

        // Get the character on the position where a Player is
        private Character GetCharacter()
        {
            foreach (var skeleton in Skeletons)
            {
                if (StandingNext(skeleton)) return skeleton;
            }
            if (Boss == null) return null;
            if (StandingNext(Boss)) return Boss;
            return null;
        }

        private bool StandingNext(Character ch)
        {
            if (((Player.PosX == ch.PosX - 1) || (Player.PosX == ch.PosX + 1)) && (Player.PosY == ch.PosY)) return true;
            if (((Player.PosY == ch.PosY - 1) || (Player.PosY == ch.PosY + 1)) && (Player.PosX == ch.PosX)) return true;
            else return false;
        }

        private bool FacingTowardsEnemy(Character ch)
        {
            if ((Player.Dir == Character.Direction.East) && (ch.PosX == Player.PosX + 1)) return true;
            if ((Player.Dir == Character.Direction.West) && (ch.PosX == Player.PosX - 1)) return true;
            if ((Player.Dir == Character.Direction.North) && (ch.PosY == Player.PosY - 1)) return true;
            if ((Player.Dir == Character.Direction.South) && (ch.PosY == Player.PosY + 1)) return true;
            return false;
        }


        private void Battle(Character Player, Character enemy)
        {
            if (enemy == null) return;
            if (!FacingTowardsEnemy(enemy)) return; 
            int SV = 0;
            Random random = new Random();
            do
            {
                // Strike by a Player
                SV = Player.SP + 2 * random.Next(7);
                if (SV > enemy.DP) enemy.CurrentHP -= SV - enemy.DP;
                if (enemy.CurrentHP <= 0) break;

                // Strike by an enemy
                SV = enemy.SP + 2 * random.Next(7);
                if (SV > Player.DP) Player.CurrentHP -= SV - Player.DP;
            } while (Player.CurrentHP > 0 && enemy.CurrentHP > 0);

            if (Player.CurrentHP <= 0) Player.RemoveImage();
            if (enemy.CurrentHP <= 0 && enemy is Skeleton)
            {
                enemy.RemoveImage();
                Skeletons.Remove(enemy);
            }
            if (enemy.CurrentHP <= 0 && enemy is Boss)
            {
                enemy.RemoveImage();
                Boss = null;
            }
        }

        // Checks if conditions for next level were met and sets a new level
        public void CheckStatus()
        {
            if (levelPreparation)
            {
                CreateNewLevel();
                return;
            }
            if (Skeletons.Count == 0 && Boss == null)
            {
                drawer.Loading();
                levelPreparation = true;
                return;
            }
            if (Player.CurrentHP <= 0)
            {
                drawer.GameOver();
                //TODO: Pause and a new game
            }
        }

        private void CreateNewLevel()
        {
            Level++;
            levelPreparation = false;
            Skeletons.Clear();
            drawer.Images.Clear();
            map.GenerateMap(58);
            GenerateSkeletons(Level + 2);
            GenerateBoss();
            GeneratePlayer();

            Random random = new Random();
            int rnd = random.Next(1, 101);
            if (rnd <= 10) Player.CurrentHP = Player.MaxHP;
            if (rnd > 10 && rnd <= 40) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 3;
            if (rnd > 50) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 10;
        }
    }
}

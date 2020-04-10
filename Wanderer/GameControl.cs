using System;
using System.Collections.Generic;
using Wanderer.characters;

namespace Wanderer
{
    public class GameControl
    {
        public static int Level;
        public Character Player = null;
        public Character Boss = null;
        public List<Skeleton> Skeletons = new List<Skeleton>();
        private Map map;
        private Drawer drawer;
        private bool levelPreparation = false;

        public GameControl(Map map, Drawer drawer)
        {
            Level = 1;
            this.map = map;
            this.drawer = drawer;
            GeneratePlayer();
            GenerateBoss();
            GenerateSkeletons(3);
        }

        private void GeneratePlayer()
        {
            int x, y;
            map.RandomFreeCell(out x, out y);
            Player = new Player(x, y, map, drawer, this, "Player");
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        // Generate the player in next levels
        private void PlacePlayer()
        {
            int x, y;
            map.RandomFreeCell(out x, out y);
            Player.PosX = x;
            Player.PosY = y;
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        private void GenerateSkeletons(int num)
        {
            // Generate Skeletons 
            int x, y;
            //num = 1;  //FOR TESTING PURPOSES
            for (int i = 0; i < num; i++)
            {
                // Find an empty random cell in the map
                do
                {
                    map.RandomFreeCell(out x, out y);
                } while (CheckCollissions(x, y));

                // Add Skeleton to the list of Skeletons
                Skeletons.Add(new Skeleton(x, y, map, drawer, this, "Skeleton" + i.ToString()));
                // Set Skeleton initial direction
                //while (!Skeletons[i].CheckDirection())
                //{
                //    if (!Skeletons[i].GenerateDirection()) break;
                //}
                drawer.DrawImage("Skeleton" + i.ToString(), Drawer.ImgType.Skeleton, x, y);
                (Skeletons[i]).NavigateEnemyToPlayer(Player, map);
            }
            
        }

        private void GenerateBoss()
        {
            // Generate a Boss
            int x, y;
            do
            {
                map.RandomFreeCell(out x, out y);
            } while (CheckCollissions(x, y));
            Boss = new Boss(x, y, map, drawer, this, "Boss");
            drawer.DrawImage(Boss, Drawer.ImgType.Boss);
        }

        public void PlayerMove()
        {
            if (Player == null) return;
            Player.Move(Player.Dir);
        }

        // Fight between a player and an enemy
        public void FightPlayer()
        {
            Fight(Player, GetCharacter());
        }

        // Update status about the player
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
                (Skeletons[i]).NavigateEnemyToPlayer(Player, map);
            }
        }

        public void MoveSkeletons()
        {
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].PathPositions.Count <= 0) 
                    Skeletons[i].NavigateEnemyToPlayer(Player, map);
                Skeletons[i].MoveSkeleton();
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
        
        // Check if someone is standing next to the player
        private bool StandingNext(Character ch)
        {
            if (((Player.PosX == ch.PosX - 1) || (Player.PosX == ch.PosX + 1)) && (Player.PosY == ch.PosY)) return true;
            if (((Player.PosY == ch.PosY - 1) || (Player.PosY == ch.PosY + 1)) && (Player.PosX == ch.PosX)) return true;
            else return false;
        }

        public bool IsCellFree(int x, int y)
        {
            if (Player.PosX == x && Player.PosY == y) return false;
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].PosX == x && Skeletons[i].PosY == y) return false;
            }
            if (Boss != null && Boss.PosX == x && Boss.PosY == y) return false;
            return true;
        }

        // Check if player is facing towards the enemy
        private bool FacingTowardsEnemy(Character ch)
        {
            if ((Player.Dir == Character.Direction.East)  && (ch.PosX == Player.PosX + 1)) return true;
            if ((Player.Dir == Character.Direction.West)  && (ch.PosX == Player.PosX - 1)) return true;
            if ((Player.Dir == Character.Direction.North) && (ch.PosY == Player.PosY - 1)) return true;
            if ((Player.Dir == Character.Direction.South) && (ch.PosY == Player.PosY + 1)) return true;
            return false;
        }

        // Fight between the player and the enemy
        private void Fight(Character Player, Character enemy)
        {
            if (enemy == null) return;
            if (!FacingTowardsEnemy(enemy)) return; 
            int SV = 0; // Strike Value used in the loop
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
                Skeletons.Remove((Skeleton)enemy);
            }
            if (enemy.CurrentHP <= 0 && enemy is Boss)
            {
                enemy.RemoveImage();
                Boss = null;
            }
        }

        // Checks if conditions for the next level were met and sets a new level
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
            }
            // TODO: Pause
        }

        private void CreateNewLevel()
        {
            Level++;
            levelPreparation = false;
            Skeletons.Clear();
            drawer.Images.Clear();
            map.CreateMap(58);
            GenerateSkeletons(2 + Level);
            GenerateBoss();
            PlacePlayer();

            // Player's healing between levels
            Random random = new Random();
            int rnd = random.Next(1, 101);
            if (rnd <= 10) Player.CurrentHP = Player.MaxHP;
            if (rnd > 10 && rnd <= 40) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 3;
            if (rnd > 50) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 10;
        }
    }
}

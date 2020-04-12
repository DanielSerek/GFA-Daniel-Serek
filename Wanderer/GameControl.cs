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
        public List<Loot> Loots = new List<Loot>();
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
            Player.PosX = -1;
            Player.PosY = -1;
            // Find an empty random cell in the map
            do
            {
                map.RandomFreeCell(out x, out y);
            } while (CheckCollissions(x, y));
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

        // Player attacks an enemy
        public void AttackEnemy()
        {
            Fight(Player, GetCharacter());
        }

        // Enemy attacks a player
        public void AttackPlayer()
        {
            Fight(GetCharacter(), Player);
        }

        // If a player is close to the boss, he attacks player
        public void BossAttacks()
        {
            if (StandingNext((Character)Boss))
            {
                Fight(Boss, Player);
            }
            
            if (Skeletons.Count < 1)
            {
                Boss.NavigateEnemyToPlayer(Player, map);
                ((Boss)Boss).MoveBoss();
            }
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
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].PosX == x && Skeletons[i].PosY == y) return true;
            }
            if (Player.PosX == x && Player.PosY == y) return true;
            if (Boss != null && (Boss.PosX == x && Boss.PosY == y)) return true;
            return false;
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
                if (StandingNext(Skeletons[i])) AttackPlayer(); //TODO: Create separate methods = Attack player, Attack enemy
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
            else if (((Player.PosY == ch.PosY - 1) || (Player.PosY == ch.PosY + 1)) && (Player.PosX == ch.PosX)) return true;
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
        private void Fight(Character attacker, Character defender)
        {
            if (defender == null) return;
            if (attacker is Player && !FacingTowardsEnemy(defender)) return;
            int SV = 0; // Strike Value
            Random random = new Random();
         
            // Strike by the attacker
            SV = attacker.SP + 2 * random.Next(7);
            if (SV > defender.DP)
            {
                // if (attacker is Skeleton || attacker is Boss) drawer.RedScreen();
                defender.CurrentHP -= SV - defender.DP;
            }

            if (defender.CurrentHP < 1 && defender is Player) Player.RemoveImage();
            if (defender.CurrentHP < 1 && defender is Skeleton)
            {
                defender.RemoveImage();
                RenderReward(defender);
                Skeletons.Remove((Skeleton)defender);
            }
            if (defender.CurrentHP < 1 && defender is Boss)
            {
                defender.RemoveImage();
                Boss = null;
            }
        }

        private void RenderReward(Character defender)
        {
            Random random = new Random();
            int rnd = random.Next(100);
            if(rnd < 100)
            {
                Loots.Add(new Loot(new Position(defender.PosX, defender.PosY), "firstAid"));
                drawer.DrawImage("Loot" + defender.Id.Substring(defender.Id.Length - 1), Drawer.ImgType.FirstAid, defender.PosX, defender.PosY);
            }
        }

        //public void GrabLoot()
        //{
        //    if(Player.PosX == Loots[i].Position)
        //    {
        //        do...
        //    }
        //}

        // Checks if conditions for the next level were met and sets a new level
        public void CheckStatus()
        {
            if (levelPreparation)
            {
                CreateNewLevel();
                return;
            }
            if (Skeletons.Count < 1 && Boss == null)
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
            MainWindow.GameSpeed *= 0.9; //Makes movemment of skeletons faster
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
            if (rnd > 10 && rnd <= 40) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 2;
            if (rnd > 50) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 5;
        }
    }
}

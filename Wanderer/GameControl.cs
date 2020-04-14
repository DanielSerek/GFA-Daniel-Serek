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
            Position pos = map.RandomFreeCell();
            Player = new Player(pos, map, drawer, this, "Player");
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        // Generate the player in next levels
        private void PlacePlayer()
        {
            Player.Position.X = -1;
            Player.Position.Y = -1;
            // Find an empty random cell in the map
            Position pos;
            do
            {
                pos = map.RandomFreeCell();
            } while (CheckCollissions(pos));
            Player.Position = pos;
            drawer.DrawImage(Player, Drawer.ImgType.HeroDown);
        }

        private void GenerateSkeletons(int num)
        {
            // Generate Skeletons 
            Position pos;
            //num = 1;  //FOR TESTING PURPOSES
            for (int i = 0; i < num; i++)
            {
                // Find an empty random cell in the map
                do
                {
                    pos = map.RandomFreeCell();
                } while (CheckCollissions(pos));

                // Add Skeleton to the list of Skeletons
                Skeletons.Add(new Skeleton(pos, map, drawer, this, "Skeleton" + i.ToString()));
                // Set Skeleton initial direction
                //while (!Skeletons[i].CheckDirection())
                //{
                //    if (!Skeletons[i].GenerateDirection()) break;
                //}
                drawer.DrawImage("Skeleton" + i.ToString(), Drawer.ImgType.Skeleton, pos);
                (Skeletons[i]).NavigateEnemyToPlayer(Player, map);
            }
        }

        private void GenerateBoss()
        {
            // Generate a Boss
            Position pos;
            do
            {
                pos = map.RandomFreeCell();
            } while (CheckCollissions(pos));
            Boss = new Boss(pos, map, drawer, this, "Boss");
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
        private bool CheckCollissions(Position position)
        {
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].Position == position) return true;
            }
            if (Player.Position == position) return true;
            if (Boss != null && (Boss.Position == position)) return true;
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
                if (StandingNext(Skeletons[i])) AttackPlayer(); 
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
            if (Player == null) return false;
            if (((Player.Position.X == ch.Position.X - 1) || (Player.Position.X == ch.Position.X + 1)) && (Player.Position.Y == ch.Position.Y)) return true;
            else if (((Player.Position.Y == ch.Position.Y - 1) || (Player.Position.Y == ch.Position.Y + 1)) && (Player.Position.X == ch.Position.X)) return true;
            else return false;
        }

        public bool IsCellFree(Position position)
        {
            if (Player.Position.X == position.X && Player.Position.Y == position.Y) return false;
            for (int i = 0; i < Skeletons.Count; i++)
            {
                if (Skeletons[i].Position.X == position.X && Skeletons[i].Position.Y == position.Y) return false;
            }
            if (Boss != null && Boss.Position.X == position.X && Boss.Position.Y == position.Y) return false;
            return true;
        }

        // Check if player is facing towards the enemy
        private bool FacingTowardsEnemy(Character ch)
        {
            if ((Player.Dir == Character.Direction.East)  && (ch.Position.X == Player.Position.X + 1)) return true;
            if ((Player.Dir == Character.Direction.West)  && (ch.Position.X == Player.Position.X - 1)) return true;
            if ((Player.Dir == Character.Direction.North) && (ch.Position.Y == Player.Position.Y - 1)) return true;
            if ((Player.Dir == Character.Direction.South) && (ch.Position.Y == Player.Position.Y + 1)) return true;
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
                defender.CurrentHP -= SV - defender.DP;
                if (attacker is Skeleton || attacker is Boss) drawer.RedScreen();
            }

            if (defender.CurrentHP < 1 && defender is Player)
            {
                defender.CurrentHP = 0;
                drawer.UpdateStatusText(StatusText());
                Player.RemoveImage();
            }
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
            if(rnd < 50)
            {
                Loots.Add(new Loot(defender.Position, "firstAid" + defender.Id.Substring(defender.Id.Length - 1)));
                drawer.DrawImage("firstAid" + defender.Id.Substring(defender.Id.Length - 1), Drawer.ImgType.FirstAid, defender.Position);
            }
            if(rnd >= 50 && rnd < 80)
            {
                Loots.Add(new Loot(defender.Position, "armour" + defender.Id.Substring(defender.Id.Length - 1)));
                drawer.DrawImage("armour" + defender.Id.Substring(defender.Id.Length - 1), Drawer.ImgType.Armour, defender.Position);
            }
            if (rnd >= 80 && rnd < 100)
            {
                Loots.Add(new Loot(defender.Position, "weapon" + defender.Id.Substring(defender.Id.Length - 1)));
                drawer.DrawImage("weapon" + defender.Id.Substring(defender.Id.Length - 1), Drawer.ImgType.Armour, defender.Position);
            }
        }

        public void GrabLoot()
        {
            Random random = new Random(); 
            for (int i = 0; i < Loots.Count; i++)
            {
                if (Player.Position.X == Loots[i].Position.X && Player.Position.Y == Loots[i].Position.Y)
                {
                    drawer.RemoveImage(Loots[i]);
                    if(Loots[i].Id.Contains("firstAid"))
                    {
                        int rnd = random.Next(1, 101);
                        if (rnd <= 10) Player.CurrentHP = Player.MaxHP;
                        if (rnd > 10 && rnd <= 40) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 2;
                        if (rnd > 50) Player.CurrentHP += (Player.MaxHP - Player.CurrentHP) / 5;
                    }
                    if (Loots[i].Id.Contains("armour"))
                    {
                        int rnd = random.Next(1, 101);      // TODO IMPROVE ACCORDING TO THE PROBABILITIES
                        Player.DP += (rnd * Player.DP) / 500;
                    }
                    if (Loots[i].Id.Contains("weapon"))
                    {
                        int rnd = random.Next(1, 101);
                        Player.SP += (rnd * Player.SP) / 500;
                    }
                    Loots.RemoveAt(i);
                }
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
            if (Skeletons.Count < 1 && Boss == null)
            {
                drawer.Loading();
                levelPreparation = true;
                return;
            }
            if (Player.CurrentHP <= 0)
            {
                Player = null;
                MainWindow.Timer.Stop();
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
            drawer.AvaloniaRedDownLock = false;
        }
    }
}

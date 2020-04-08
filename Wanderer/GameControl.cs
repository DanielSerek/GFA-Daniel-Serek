using System;
using System.Collections.Generic;
using Wanderer.characters;

namespace Wanderer
{
    public class GameControl
    {
        public static int Level;
        private bool levelPreparation = false;

        public Character player = null;
        public Character boss = null;
        public List<Character> skeletons = new List<Character>();

        private Map Map;
        private Drawer Drawer; 

        public GameControl(Map map, Drawer drawer)
        {
            Level = 1;
            Map = map;
            Drawer = drawer;
            GenerateNewPlayer();
            GenerateBoss();
            GenerateSkeletons(3);
        }

        private void GenerateNewPlayer()
        {
            int x, y;
            Map.FindFreeCell(out x, out y);
            player = new Player(x, y, Map, Drawer, this, "player");
            Drawer.DrawImage(player, Drawer.ImgType.HeroDown);
        }

        private void GeneratePlayer()
        {
            int x, y;
            Map.FindFreeCell(out x, out y);
            player.PosX = x;
            player.PosY = y;
            Drawer.DrawImage(player, Drawer.ImgType.HeroDown);
        }

        private void GenerateSkeletons(int num)
        {
            // Generate skeletons 
            int x, y;
            num = 1; // TO BE DELETED

            for (int i = 0; i < num; i++)
            {
                // Find an empty random cell in the map
                do
                {
                    Map.RandomCell(out x, out y);
                } while (CheckCollissions(x, y));

                // Add Skeleton to the list of Skeletons
                skeletons.Add(new Skeleton(x, y, Map, Drawer, this, "skeleton" + i.ToString()));
                // Set Skeleton initial direction
                while (!skeletons[i].CheckDirection())
                {
                    if (!skeletons[i].GenerateDirection()) break;
                }
                Drawer.DrawImage("skeleton" + i.ToString(), Drawer.ImgType.Skeleton, x, y);
            }
        }

        private void GenerateBoss()
        {
            // Generate a boss
            int x, y;
            do
            {
                Map.RandomCell(out x, out y);
            } while (CheckCollissions(x, y));
            boss = new Boss(x, y, Map, Drawer, this, "boss");
            Drawer.DrawImage(boss, Drawer.ImgType.Boss);
        }

        public void PlayerMove()
        {
            if (player == null) return;
            player.Move(player.Dir);

            //CheckStatus();
        }

        //  gameControl.Battle(gameControl.player, gameControl.GetCharacter());
        public void BattlePlayer()
        {
            Battle(player, GetCharacter());
        }

        public void ShowStatus()
        {
            Drawer.UpdateStatusText(StatusText());
        }


        private string StatusText()
        {
            return $"Level: {Level}\nHealth Points: {player.CurrentHP} / {player.MaxHP}";
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
                NavigateEnemyToPlayer(skeletons[i]);
                skeletons[i].Move(skeletons[i].Dir);
                //if (player.PosX != skeletons[i].PosX || player.PosY != skeletons[i].PosY) ((Skeleton)skeletons[i]).MoveSkeleton();
            }
        }

        // Get the character on the position where a player is
        private Character GetCharacter()
        {
            foreach (var skeleton in skeletons)
            {
                if (StandingNext(skeleton)) return skeleton;
            }
            if (boss == null) return null;
            if (StandingNext(boss)) return boss;
            return null;
        }

        private bool StandingNext(Character ch)
        {
            if (((player.PosX == ch.PosX - 1) || (player.PosX == ch.PosX + 1)) && (player.PosY == ch.PosY)) return true;
            if (((player.PosY == ch.PosY - 1) || (player.PosY == ch.PosY + 1)) && (player.PosX == ch.PosX)) return true;
            else return false;
        }

        private bool FacingTowardsEnemy(Character ch)
        {
            if ((player.Dir == Character.Direction.East) && (ch.PosX == player.PosX + 1)) return true;
            if ((player.Dir == Character.Direction.West) && (ch.PosX == player.PosX - 1)) return true;
            if ((player.Dir == Character.Direction.North) && (ch.PosY == player.PosY - 1)) return true;
            if ((player.Dir == Character.Direction.South) && (ch.PosY == player.PosY + 1)) return true;
            return false;
        }


        private void Battle(Character player, Character enemy)
        {
            if (enemy == null) return;
            if (!FacingTowardsEnemy(enemy)) return; 
            int SV = 0;
            Random random = new Random();
            do
            {
                // Strike by a player
                SV = player.SP + 2 * random.Next(7);
                if (SV > enemy.DP) enemy.CurrentHP -= SV - enemy.DP;
                if (enemy.CurrentHP <= 0) break;

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
        public void CheckStatus()
        {
            if (levelPreparation)
            {
                CreateNewLevel();
                return;
            }
            if (skeletons.Count == 0 && boss == null)
            {
                Drawer.Loading();
                levelPreparation = true;
                return;
            }
            if (player.CurrentHP <= 0)
            {
                Drawer.GameOver();
                //TODO: Pause and a new game
            }
        }

        private void CreateNewLevel()
        {
            Level++;
            levelPreparation = false;
            skeletons.Clear();
            Drawer.Images.Clear();
            Map.GenerateMap(58);
            GenerateSkeletons(Level + 2);
            GenerateBoss();
            GeneratePlayer();

            Random random = new Random();
            int rnd = random.Next(1, 101);
            if (rnd <= 10) player.CurrentHP = player.MaxHP;
            if (rnd > 10 && rnd <= 40) player.CurrentHP += (player.MaxHP - player.CurrentHP) / 3;
            if (rnd > 50) player.CurrentHP += (player.MaxHP - player.CurrentHP) / 10;
        }

        public void NavigateEnemyToPlayer(Character ch)
        {
            //if (player.PosX >= ch.PosX) ch.Dir = Character.Direction.East;
            //if (player.PosX <= ch.PosX) ch.Dir = Character.Direction.West;
            //if (player.PosY <= ch.PosY) ch.Dir = Character.Direction.North;
            //if (player.PosY >= ch.PosY) ch.Dir = Character.Direction.South;

            // Player X Y
            // ch X Y
            PathFinder pathFinder = new PathFinder();
            int goToX, goToY;
            pathFinder.PathFinding(ch.PosX, ch.PosY, player.PosX, player.PosY, Map, out goToX, out goToY);

            if (goToX > ch.PosX) ch.Dir = Character.Direction.East;
            if (goToX < ch.PosX) ch.Dir = Character.Direction.West;
            if (goToY > ch.PosY) ch.Dir = Character.Direction.South;
            if (goToY < ch.PosY) ch.Dir = Character.Direction.North;
        }

        

    }
}

using System;

namespace Wanderer
{
    abstract public class Character
    {
        public enum Direction
        {
            North,
            South,
            West,
            East
        }

        public int PosX;
        public int PosY;
        public Direction Dir;
        public int MaxHP;
        public int CurrentHP;
        public int DP;
        public int SP;

        protected Drawer Drawer;
        private Map Map;
        protected GameControl GameControl;

        public string Id { get; private set; }

        public Character(int posX, int posY, Map map, Drawer drawer, GameControl gameControl, string id)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Map = map;
            this.Drawer = drawer;
            GameControl = gameControl;
        }

        public virtual void Move(Direction dir)
        {
            if (dir == Direction.North && CheckTileOccupancy(PosX, PosY - 1)) PosY--;
            if (dir == Direction.South && CheckTileOccupancy(PosX, PosY + 1)) PosY++;
            if (dir == Direction.West && CheckTileOccupancy(PosX - 1, PosY)) PosX--;
            if (dir == Direction.East && CheckTileOccupancy(PosX + 1, PosY)) PosX++;
        }

        public bool CheckDirection()
        {
            if (Dir == Direction.North && CheckTileOccupancy(PosX, PosY - 1)) return true;
            else if (Dir == Direction.South && CheckTileOccupancy(PosX, PosY + 1)) return true;
            else if (Dir == Direction.West && CheckTileOccupancy(PosX - 1, PosY)) return true;
            else if (Dir == Direction.East && CheckTileOccupancy(PosX + 1, PosY)) return true;
            else return false;
        }

        private bool CheckTileOccupancy(int x, int y)
        {
            if (Map.GetTile(x, y) == Map.TileType.Wall) return false;
            if (GameControl.Player.PosX == x && GameControl.Player.PosY == y) return false;
            for (int i = 0; i < GameControl.Skeletons.Count; i++)
            {
                if (GameControl.Skeletons[i].PosX == x && GameControl.Skeletons[i].PosY == y) return false;
            }
            if (GameControl.Boss != null && GameControl.Boss.PosX == x && GameControl.Boss.PosY == y) return false;
            return true;
        }

        // TODO: Create a method which won't make the Skeleton go back
        //public void CheckPossibleOtherDirection()
        //{
        //    if (Dir == Direction.North || Dir == Direction.South
        //        && (Map.GetTile(PosX - 1, PosY) == Map.TileType.Floor || Map.GetTile(PosX + 1, PosY) == Map.TileType.Floor)) GenerateDirection();
        //    if (Dir == Direction.West || Dir == Direction.East
        //        && (Map.GetTile(PosX, PosY - 1) == Map.TileType.Floor || Map.GetTile(PosX, PosY + 1) == Map.TileType.Floor)) GenerateDirection();
        //}

        public bool GenerateDirection()
        {
            Random random = new Random();
            int rnd;
            int count = 0;
            do
            {
                rnd = random.Next(4);
                // Parsing number back to Enum
                this.Dir = (Direction)rnd;
                count++;
                if (count == 10) return false;
            } while (!CheckDirection());
            return true;
        }

        public bool RemoveImage()
        {
            bool alive = true;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                Drawer.RemoveImage(this);
                alive = false;
                Drawer.Images.Remove(this.Id);
            }
            return alive;
        }

        
    }
}

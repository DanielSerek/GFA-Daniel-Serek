using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
        
        public string Id { get; private set; }

        public Character(int posX, int posY, Map map, Drawer drawer, string id )            
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            Map = map;
            this.Drawer = drawer;
        }

        public virtual void Move(Direction dir)
        {
            if (dir == Direction.North && Map.GetTile(PosX, PosY - 1) == Map.TileType.Floor) PosY--;
            if (dir == Direction.South && Map.GetTile(PosX, PosY + 1) == Map.TileType.Floor) PosY++;
            if (dir == Direction.West && Map.GetTile(PosX - 1, PosY) == Map.TileType.Floor) PosX--;
            if (dir == Direction.East && Map.GetTile(PosX + 1, PosY) == Map.TileType.Floor) PosX++;
        }

        public bool CheckDirection()
        {
            if (Dir == Direction.North && Map.GetTile(PosX, PosY - 1) == Map.TileType.Wall) return false;
            else if (Dir == Direction.South && Map.GetTile(PosX, PosY + 1) == Map.TileType.Wall) return false;
            else if (Dir == Direction.West && Map.GetTile(PosX - 1, PosY) == Map.TileType.Wall) return false;
            else if (Dir == Direction.East && Map.GetTile(PosX + 1, PosY) == Map.TileType.Wall) return false;
            else return true;
        }

        // TODO: Create a method which won't make the Skeleton go back
        public void CheckPossibleOtherDirection()
        {
            if (Dir == Direction.North || Dir == Direction.South 
                && (Map.GetTile(PosX - 1, PosY) == Map.TileType.Floor || Map.GetTile(PosX + 1, PosY) == Map.TileType.Floor)) GenerateDirection();
            if (Dir == Direction.West || Dir == Direction.East
                && (Map.GetTile(PosX, PosY - 1) == Map.TileType.Floor || Map.GetTile(PosX, PosY + 1) == Map.TileType.Floor)) GenerateDirection();
        }

        public void GenerateDirection()
        {
            Random random = new Random();
            int rnd;
            do
            {
                rnd = random.Next(4);
                // Parsing number back to Enum
                this.Dir = (Direction)rnd;
            } while (!CheckDirection());
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
                if (this is Player)
                {
                    Drawer.GameOver();
                }
            }
            return alive;
        }
    }
}

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

        public string Id { get; private set; }

        protected Drawer Drawer;
        private Map Map;


        public Character(int posX, int posY, Map map, Drawer drawer, string id )            // , string imagePath
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

        internal void CheckDirection()
        {
            throw new NotImplementedException();
        }

    }
}

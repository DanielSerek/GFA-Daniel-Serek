using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
        //private FoxDraw FoxDraw;
        private Drawer Drawer;
        private Map Map;
        private IBitmap Image = new Avalonia.Media.Imaging.Bitmap(@"../../../img/hero-down.png");


        public Character(int posX, int posY, Map map, Drawer drawer)
        {
            PosX = posX;
            PosY = posY;
            Map = map;
            Drawer = drawer;
        }

        public virtual void Move(Direction dir)
        {
            if (dir == Direction.North  && ((Map.GameMap[PosX][PosY - 1] != 1))) PosY--;
            if (dir == Direction.South  && ((Map.GameMap[PosX][PosY + 1] != 1))) PosY++;
            if (dir == Direction.West   && ((Map.GameMap[PosX - 1][PosY] != 1))) PosX--;
            if (dir == Direction.East   && ((Map.GameMap[PosX + 1][PosY] != 1))) PosX++;

            Image player = new Image();
            Drawer.DrawCell(player, Map.PicSize, Image, PosX, PosY);
        }

    }
}

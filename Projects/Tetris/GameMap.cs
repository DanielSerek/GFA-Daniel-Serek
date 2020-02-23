using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    //Hold all the information about the contents and size of the game map
    class GameMap
    {
        private DrawerUtil Drawer;
        private int SizeX;
        private int SizeY;
        private bool[,] Map; //info where the cells are filled

        public GameMap(DrawerUtil drawer, int sizeX, int sizeY)
        {
            Drawer = drawer;
            SizeX = sizeX;
            SizeY = sizeY;
            Map = new bool[sizeX, sizeY];
        }

        //Checking if the map has any potentionaly colliding stuff at this position
        public bool IsPresent(int x, int y)
        {
            //Virtually filling the whole outside world with blocks
            if (x < 0 || y < 0 ||
                x > SizeX - 1 || y > SizeY - 1) return true;
            //Checking if the inside has some stuff in this position
            return Map[x, y];
        }

        public void SetCellToFilled(int x, int y)
        {
            if (x < 0 || y < 0 || x > SizeX - 1 || y > SizeY - 1) return;
            Map[x, y] = true;
        }

        public void Draw()
        {
            //Draws the game area outline
            Drawer.DrawOutline(0, 0, SizeX, SizeY);
            //Loop through all the cells in the map
            for (int i = 0; i < Map.GetLength(0); i++) //Map.GetLength(0) -> horizontal size
            {
                for (int j = 0; j < Map.GetLength(1); j++) //Map.GetLength(1) -> vertical size
                {
                    //If a cell is present at the current position
                    if(Map[i, j])
                    {
                        //Draw the cell here
                        Drawer.DrawCell(i, j, Colors.Pink);
                    }
                }
            }
        }
    }
}

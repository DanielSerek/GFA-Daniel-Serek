using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    //Represents the playable block element
    class Block
    {
        //Possible movement directions
        public enum Direction
        {
            Right,
            Left,
            Down,
        }

        private DrawerUtil Drawer; //Used to easily drow filled cells
        private int PosX; //Position of the top left cell of the moving block
        private int PosY;
        //Something like a moving "mini-map" inside of the game map
        private bool[,] Cells; //Holds all (4x4) shape information about the block

        public Block(DrawerUtil drawer, int posX, int posY, bool[,] cells)
        {
            Drawer = drawer;
            PosX = posX;
            PosY = posY;
            Cells = cells;
        }

        //Note: this function is currently not used anymore GameMap.IsPresent is used instead
        //Checking if any part of the body of the block is on this location or not
        public bool IsPresent(int x, int y) //Note: x, y is in game map coordinate system!!
        {
            //Ruling out the coordinate points outside of the "mini-map"
            if (x < PosX     || y < PosY ||
                x > PosX + 3 || y > PosY + 3) return false;
            //Checking if the inside has some "meat" in this position
            return Cells[x - PosX, y - PosY];
        }

        //Checks the whole "mini-map" with the game map if there are any intersections
        public bool CheckCollision(GameMap map)
        {
            //Looping through all the cells
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    //If our dear block has any "meat" at this position
                    //AND the map also has stuff here
                    if (Cells[i, j] && map.IsPresent(i + PosX, j + PosY))
                    {
                        //Then there is a collision 
                        return true;
                    }
                }
            }
            //If no collisions found anywhere, there is none
            return false;
        }

        //Create a list of all the content in this block
        //Listing coordinate pairs in game map coordinate system
        public List<Tuple<int, int>> GetCellContent()
        {
            var ret = new List<Tuple<int, int>>();
            //Looping through all the cells
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j])
                    {
                        ret.Add(new Tuple<int, int>(i + PosX, j + PosY));
                    }
                }
            }
            return ret;
        }

        //Moving the block by changing its position coordinates
        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:  PosY++; break;
                case Direction.Left:  PosX--; break;
                case Direction.Right: PosX++; break;
            }
        }

        //Clone myself in a neighbouring location
        public Block CreateMoved(Direction dir)
        {
            Block other = new Block(Drawer, PosX, PosY, Cells);
            other.Move(dir);
            return other;
        }

        //Draw the content of this "mini-map" (aka the Block)
        public void Draw()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j])
                    {
                        //Relative position in the actual game map
                        //Measured from the top left corner of the whole game map
                        Drawer.DrawCell(PosX + i, PosY + j, Colors.Green);
                    }
                }
            }
        }
    }
}

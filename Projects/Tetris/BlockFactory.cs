using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    //To create tetris valid Block objects
    class BlockFactory
    {
        //Possible types of tetris valid blocks 
        public enum Type
        {
            Square,
            LPiece,
            Line,
            Zigzag,
            TPiece
        }

        //Block object builder function
        public static Block CreateBlock(DrawerUtil drawer, Type type, int x, int y)
        {
            var cells = new bool[4, 4];
            switch (type)
            {
                case Type.Square:
                    {
                        cells[0, 0] = true;
                        cells[0, 1] = true;
                        cells[1, 0] = true;
                        cells[1, 1] = true;
                    }
                    break;
                case Type.LPiece:
                    {
                        cells[0, 0] = true;
                        cells[0, 1] = true;
                        cells[1, 0] = true;
                        cells[0, 2] = true;
                    }
                    break;
                case Type.Line:
                    {
                        cells[0, 0] = true;
                        cells[0, 1] = true;
                        cells[0, 2] = true;
                        cells[0, 3] = true;
                    }
                    break;
                case Type.TPiece:
                    {
                        cells[0, 0] = true;
                        cells[1, 0] = true;
                        cells[2, 0] = true;
                        cells[1, 1] = true;
                    }
                    break;
                case Type.Zigzag:
                    {
                        cells[1, 0] = true;
                        cells[2, 0] = true;
                        cells[0, 1] = true;
                        cells[1, 1] = true;
                    }
                    break;
            }
            return new Block(drawer, x, y, cells);
        }

        public static Block CreateBlockRandom(DrawerUtil drawer, int x, int y)
        {
            Random rnd = new Random();
            Type type = (Type)rnd.Next(0, 4);
            return CreateBlock(drawer, type, x, y);
        }
    }
}

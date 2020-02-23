using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    //Drawing abstraction for all game specific drawing stuff
    class DrawerUtil
    {
        FoxDraw DrawObj; //Actual drawing utility functions from syllabus
        int CellSize;
        int MapStartX;
        int MapStartY;

        public DrawerUtil(FoxDraw drawObj, int cellSize, int mapStartX, int mapStartY)
        {
            DrawObj = drawObj;
            CellSize  = cellSize;
            MapStartX = mapStartX;
            MapStartY = mapStartY;
        }

        //Draw a cell on the game coordinate system
        public void DrawCell(int x, int y, Color col)
        {
            DrawObj.SetFillColor(col);
            DrawObj.DrawRectangle(MapStartX + x * CellSize,
                                  MapStartY + y * CellSize,
                                  CellSize, CellSize);
        }

        //Outline of the game area
        public void DrawOutline(int x1, int y1, int x2, int y2)
        {
            DrawObj.SetFillColor(Colors.Gray);
            DrawObj.DrawRectangle(MapStartX + x1 * CellSize, MapStartY + y1 * CellSize,
                                  CellSize * (x2 - x1), CellSize * (y2 - y1));
        }
    }
}

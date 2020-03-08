using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace Wanderer
{
    public class Drawer
    {
        FoxDraw DrawObj; //Actual drawing utility functions from syllabus
        //int CellSize;
        //int MapStartX;
        //int MapStartY;

        public Drawer(FoxDraw drawObj)
        {
            DrawObj = drawObj;
            //CellSize = cellSize;
            //MapStartX = mapStartX;
            //MapStartY = mapStartY;
        }

        public void DrawCell(List<List<Image>> images, int picSize, IBitmap type, int x, int y) 
        {
            images[x][y].Source = type;
            DrawObj.AddImage(images[x][y], x * picSize, y * picSize);
        }
    }
}

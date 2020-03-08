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
        // Is it a good place for IBitmap? Can I use Enum?
        public IBitmap Floor = new Avalonia.Media.Imaging.Bitmap(@"../../../img/floor.png");
        public IBitmap Wall = new Avalonia.Media.Imaging.Bitmap(@"../../../img/wall.png");
        private IBitmap Character = new Avalonia.Media.Imaging.Bitmap(@"../../../img/hero-down.png");

        public Drawer(FoxDraw drawObj)
        {
            DrawObj = drawObj;
            //CellSize = cellSize;
            //MapStartX = mapStartX;
            //MapStartY = mapStartY;
        }

        public void DrawCell(Image image, int picSize, IBitmap type, int x, int y) 
        {
            image.Source = type;
            DrawObj.AddImage(image, x * picSize, y * picSize);
        }
    }
}

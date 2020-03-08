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

        public void DrawMap(int size, int x, int y) 
        {
            // TODO: Put in a class tile using Enum
            IBitmap Floor = new Avalonia.Media.Imaging.Bitmap(@"../../../img/floor.png");
            IBitmap Wall = new Avalonia.Media.Imaging.Bitmap(@"../../../img/wall.png");


            // Generate the list of images objects
            List<List<Image>> images = new List<List<Image>>();
            for (int i = 0; i < size; i++)
            {
                images.Add(new List<Image>());
                for (int j = 0; j < size; j++)
                {
                    images[i].Add(new Avalonia.Controls.Image());
                }
            }

            // Print the map
            int picSize = 72;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    images[i][j].Source = Floor;
                    DrawObj.AddImage(images[i][j], i * picSize, j * picSize);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Text;

namespace Wanderer
{
    public class Map
    {
        
        public void DrawMap(int size, Canvas canvas)
        {
            var foxDraw = new FoxDraw(canvas);

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
                    images[i][j].Source = Floor;
                }
            }

            // Print the map
            int picSize = 72;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    foxDraw.AddImage(images[i][j], i * picSize, j * picSize);
                }
            }
        }
    }
}

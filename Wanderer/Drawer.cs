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
        public int PicSize = 72;

        // TODO: private???
        internal Canvas canvas;

        public Drawer( Canvas canvas )
        {
            this.canvas = canvas;
        }

        public void Draw(Image image, int xMap, int yMap)
        {
            xMap *= PicSize;
            yMap *= PicSize;

            Canvas.SetLeft(image, xMap);
            Canvas.SetTop(image, yMap);
        }
    }
}

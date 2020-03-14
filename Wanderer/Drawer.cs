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
        public enum ImgType
        {
            Floor,
            Wall,
            HeroDown
        }

        internal Canvas canvas;
        public int PicSize = 72;
        private int Left;
        private int Top;
        private Dictionary<ImgType, Bitmap> Resources;
        private static string ImagePath = @"../../../img/";

        public Drawer(Canvas canvas, int picsize, int left, int top)
        {
            this.canvas = canvas;
            PicSize = picsize;
            Left = left;
            Top = top;
            Resources = new Dictionary<ImgType, Bitmap>();

            Load();
        }

        private void Load()
        {
            Resources.Add(ImgType.Floor, new Avalonia.Media.Imaging.Bitmap(ImagePath + "floor.png"));
            Resources.Add(ImgType.Wall, new Avalonia.Media.Imaging.Bitmap(ImagePath + "wall.png"));
            Resources.Add(ImgType.HeroDown, new Avalonia.Media.Imaging.Bitmap(ImagePath + "hero-down.png"));
        }

        public void DrawImage(ImgType type, int xMap, int yMap)
        {
            Image image = new Avalonia.Controls.Image();
            image.Source = Resources[type];
            Canvas.SetLeft(image, Left + xMap * PicSize);
            Canvas.SetTop(image, Top + yMap * PicSize);
            canvas.Children.Add(image);

            //xMap *= PicSize;
            //yMap *= PicSize;

            //Canvas.SetLeft(image, xMap);
            //Canvas.SetTop(image, yMap);
        }

        public void ClearCanvas()
        {
            canvas.Children.Clear();
        }
    }
}

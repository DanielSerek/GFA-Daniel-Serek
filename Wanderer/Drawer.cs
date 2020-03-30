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
            HeroDown,
            HeroUp,
            HeroLeft,
            HeroRight,
            Skeleton,
            Boss
        }

        internal Canvas canvas;
        public int PicSize = 72;
        private int Left;
        private int Top;
        private Dictionary<ImgType, Bitmap> Resources;
        private static string ImagePath = @"../../../img/";
        public Dictionary<string, Image> Images; // Dictionary is used to call different Image objects
        private TextBlock tb; 

        public Drawer(Canvas canvas, int picsize, int left, int top)
        {
            this.canvas = canvas;
            PicSize = picsize;
            Left = left;
            Top = top;
            Resources = new Dictionary<ImgType, Bitmap>();
            Images = new Dictionary<string, Image>();

            Load();
            TextBlockDisplay();
        }

        private void Load()
        {
            Resources.Add(ImgType.Floor, new Avalonia.Media.Imaging.Bitmap(ImagePath + "floor.png"));
            Resources.Add(ImgType.Wall, new Avalonia.Media.Imaging.Bitmap(ImagePath + "wall.png"));
            Resources.Add(ImgType.HeroDown, new Avalonia.Media.Imaging.Bitmap(ImagePath + "hero-down.png"));
            Resources.Add(ImgType.HeroUp, new Avalonia.Media.Imaging.Bitmap(ImagePath + "hero-up.png"));
            Resources.Add(ImgType.HeroLeft, new Avalonia.Media.Imaging.Bitmap(ImagePath + "hero-left.png"));
            Resources.Add(ImgType.HeroRight, new Avalonia.Media.Imaging.Bitmap(ImagePath + "hero-right.png"));
            Resources.Add(ImgType.Skeleton, new Avalonia.Media.Imaging.Bitmap(ImagePath + "skeleton.png"));
            Resources.Add(ImgType.Boss, new Avalonia.Media.Imaging.Bitmap(ImagePath + "boss.png"));
        }

        private void TextBlockDisplay()
        {
            tb = new Avalonia.Controls.TextBlock();
            tb.FontSize = 20;
            //tb.Foreground = SolidColorBrush.Parse("#ffffff");
            canvas.Children.Add(tb);
            Canvas.SetTop(tb, 730);
            Canvas.SetLeft(tb, 10);
        }

        public void DrawImage(string imageName, ImgType type, int xMap, int yMap)
        {
            Image image = new Avalonia.Controls.Image();
            Images.Add(imageName, image);
            image.Source = Resources[type];
            Canvas.SetLeft(image, Left + xMap * PicSize);
            Canvas.SetTop(image, Top + yMap * PicSize);
            canvas.Children.Add(image);
        }

        public void DrawImage(Character ch, ImgType type)
        {
            Image image = new Avalonia.Controls.Image();
            Images.Add( ch.Id, image);
            image.Source = Resources[type];
            Canvas.SetLeft(image, Left + ch.PosX * PicSize);
            Canvas.SetTop(image, Top + ch.PosY * PicSize);
            canvas.Children.Add(image);
        }

        public void MoveImage(Character ch, ImgType type)
        {
            Image image = Images[ch.Id];
            image.Source = Resources[type];
            Canvas.SetLeft(image, Left + ch.PosX * PicSize);
            Canvas.SetTop(image, Top + ch.PosY * PicSize);
        }

        public void RemoveImage(Character ch)
        {
            canvas.Children.Remove(Images[ch.Id]);
        }

        public void UpdateStatusText(Character player)
        {
            tb.Text = $"Player:\nHealth Points: {player.CurrentHP}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Wanderer.characters;


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
            if (Images.ContainsKey(ch.Id))
            {
                Image image = Images[ch.Id];
                image.Source = Resources[type];
                Canvas.SetLeft(image, Left + ch.PosX * PicSize);
                Canvas.SetTop(image, Top + ch.PosY * PicSize);
            }
        }

        public void RemoveImage(Character ch)
        {
            if (!(ch is Player) || !(ch is Boss))
            {
                canvas.Children.Remove(Images[ch.Id]);
                Images.Remove(ch.Id);
            }
        }

        public void UpdateStatusText(string input)
        {
            tb.Text = input;
        }

        public void GameOver()
        {
            TextBlock textblock = CenterText("game over", SetColor(255, 0, 0), Darken(156));
            canvas.Children.Add(textblock);
        }

        public void Loading()
        {
            TextBlock textblock = CenterText("LOADING...", SetColor(255, 0, 0), Darken(156));
            canvas.Children.Add(textblock);
        }

        private TextBlock CenterText(string text, SolidColorBrush foreground, SolidColorBrush background)
        {
            var output = new TextBlock();

            output.Text = text.ToUpper();
            output.TextAlignment = TextAlignment.Center;
            output.Foreground = foreground;
            output.Background = background;
            output.FontWeight = FontWeight.Black;
            output.FontSize = 80;
            output.Width = 720;
            output.Height = 120;
            Canvas.SetTop(output, 320);
            return output;
        }

        private SolidColorBrush SetColor(byte r, byte g, byte b)
        {
            return new SolidColorBrush(new Color(255, r, g, b));
        }

        private SolidColorBrush Darken(byte a)
        {
            return new SolidColorBrush(new Color(a, 0, 0, 0));
        }
    }
}

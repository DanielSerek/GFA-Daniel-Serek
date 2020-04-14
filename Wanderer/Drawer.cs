using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Threading;
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
            Boss,
            FirstAid,
            Armour,
            Weapon
        }

        public Canvas Canvas;
        public int PicSize = 72;
        public Dictionary<string, Image> Images; // Dictionary is used to call different Image objects
        private int left;
        private int top;
        private Dictionary<ImgType, Bitmap> resources;
        private static string imagePath = @"../../../img/";
        private TextBlock tb;

        // Variables used in RedScreen method
        private byte opacity;
        private bool redDown;
        public bool AvaloniaRedDownLock; // Not to display more images on Canvas
        Rectangle rectangle = new Rectangle()
        {
            Width = 720,
            Height = 800,
        };
        DispatcherTimer Timer = new DispatcherTimer();


        public Drawer(Canvas canvas, int picsize, int left, int top)
        {
            Canvas = canvas;
            PicSize = picsize;
            this.left = left;
            this.top = top;
            resources = new Dictionary<ImgType, Bitmap>();
            Images = new Dictionary<string, Image>();
            Load();
            TextBlockDisplay();
            Timer.Tick += Timer_RedColor;
            Timer.Interval = TimeSpan.FromMilliseconds(1);
        }

        // Load all pictures into resources Dictionary
        private void Load()
        {
            resources.Add(ImgType.Floor,    new Bitmap(imagePath + "floor.png"));
            resources.Add(ImgType.Wall,     new Bitmap(imagePath + "wall.png"));
            resources.Add(ImgType.HeroDown, new Bitmap(imagePath + "hero-down.png"));
            resources.Add(ImgType.HeroUp,   new Bitmap(imagePath + "hero-up.png"));
            resources.Add(ImgType.HeroLeft, new Bitmap(imagePath + "hero-left.png"));
            resources.Add(ImgType.HeroRight,new Bitmap(imagePath + "hero-right.png"));
            resources.Add(ImgType.Skeleton, new Bitmap(imagePath + "skeleton.png"));
            resources.Add(ImgType.Boss,     new Bitmap(imagePath + "boss.png"));
            resources.Add(ImgType.FirstAid, new Bitmap(imagePath + "firstaid.png"));
            resources.Add(ImgType.Armour,   new Bitmap(imagePath + "armour.png"));
            resources.Add(ImgType.Weapon, new Bitmap(imagePath + "weapon.png"));
        }

        // The method is used to display player's status
        private void TextBlockDisplay()
        {
            tb = new TextBlock();
            tb.FontSize = 20;
            Canvas.Children.Add(tb);
            Canvas.SetTop(tb, 610);
            Canvas.SetLeft(tb, 10);
        }

        public void DrawImage(string imageName, ImgType type, Position pos) 
        {
            var image = new Image();
            if (imageName != null)
            {
                Images.Add(imageName, image);
            }
            image.Source = resources[type];
            Canvas.SetLeft(image, left + pos.X * PicSize);
            Canvas.SetTop(image, top + pos.Y * PicSize);
            Canvas.Children.Add(image);
        }

        public void DrawImage(Character ch, ImgType type)
        {
            DrawImage(ch.Id, type, ch.Position);
        }

        // The method is separate because we don't need to keep map tiles images
        public void DrawMapImage(ImgType type, Position pos)
        {
            DrawImage(null, type, pos);
        }

        public void MoveImage(Character ch, ImgType type)
        {
            if (Images.ContainsKey(ch.Id))
            {
                Image image = Images[ch.Id];
                image.Source = resources[type];
                Canvas.SetLeft(image, left + ch.Position.X * PicSize);
                Canvas.SetTop(image, top + ch.Position.Y * PicSize);
            }
        }

        public void RemoveImage(Character ch)
        {
            if ((!(ch is Player) || !(ch is Boss)) && Images.ContainsKey(ch.Id))
            {
                Canvas.Children.Remove(Images[ch.Id]);
                Images.Remove(ch.Id);
            }
        }

        public void RemoveImage(Loot l)
        {
            if (Images.ContainsKey(l.Id))
            {
                Canvas.Children.Remove(Images[l.Id]);
                Images.Remove(l.Id);
            }
        }

        public void UpdateStatusText(string input)
        {
            tb.Text = input;
        }

        public void GameOver()
        {
            DrawCenterText("GAME OVER");
        }

        public void Loading()
        {
            DrawCenterText("LOADING...");
        }

        public void RedScreen()
        {
            Timer.Start();
            if(!AvaloniaRedDownLock)
            {
                Canvas.Children.Add(rectangle);
                AvaloniaRedDownLock = true;
            }
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 0);
            if (opacity < 5) return;
        }
        private void Timer_RedColor(object sender, EventArgs e)
        {
            try
            {
                if (opacity < 120 && !redDown) opacity += 10;
                if (opacity >= 120) redDown = true;
                if (opacity > 0 && redDown)
                {
                    opacity -= 10;
                    if (opacity <= 10)
                    {
                        opacity = 0;
                        redDown = false;
                        rectangle.Fill = new SolidColorBrush(new Color(opacity, 255, 0, 0));
                        Timer.Stop();
                        return;
                    }
                }
                rectangle.Fill = new SolidColorBrush(new Color(opacity, 255, 0, 0));
            }
            catch (Exception m)
            {
                string str = m.Message;
            }
        }


        // The following methods are used to display text through all the screen
        private void DrawCenterText(string str)
        {
            TextBlock textblock = CenterText(str, SetColor(255, 0, 0), Darken(156));
            Canvas.Children.Add(textblock);
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
            output.Width = 600;
            output.Height = 120;
            Canvas.SetTop(output, 240);
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

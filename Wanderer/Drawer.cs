using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System.Collections.Generic;
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

        public Canvas Canvas;
        public int PicSize = 72;
        public Dictionary<string, Image> Images; // Dictionary is used to call different Image objects
        private int left;
        private int top;
        private Dictionary<ImgType, Bitmap> resources;
        private static string imagePath = @"../../../img/";
        private TextBlock tb;

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
        }

        // The method is used to display player's status
        private void TextBlockDisplay()
        {
            tb = new TextBlock();
            tb.FontSize = 20;
            Canvas.Children.Add(tb);
            Canvas.SetTop(tb, 730);
            Canvas.SetLeft(tb, 10);
        }

        public void DrawImage(string imageName, ImgType type, int x, int y)
        {
            var image = new Image();
            if (imageName != null)
            {
                Images.Add(imageName, image);
            }
            image.Source = resources[type];
            Canvas.SetLeft(image, left + x * PicSize);
            Canvas.SetTop(image, top + y * PicSize);
            Canvas.Children.Add(image);
        }

        public void DrawImage(Character ch, ImgType type)
        {
            DrawImage(ch.Id, type, ch.PosX, ch.PosY);
        }

        // The method is separate because we don't need to keep map tiles images
        public void DrawMapImage(ImgType type, int x, int y)
        {
            DrawImage(null, type, x, y);
        }

        public void MoveImage(Character ch, ImgType type)
        {
            if (Images.ContainsKey(ch.Id))
            {
                Image image = Images[ch.Id];
                image.Source = resources[type];
                Canvas.SetLeft(image, left + ch.PosX * PicSize);
                Canvas.SetTop(image, top + ch.PosY * PicSize);
            }
        }

        public void RemoveImage(Character ch)
        {
            if (!(ch is Player) || !(ch is Boss))
            {
                Canvas.Children.Remove(Images[ch.Id]);
                Images.Remove(ch.Id);
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

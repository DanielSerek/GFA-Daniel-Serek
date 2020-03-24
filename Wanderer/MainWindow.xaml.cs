using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Timers;
using Wanderer.characters;

namespace Wanderer
{
    public class MainWindow : Window
    {
        Character player = null;
        List<Character> skeletons = new List<Character>();
        
        
        Timer timer = null;
        private Drawer Drawer;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;

            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();

            // Create a canvas
            var canvas = this.Get<Canvas>("canvas");
            Drawer = new Drawer(canvas, 72, 0, 0);

            // Generate a map
            Map Map = new Map(Drawer, 10);
            Map.GenerateMap(58);  //58 is max

            // Generate a player
            int x = 0;
            int y = 0;
            Map.FindFreeCell(out x, out y); 
            player = new Player(x, y, Map, Drawer, "player" ); 
            Drawer.DrawImage( player, Drawer.ImgType.HeroDown );

            // Generate skeletons
            int i, j;
            for (int k = 0; k < 3; k++)
            {
                do
                {
                    Map.RandomCell(out i, out j);
                } while (CheckCollissions(i, j));
                skeletons.Add(new Skeleton(i, j, Map, Drawer, "skeleton" + (k + 1).ToString()));
                Drawer.DrawImage("skeleton" + (k + 1).ToString(), Drawer.ImgType.Skeleton, i, j);
            }
            
            // How to display text in Avalonia
            TextBlock tb = new Avalonia.Controls.TextBlock();
            tb.Text = "HP: ";
            //tb.Foreground = SolidColorBrush.Parse("#ffffff");
            tb.FontSize = 20;
            canvas.Children.Add(tb);
            Canvas.SetTop(tb, 730);
            Canvas.SetLeft(tb, 10);
        }

        private bool CheckCollissions(int x, int y)
        {
            bool collision = false;
            for (int i = 0; i < skeletons.Count; i++)
            {
                if (skeletons[i].PosX == x && skeletons[i].PosY == y)
                {
                    collision = true;
                }
                if (player.PosX == x && player.PosY == y)
                {
                    collision = true;
                }
            }
            return collision;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // TODO: msuime vyzkoumat, jak volat v hlavnim vlakne update GUI
//            int g = 1;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key) {
                case Key.Left:
                    player.Move(Character.Direction.West);
                    break;
                case Key.Right:
                    player.Move(Character.Direction.East);
                    break;
                case Key.Up:
                    player.Move(Character.Direction.North);
                    break;
                case Key.Down:
                    player.Move(Character.Direction.South);
                    break;
            }
            SkeletonsMove();
        }

        void SkeletonsMove()
        {
            foreach (var skeleton in skeletons)
            {
                skeleton.CheckDirection();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

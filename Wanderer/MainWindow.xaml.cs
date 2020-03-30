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
        Character boss = null;
        Timer timer = null;
        private Drawer drawer;
        private Canvas canvas;
        List<Character> skeletons = new List<Character>();



        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;

            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();

            // Create a canvas
            canvas = this.Get<Canvas>("canvas");
            drawer = new Drawer(canvas, 72, 0, 0);
            //GameControl.drawer = drawer;

            // Generate a map
            Map Map = new Map(drawer, 10);
            Map.GenerateMap(58);  //58 is max

            // Generate a player
            int x = 0;
            int y = 0;
            Map.FindFreeCell(out x, out y);
            player = new Player(x, y, Map, drawer, "player");
            drawer.DrawImage(player, Drawer.ImgType.HeroDown);

            // Generate skeletons 
            int i, j;
            for (int k = 0; k < 3; k++)
            {
                // Find an empty random cell in the map
                do
                {
                    Map.RandomCell(out i, out j);
                } while (CheckCollissions(i, j));
                // Add Skeleton to the list of Skeletons
                skeletons.Add(new Skeleton(i, j, Map, drawer, "skeleton" + k.ToString()));
                // Set Skeleton initial direction
                while (!skeletons[k].CheckDirection())
                {
                    skeletons[k].GenerateDirection();
                }
                drawer.DrawImage("skeleton" + k.ToString(), Drawer.ImgType.Skeleton, i, j);
            }

            // Generate a boss
            x = 0;
            y = 0;
            do
            {
                Map.RandomCell(out x, out y);
            } while (CheckCollissions(x, y));
            boss = new Boss(x, y, Map, drawer, "boss");
            drawer.DrawImage(boss, Drawer.ImgType.Boss);



        }
        // Check free place in the map, not to create two skeletons on the same tile
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
            // TODO: Jak volat v hlavnim vlakne update GUI
            // int g = 1;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key) {
                case Key.Left:
                    player.Move(Character.Direction.West);
                    skeletonsMove();
                    break;
                case Key.Right:
                    player.Move(Character.Direction.East);
                    skeletonsMove();
                    break;
                case Key.Up:
                    player.Move(Character.Direction.North);
                    skeletonsMove();
                    break;
                case Key.Down:
                    player.Move(Character.Direction.South);
                    skeletonsMove();
                    break;
                case Key.Space:
                    GameControl.Battle(player, GetCharacter());
                    break;
            }
            drawer.UpdateStatusText(player);
        }

        

        // Get the character on the position where a player is
        public Character GetCharacter()
            {
                foreach (var skeleton in skeletons)
                {
                    if (player.PosX == skeleton.PosX && player.PosY == skeleton.PosY) return skeleton;
                }
                if (player.PosX == boss.PosX && player.PosY == boss.PosY) return boss;
                return null;
            }

        private void skeletonsMove()
        {
            for (int i = 0; i < skeletons.Count; i++)
            {
                ((Skeleton)skeletons[i]).MoveSkeleton();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

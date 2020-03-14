using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Wanderer
{
    public class MainWindow : Window
    {
        Character player = null;
        private Drawer Drawer;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;

            var canvas = this.Get<Canvas>("canvas");
            Drawer = new Drawer(canvas, 72, 0, 0);
            Map map = new Map(Drawer);
            map.GenerateMap(10, 0);  //58 is max

            int x = 0;
            int y = 0;
            map.FindFreeCell(out x, out y); 
            player = new Player(x, y, map, Drawer); 
            //player.Draw();

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key) {
                case Key.Left:
                    player.Move(Character.Direction.West);
                    Drawer.DrawImage(Drawer.ImgType.HeroDown, player.PosX, player.PosY);
                    break;
                case Key.Right:
                    player.Move(Character.Direction.East);
                    Drawer.DrawImage(Drawer.ImgType.HeroDown, player.PosX, player.PosY);
                    break;
                case Key.Up:
                    player.Move(Character.Direction.North);
                    Drawer.DrawImage(Drawer.ImgType.HeroDown, player.PosX, player.PosY);
                    break;
                case Key.Down:
                    player.Move(Character.Direction.South);

                    break;
            }

           //player.Draw();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

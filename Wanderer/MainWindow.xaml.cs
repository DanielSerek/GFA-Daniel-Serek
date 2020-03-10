﻿using Avalonia;
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

        public MainWindow()
        {
            InitializeComponent();
            var canvas = this.Get<Canvas>("canvas");
            Drawer drawer = new Drawer(canvas);
            Map map = new Map(drawer);
            map.GenerateNewMap(10, 40);  //58 is max

            this.KeyDown += MainWindow_KeyDown;

            int i, j = 0;
            map.FindFreeCell(out i, out j);

            player = new Player(i, j, map, drawer);
            player.Draw();
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

           player.Draw();
        }

            private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

namespace Wanderer
{
    public class MainWindow : Window
    {
        public static double GameSpeed = 1;
        DispatcherTimer Timer;
        private Drawer drawer;
        private Canvas canvas;
        private GameControl gameControl;
        


        public MainWindow()
        {
            InitializeComponent();

            // Create a canvas
            canvas = this.Get<Canvas>("canvas");
            drawer = new Drawer(canvas, 60, 0, 0);

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(GameSpeed);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            // Generate a map
            Map Map = new Map(drawer, 10);
            Map.CreateMap(50);

            // Generate a GameControl
            gameControl = new GameControl(Map, drawer);

            this.KeyDown += MainWindow_KeyDown;
        }

        // Keyboard input event handler
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    PlayerMoveToDirection(Character.Direction.West);
                    break;
                case Key.Right:
                    PlayerMoveToDirection(Character.Direction.East);
                    break;
                case Key.Up:
                    PlayerMoveToDirection(Character.Direction.North);
                    break;
                case Key.Down:
                    PlayerMoveToDirection(Character.Direction.South);
                    break;
                case Key.Space:
                    gameControl.AttackEnemy();
                    break;
            }
        }

        // Simplification for keyboard input handler
        public void PlayerMoveToDirection(Character.Direction direction)
        {
            gameControl.DefinePathsForSkeletons();
            gameControl.Player.Dir = direction;
            gameControl.PlayerMove();
            //gameControl.GrabLoot();
        }

        // Sequence of actions during one time period
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                gameControl.CheckStatus();
                gameControl.ShowStatus();
                gameControl.MoveSkeletons();
                gameControl.BossAttacks();
                Timer.Interval = TimeSpan.FromSeconds(GameSpeed);
            } 
            catch (Exception m)
            {
                string str = m.Message;
            }
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

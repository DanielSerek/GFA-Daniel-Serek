using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Timers;
using Wanderer.characters;

namespace Wanderer
{
    public class MainWindow : Window
    {
        DispatcherTimer Timer;
        private Drawer drawer;
        private Canvas canvas;
        private GameControl gameControl;


        public MainWindow()
        {
            InitializeComponent();

            // Create a canvas
            canvas = this.Get<Canvas>("canvas");
            drawer = new Drawer(canvas, 72, 0, 0);

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            // Generate a map
            Map Map = new Map(drawer, 10);
            Map.GenerateMap(58);  //58 is max

            // Generate a GameControl
            gameControl = new GameControl(Map, drawer);

            this.KeyDown += gameControl.MainWindow_Key;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            gameControl.SkeletonsMove();
            gameControl.CheckStatus();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

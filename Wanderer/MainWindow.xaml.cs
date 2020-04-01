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
        Timer timer = null;
        private Drawer drawer;
        private Canvas canvas;
        private GameControl gameControl;
        

        public MainWindow()
        {
            InitializeComponent();
            

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

            // Generate a GameControl
            gameControl = new GameControl(Map, drawer);

            this.KeyDown += gameControl.MainWindow_Key;
        }
        

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // TODO: Jak volat v hlavnim vlakne update GUI
            // int g = 1;
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

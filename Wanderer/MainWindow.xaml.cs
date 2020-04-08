using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

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
            Map.GenerateMap(50);

            // Generate a GameControl
            gameControl = new GameControl(Map, drawer);

            this.KeyDown += MainWindow_KeyDown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    gameControl.player.Dir = Character.Direction.West;
                    gameControl.PlayerMove();
                    break;
                case Key.Right:
                    gameControl.player.Dir = Character.Direction.East;
                    gameControl.PlayerMove();
                    break;
                case Key.Up:
                    gameControl.player.Dir = Character.Direction.North;
                    gameControl.PlayerMove();
                    break;
                case Key.Down:
                    gameControl.player.Dir = Character.Direction.South;
                    gameControl.PlayerMove();
                    
                    break;
                case Key.Space:
                    gameControl.BattlePlayer();
                    break;
            }
            
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            gameControl.ShowStatus();
            gameControl.CheckStatus();
            gameControl.SkeletonsMove();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

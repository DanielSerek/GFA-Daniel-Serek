using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris
{
    public class MainWindow : Window
    {
        Canvas Canv;
        GameControl Controller;
        private object source;

        public MainWindow()
        {
            InitializeComponent();
            #if DEBUG
            this.AttachDevTools();
            #endif

            Canv = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(Canv);

            //Add key callback function
            this.KeyUp += MainWindow_KeyUp;

            //Create drawing, map, game control setup
            DrawerUtil draw = new DrawerUtil(foxDraw, 20, 50, 50);
            GameMap map = new GameMap(draw, 10, 20);
            Controller = new GameControl(draw, map);

            for (int i = 0; i < 6; i++)
            {
                Controller.Move(Block.Direction.Down);
            }
            
            //Draw for the first time
            Controller.Draw();

        }

       
        private Task<int> Multiply(object m, object n)
        {
            throw new NotImplementedException();
        }

        //This is called when a key is pressed
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            //Clear the canvas
            Canv.Children.Clear();
            //Handle key input reponse
            Controller.HandleInput(e);
            //Draw everything
            Controller.Draw();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

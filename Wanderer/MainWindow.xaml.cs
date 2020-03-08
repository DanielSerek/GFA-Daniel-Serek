using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Collections.Generic;

namespace Wanderer
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);

            this.KeyUp += MainWindow_KeyUp;

            
            Drawer drawer = new Drawer(foxDraw);
            Map map = new Map(foxDraw, drawer);
            map.DrawMap(10);
        }

        private void MainWindow_KeyUp(object sender, Avalonia.Input.KeyEventArgs e)
        {
            //Console.WriteLine(e.Key);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

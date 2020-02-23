using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using GreenFox;

namespace AvaloniaProject
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);



            //foxDraw.SetStrokeColor(Colors.Green);
            //foxDraw.DrawLine(0, 10, 100, 100);


            //foxDraw.SetStrokeColor(Colors.Green);
            //foxDraw.DrawLine(0, 10, 100, 10);

            //var startPoint = new Point(0, 20);
            //var endPoint = new Point(100, 20);
            //foxDraw.DrawLine(startPoint, endPoint);

            // draw a red horizontal line to the canvas' middle.
            // draw a green vertical line to the canvas' middle.

            //foxDraw.SetStrokeColor(Colors.Red);
            //foxDraw.DrawLine(0, 0, MaxWidth, MaxHeight);
            //foxDraw.DrawLine(0, 0, Bounds.Width, Bounds.Height);


            // Draw a box that has different colored lines on each edge.
            //foxDraw.SetStrokeColor(Colors.Green);
            //foxDraw.DrawLine(100, 100, 150, 100);
            //foxDraw.SetStrokeColor(Colors.Blue);
            //foxDraw.DrawLine(150, 100, 150, 150);
            //foxDraw.SetStrokeColor(Colors.Red);
            //foxDraw.DrawLine(150, 150, 100, 150);
            //foxDraw.SetStrokeColor(Colors.Black);
            //foxDraw.DrawLine(100, 150, 100, 100);


            // Purple steps
            foxDraw.SetStrokeColor(Colors.Black);
            foxDraw.SetFillColor(Colors.Purple);

            for (int i = 0; i < 300; i += 20)
            {
                foxDraw.DrawRectangle(i, i, 20, 20);
            }
            
        }

     

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

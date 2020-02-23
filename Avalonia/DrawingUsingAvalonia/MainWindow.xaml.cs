using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using GreenFox;
using System;


namespace DrawingUsingAvalonia
{
    public class MainWindow : Window
    {
        static int CanvasWidth = 1200;
        static int CanvasHeight = 500;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var canvas = this.Get<Canvas>("canvas");
            var foxDraw = new FoxDraw(canvas);

            Width = CanvasWidth;
            Height = CanvasHeight;
            CanResize = false;


            // Hexagon
            int size = 100;

            foxDraw.DrawLine(size / 2 - size / 4, 0, size / 2 + size / 4, 0);




            /*
            // Envelope Star
            int numberOfLines = 20;
            for (int i = 1; i < numberOfLines; i++)
            {
                foxDraw.DrawLine((Width/(2*numberOfLines))*i, Height/2, Width/2, (Height/2)-(Height/(2*numberOfLines))*i);
                foxDraw.DrawLine(Width / 2, (Height / (2 * numberOfLines)) * i, Width/2 + (Width/(2*numberOfLines))*i, Height/2);
                foxDraw.DrawLine((Width/(2*numberOfLines))*i, Height/2, Width/2, (Height/2)+(Height/(2*numberOfLines))*i);
                foxDraw.DrawLine(Width / 2, Height - (Height / (2 * numberOfLines)) * i, Width / 2 + (Width / (2 * numberOfLines)) * i, Height / 2);
            }
            */


            /*
            // Triangles
            int numberOfLines = 30;
            for (int i = 0; i < numberOfLines; i++)
            {
                foxDraw.DrawLine((Width / 2) - i * ((Width / 2) / numberOfLines), (Height / numberOfLines) * i, (Width / 2) + i * ((Width / 2) / numberOfLines), (Height / numberOfLines) * i);
                foxDraw.DrawLine((Width / 2) + i * ((Width / 2) / numberOfLines), (Height / numberOfLines) * i, (Width / numberOfLines) * i, Height);
                foxDraw.DrawLine((Width / 2) - i * ((Width / 2) / numberOfLines), (Height / numberOfLines) * i, Width - (Width / numberOfLines) * i, Height);
            }
            */
            
            /* 
            // Lines Play
            int numberOfLines = 30;

            for (int i = 0; i < numberOfLines; i++)
            {
                foxDraw.DrawLine(i*(Width/numberOfLines), 0, Width, (Height / numberOfLines)*i);
                foxDraw.DrawLine(0, i * (Height / numberOfLines), (Width / numberOfLines) * i, Height);
            }
            */


            // Lines to the center
            //int distance = 20;

            //for (int i = 0; i <= CanvasWidth; i += distance)
            //{

            //    foxDraw.DrawLine(i, 0, Width / 2, Height / 2);
            //    foxDraw.DrawLine(i, Height, Width / 2, Height / 2);

            //}

            //for (int j = 0; j <= CanvasHeight; j += distance)
            //{

            //    foxDraw.DrawLine(0, j, Width / 2, Height / 2);
            //    foxDraw.DrawLine(Width, j, Width / 2, Height / 2);

            //}



            // Purple steps
            //foxDraw.SetStrokeColor(Colors.Black);
            //foxDraw.SetFillColor(Colors.Purple);

            //double size = 5;
            //for (double i = 0; i < 500; i += size)
            //{
            //    size *= 1.5;
            //    foxDraw.DrawRectangle(i, i, size, size);
            //}


            // Checkerboard pattern
            //int size = 20;
            //for (int i = 0; i < 400; i+=2*size)
            //{
            //    for (int j = 0; j < 400; j+=2*size)
            //    {
            //        if (true)
            //        {

            //        }

            //        foxDraw.SetFillColor(Colors.Black); 
            //        foxDraw.DrawRectangle(i, j, size, size);
            //        foxDraw.SetFillColor(Colors.White); 
            //        foxDraw.DrawRectangle(i, j+size, size, size);
            //    }
            //}

            // Checkerboard - Not finished code
            //int size = 50;
            //for (int i = 1; i < 9; i++)
            //{
            //    for (int j = 1; j < 9; j++)
            //    {
            //        if ((i + j) % 2 == 0)
            //        {
            //            foxDraw.DrawRectangle(i * size, j * size, size, size, Colors.Black);
            //        }
            //        else
            //        {
            //            foxDraw.DrawRectangle((i * size) + (size), j * size, size, size, Colors.White);
            //        }
            //    }
            //}

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

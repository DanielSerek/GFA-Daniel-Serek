using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer
{
    public class Player : Character
    {
        // private IBitmap Image = new Avalonia.Media.Imaging.Bitmap(@"../../../img/hero-down.png");

        public Player(int posX, int posY, Map map, Drawer drawer ) : base(posX, posY, map, drawer)
        {
            this.SetImage(@"../../../img/hero-down.png");
        }

    }
}

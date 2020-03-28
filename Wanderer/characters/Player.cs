using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer
{
    public class Player : Character
    {
        public Player(int posX, int posY, Map map, Drawer drawer, string id ) : base(posX, posY, map, drawer, id)
        {
            Random random = new Random();
            CurrentHP = 20 + 3 * random.Next(7);
            DP = 2 * random.Next(7);
            SP = 5 + random.Next(7);
        }

        public override void Move(Direction dir)
        {
            base.Move(dir);

            Drawer.ImgType img_type = Drawer.ImgType.HeroDown;

            switch ( dir ) {
                case Direction.West:
                    img_type = Drawer.ImgType.HeroLeft;
                    break;

                case Direction.East:
                    img_type = Drawer.ImgType.HeroRight;
                    break;

                case Direction.North:
                    img_type = Drawer.ImgType.HeroUp;
                    break;

                case Direction.South:
                    img_type = Drawer.ImgType.HeroDown;
                    break;
            }

            Drawer.MoveImage( this, img_type);
        }
    } 
}

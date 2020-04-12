using System;
using System.Collections.Generic;

namespace Wanderer.characters
{
    public class Skeleton : Character
    {
        public Skeleton(int posX, int posY, Map map, Drawer drawer, GameControl gameControl, string id) : base(posX, posY, map, drawer, gameControl, id)
        {
            Random random = new Random();
            MaxHP = 2 * GameControl.Level * random.Next(1, 7);
            CurrentHP = MaxHP;
            DP = GameControl.Level / 2 * random.Next(1, 7);
            SP = GameControl.Level * random.Next(1, 7);
        }

        public override void Move(Direction dir)
        {
            base.Move(dir);
            Drawer.ImgType img_type = Drawer.ImgType.Skeleton;
            drawer.MoveImage(this, img_type);
        }

        public void MoveSkeleton()
        {
            SetDirection();
            Move(Dir);
        }
    }
}

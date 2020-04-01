using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer.characters
{
    public class Skeleton : Character
    {
        public Skeleton(int posX, int posY, Map map, Drawer drawer, string id ) : base(posX, posY, map, drawer, id)
        {
            Random random = new Random();
            MaxHP = 2 * GameControl.Level * random.Next(1, 7);
            CurrentHP = MaxHP;
            DP = GameControl.Level / 2 * random.Next(1, 7);
            SP = GameControl.Level * random.Next(1, 7);
        }

        
        public void MoveSkeleton()
        {
            while (!this.CheckDirection())
            {
                this.GenerateDirection();
            }
            //this.CheckPossibleOtherDirection();
            this.Move(this.Dir);
        }

        public override void Move(Direction dir)
        {
            base.Move(dir);
            Drawer.ImgType img_type = Drawer.ImgType.Skeleton;
            Drawer.MoveImage(this, img_type);
        }
    }
}

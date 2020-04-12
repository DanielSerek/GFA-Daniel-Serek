using System;

namespace Wanderer.characters
{
    class Boss : Character
    {
        public Boss(int posX, int posY, Map map, Drawer drawer, GameControl gameControl, string id) : base(posX, posY, map, drawer, gameControl, id)
        {
            Random random = new Random();
            MaxHP = 2 * GameControl.Level * random.Next(1, 7) + random.Next(1, 7);
            CurrentHP = MaxHP;
            DP = GameControl.Level / 2 * random.Next(1, 7) + random.Next(1, 7) / 2;
            SP = GameControl.Level * random.Next(1, 7) + GameControl.Level;
        }

        public override void Move(Direction dir)
        {
            base.Move(dir);
            Drawer.ImgType img_type = Drawer.ImgType.Boss;
            drawer.MoveImage(this, img_type);
        }

        public void MoveBoss()
        {
            SetDirection();
            Move(Dir);
        }
    }
}

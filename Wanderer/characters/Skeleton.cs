using System;
using System.Collections.Generic;

namespace Wanderer.characters
{
    public class Skeleton : Character
    {
        public List<Position> PathPositions;
        public Skeleton(int posX, int posY, Map map, Drawer drawer, GameControl gameControl, string id) : base(posX, posY, map, drawer, gameControl, id)
        {
            Random random = new Random();
            MaxHP = 2 * GameControl.Level * random.Next(1, 7);
            CurrentHP = MaxHP;
            DP = GameControl.Level / 2 * random.Next(1, 7);
            SP = GameControl.Level * random.Next(1, 7);
        }


        //public void MoveSkeleton()
        //{
        //    bool canMove = true;
        //    while (!this.CheckDirection())
        //    {
        //        if (!GenerateDirection())
        //        {
        //            canMove = false;
        //            break;
        //        }
        //    }
        //    //this.CheckPossibleOtherDirection();
        //    if(canMove) this.Move(this.Dir);
        //}

        public override void Move(Direction dir)
        {
            base.Move(dir);
            Drawer.ImgType img_type = Drawer.ImgType.Skeleton;
            Drawer.MoveImage(this, img_type);
        }

        public void NavigateEnemyToPlayer(Character player, Map map)
        {
            PathFinder pathFinder = new PathFinder();
            this.PathPositions = pathFinder.PathFinding(PosX, PosY, player.PosX, player.PosY, map);
        }

        public void SetDirection()
        {
            if (PathPositions[0].PosX > PosX) this.Dir = Direction.East;
            if (PathPositions[0].PosX < PosX) this.Dir = Direction.West;
            if (PathPositions[0].PosY > PosY) this.Dir = Direction.South;
            if (PathPositions[0].PosY < PosY) this.Dir = Direction.North;
            PathPositions.RemoveAt(0);
        }
    }
}

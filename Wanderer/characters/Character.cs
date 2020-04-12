﻿using System;
using System.Collections.Generic;

namespace Wanderer
{
    abstract public class Character
    {
        public enum Direction
        {
            North,
            South,
            West,
            East
        }

        public int PosX;
        public int PosY;
        public Direction Dir;
        public int MaxHP;
        public int CurrentHP {
            get { return hp; }
            set 
            {
                if (value < 0) hp = 0;
                else hp = value;
            } 
        }
        public List<Position> PathPositions;
        public int DP;
        public int SP;
        protected Drawer drawer;
        protected GameControl gameControl;
        private Map map;
        private int hp;

        public string Id { get; private set; }

        public Character(int posX, int posY, Map map, Drawer drawer, GameControl gameControl, string id)
        {
            Id = id;
            PosX = posX;
            PosY = posY;
            this.map = map;
            this.drawer = drawer;
            this.gameControl = gameControl;
        }

        public virtual void Move(Direction dir)
        {
            if (dir == Direction.North && CheckTileOccupancy(PosX, PosY - 1)) PosY--;
            if (dir == Direction.South && CheckTileOccupancy(PosX, PosY + 1)) PosY++;
            if (dir == Direction.West  && CheckTileOccupancy(PosX - 1, PosY)) PosX--;
            if (dir == Direction.East  && CheckTileOccupancy(PosX + 1, PosY)) PosX++;
        }

        public bool CheckDirection()
        {
            if (Dir == Direction.North      && CheckTileOccupancy(PosX, PosY - 1)) return true;
            else if (Dir == Direction.South && CheckTileOccupancy(PosX, PosY + 1)) return true;
            else if (Dir == Direction.West  && CheckTileOccupancy(PosX - 1, PosY)) return true;
            else if (Dir == Direction.East  && CheckTileOccupancy(PosX + 1, PosY)) return true;
            else return false;
        }

        public void SetDirection()
        {

            if (PathPositions.Count < 1) return;
            if (PathPositions[0].PosX > PosX) Dir = Direction.East;
            if (PathPositions[0].PosX < PosX) Dir = Direction.West;
            if (PathPositions[0].PosY > PosY) Dir = Direction.South;
            if (PathPositions[0].PosY < PosY) Dir = Direction.North;
            PathPositions.RemoveAt(0);
        }

        public void NavigateEnemyToPlayer(Character player, Map map)
        {
            PathFinder pathFinder = new PathFinder();
            PathPositions = pathFinder.PathFinding(PosX, PosY, player.PosX, player.PosY, map);
        }

        // Checks if the tile is empty
        private bool CheckTileOccupancy(int x, int y)
        {
            if (map.GetTile(x, y) == Map.TileType.Wall) return false;
            if (!gameControl.IsCellFree(x, y)) return false;
            return true;
        }

        public bool RemoveImage()
        {
            bool alive = true;
            if (CurrentHP < 1)
            {
                CurrentHP = 0;
                drawer.RemoveImage(this);
                alive = false;
                drawer.Images.Remove(this.Id);
            }
            return alive;
        }
    }
}

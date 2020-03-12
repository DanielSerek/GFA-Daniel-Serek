﻿using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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


    private Drawer Drawer;
        private Map Map;
        protected Avalonia.Controls.Image playerImage = null;


        public Character(int posX, int posY, Map map, Drawer drawer)            // , string imagePath
        {
            PosX = posX;
            PosY = posY;
            Map = map;
            this.Drawer = drawer;

            playerImage = new Avalonia.Controls.Image();
            // SetImage(imagePath);
            drawer.canvas.Children.Add(playerImage);
        }

        // Sets Source to the image
        protected void SetImage(string imagePath )
        {
            // Free the reference to the Bitmap
            if (playerImage.Source != null) {
                playerImage.Source.Dispose();
            }

            playerImage.Source = new Avalonia.Media.Imaging.Bitmap(imagePath);
        }


        public virtual void Move(Direction dir)
        {
            if (dir == Direction.North  && (PosY != 0)                          && (Map.GameMap[PosX][PosY - 1] != 1)) PosY--;
            if (dir == Direction.South  && (PosY != Map.GameMap[1].Count - 1)   && (Map.GameMap[PosX][PosY + 1] != 1)) PosY++;
            if (dir == Direction.West   && (PosX != 0)                          && (Map.GameMap[PosX - 1][PosY] != 1)) PosX--;
            if (dir == Direction.East   && (PosX != Map.GameMap[1].Count - 1)   && (Map.GameMap[PosX + 1][PosY] != 1)) PosX++;
        }


        public virtual void Draw()
        {
            Drawer.Draw(playerImage, PosX, PosY);
        }
    }
}
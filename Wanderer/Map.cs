using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Text;

namespace Wanderer
{
    public class Map
    {

        public enum TileType
        {
            Wall,
            Floor,
            Flooded
        }

        private Drawer Drawer;
        public Image[,] Images = null;
        public TileType[,] GameMap = null; 

        public IBitmap FLOOR = new Avalonia.Media.Imaging.Bitmap(@"../../../img/floor.png");
        public IBitmap WALL = new Avalonia.Media.Imaging.Bitmap(@"../../../img/wall.png");


        public Map(Drawer drawer)
        {
            Drawer = drawer;
        }

        public void GenerateMap(int size, int wallsPercentage)
        {
            //Image test = new Avalonia.Controls.Image();
            Images = new Avalonia.Controls.Image[size, size];
            // Generate the map of images objects
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    Images[i, j] = new Avalonia.Controls.Image();
                    Images[i, j].Source = FLOOR;
                    Drawer.canvas.Children.Add(Images[i, j]);
                }
            }

            // Generate the virtual gameMap
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;
            
            GameMap = new TileType[size, size];

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    randomNumber = random.Next(0, 100);
                    if (randomNumber <= wallsPercentage) {
                        GameMap[i, j] = TileType.Wall;
                    } else {
                        GameMap[i, j] = TileType.Flooded;
                        floorCount++;
                    }
                }
            }

            int chf = 0;
            do {
                floorCount = GenerateNewMap(wallsPercentage);
                int i, j = 0;
                if (FindFreeCell(out i, out j)) {
                    FloodFill(i, j);
                }
                chf = CheckFloodFill();
            } while (chf != floorCount);
            
            PrepareMap();

            PrintMap();
        }

        // Resolves boundary conditions and returns a type of a tile
        public TileType GetTile(int x, int y)
        {
            if (x < 0 || x >= GameMap.GetLength(0) ||
                y < 0 || y >= GameMap.GetLength(1)) return TileType.Wall;
            return GameMap[x, y];
        }


        public bool FindFreeCell(out int x, out int y)
        {
            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    if (GameMap[i, j] == TileType.Floor) 
                    {
                        x = i;
                        y = j;
                        return true;
                    }
                }
            }
            x = -1;
            y = -1;
            return false;
        }


        public void PrintMap()
        {
            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    if (GameMap[i, j] == TileType.Wall) Images[i, j].Source = WALL;
                    Drawer.Draw(Images[i, j], i, j);
                }
            }
        }

        int GenerateNewMap(int wallsPercentage)
        {
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    randomNumber = random.Next(1, 100);
                    if (randomNumber <= wallsPercentage) {
                        GameMap[i, j] = TileType.Wall;

                    } else {
                        GameMap[i, j] = TileType.Floor;
                        floorCount++;
                    }
                }
            }
            return floorCount;
        }

        void PrepareMap()
        {
            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    if (GameMap[i, j] == TileType.Flooded) {
                        GameMap[i, j] = TileType.Floor;
                    }
                }
            }
        }


        int CheckFloodFill()
        {
            int count = 0;
            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    if (GameMap[i, j] == TileType.Flooded) {
                        count++;
                        //GameMap[i,j] = TileType.Floor;
                    }
                }
            }
            return count;
        }

        void FloodFill(int x, int y)
        {

            // Base cases 
            if (x < 0 || x >= GameMap.GetLength(0) ||
                y < 0 || y >= GameMap.GetLength(1))
                return;
            if (GameMap[x, y] == TileType.Flooded || GameMap[x, y] == TileType.Wall)
                //if (gameMap[x,y] != TileType.Flooded)
                return;

            // Replace the color at (x, y) 
            GameMap[x, y] = TileType.Flooded;

            // Recur for north, east, south and west 
            FloodFill(x + 1, y);
            FloodFill(x - 1, y);
            FloodFill(x, y + 1);
            FloodFill(x, y - 1);

        }
    }
}

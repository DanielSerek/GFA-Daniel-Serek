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
        public TileType[,] GameMap = null;
        private int mapSize;

        public Map(Drawer drawer, int mapSize)
        {
            Drawer = drawer;
            this.mapSize = mapSize;
        }

        // The initial function call to generate first map and check if it passess Floodfill method
        public void GenerateMap(int wallsPercentage)
        {
            // Generate the virtual gameMap
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;
            
            GameMap = new TileType[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++) {
                for (int j = 0; j < mapSize; j++) {
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
                    if (GameMap[i, j] == TileType.Wall) Drawer.DrawImage(i.ToString()+j.ToString(), Drawer.ImgType.Wall, i, j);
                    else Drawer.DrawImage(i.ToString()+j.ToString(), Drawer.ImgType.Floor, i, j);
                }
            }
        }

        // If the first map doesn't pass floodfill, a new map is generated using this method
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
                    } 
                    else {
                        GameMap[i, j] = TileType.Floor;
                        floorCount++;
                    }
                }
            }
            return floorCount;
        }

        // Change of flooded tiles back to floor tiles
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


        // Count how many tiles have been flooded
        int CheckFloodFill()
        {
            int count = 0;
            for (int i = 0; i < GameMap.GetLength(0); i++) {
                for (int j = 0; j < GameMap.GetLength(1); j++) {
                    if (GameMap[i, j] == TileType.Flooded) {
                        count++;
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
                return;

            // Replace the color at (x, y) 
            GameMap[x, y] = TileType.Flooded;

            // Recur for north, east, south and west 
            FloodFill(x + 1, y);
            FloodFill(x - 1, y);
            FloodFill(x, y + 1);
            FloodFill(x, y - 1);
        }

        //Generate a random cell and create a skeleton
        public void RandomCell(out int i, out int j)
        {
            Random random = new Random();
            do
            {
                i = random.Next(1, mapSize);
                j = random.Next(1, mapSize);
            } while (GetTile(i, j) != Map.TileType.Floor);
        }
    }
}

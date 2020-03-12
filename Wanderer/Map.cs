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

        public List<List<Image>> Images = new List<List<Image>>();
        public List<List<TileType>> GameMap = new List<List<TileType>>();

        public IBitmap FLOOR = new Avalonia.Media.Imaging.Bitmap(@"../../../img/floor.png");
        public IBitmap WALL = new Avalonia.Media.Imaging.Bitmap(@"../../../img/wall.png");


        public Map(Drawer drawer )
        {
            Drawer = drawer;
        }

        public void GenerateNewMap(int size, int wallsPercentage) 
        {
            // Generate the map of images objects
            for (int i = 0; i < size; i++)
            {
                Images.Add(new List<Image>());
                for (int j = 0; j < size; j++)
                {
                    Images[i].Add(new Avalonia.Controls.Image());
                    Images[i][j].Source = FLOOR;
                    Drawer.canvas.Children.Add(Images[i][j]);
                }
            }

            // Generate the virtual gameMap: -1 = walkable field, 1 = wall ; -1 will be replaced by 0 in case of succesfull floodFill method
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < size; i++)
            {
                GameMap.Add(new List<TileType>());
                for (int j = 0; j < size; j++)
                {
                    GameMap[i].Add(TileType.Floor);
                    randomNumber = random.Next(0, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        GameMap[i][j] = TileType.Wall;
                    }
                    else floorCount++;
                }
            }


            do 
            {
                floorCount = generateNewMap(GameMap, wallsPercentage);
                int i, j = 0;
                if (FindFreeCell(out i, out j)) { floodFill(GameMap, i, j); }

            } while (checkFloodFill(GameMap) != floorCount);

                        
            PrintMap();
        }

        // Resolves boundary conditions and returns a type of a tile
        public TileType GetTile(int x, int y)
        {
            if (x <= 0 || x >= GameMap[0].Count - 1) return TileType.Wall;
            if (y <= 0 || y >= GameMap[1].Count - 1) return TileType.Wall;
            return GameMap[x][y];
        }


        public bool FindFreeCell(out int x, out int y)
        {
            for (int i = 0; i < GameMap[0].Count - 1; i++)
            {
                for (int j = 0; j < GameMap[1].Count; j++)
                {
                    if (GameMap[i][j] == TileType.Floor || GameMap[i][j] == TileType.Flooded)
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
            for (int i = 0; i < GameMap[0].Count; i++)
            {
                for (int j = 0; j < GameMap[1].Count; j++) {
                    if(GameMap[i][j] == TileType.Wall) Images[i][j].Source = WALL;
                    Drawer.Draw(Images[i][j], i, j);
                }
            }
        }

        static int generateNewMap(List<List<TileType>> gameMap, int wallsPercentage)
        {
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < gameMap.Count; i++)
            {
                for (int j = 0; j < gameMap.Count; j++)
                {
                    randomNumber = random.Next(1, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        gameMap[i][j] = TileType.Wall;
                        
                    }
                    else
                    {
                        gameMap[i][j] = TileType.Floor;
                        floorCount++;
                    }
                }
            }
            return floorCount;
        }
        


        static int checkFloodFill(List<List<TileType>> gameMap)
        {
            int count = 0;
            for (int i = 0; i < gameMap[0].Count; i++)
            {
                for (int j = 0; j < gameMap[1].Count; j++)
                {
                    if (gameMap[i][j] == TileType.Flooded)
                    {
                        count++;
                        gameMap[i][j] = TileType.Floor;
                    }
                }
            }
            return count;
        }
        
        static void floodFill(List<List<TileType>> gameMap, int x, int y)
        {
            
            // Base cases 
            if (x < 0 || x >= gameMap[0].Count ||
                y < 0 || y >= gameMap[1].Count)
                return;
            if (gameMap[x][y] == TileType.Floor || gameMap[x][y] == TileType.Flooded)
                return;

            // Replace the color at (x, y) 
            gameMap[x][y] = TileType.Flooded;

            // Recur for north, east, south and west 
            floodFill(gameMap, x + 1, y);
            floodFill(gameMap, x - 1, y);
            floodFill(gameMap, x, y + 1);
            floodFill(gameMap, x, y - 1);
        }
    }
}

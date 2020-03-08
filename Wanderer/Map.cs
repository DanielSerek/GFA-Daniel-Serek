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
        private FoxDraw FoxDraw;
        private Drawer Drawer;
        //private Map Map;
        public List<List<Image>> Images = new List<List<Image>>();
        public List<List<int>> GameMap = new List<List<int>>();
        public int PicSize = 72;

        public Map(FoxDraw foxDraw, Drawer drawer)
        {
            FoxDraw = foxDraw;
            Drawer = drawer;
            //Map = map;
        }
        public void DrawMap(int size, int wallsPercentage) //, Canvas canvas
        {
            // Generate the map of images objects
            for (int i = 0; i < size; i++)
            {
                Images.Add(new List<Image>());
                for (int j = 0; j < size; j++)
                {
                    Images[i].Add(new Avalonia.Controls.Image());
                    Images[i][j].Source = Drawer.Floor;
                }
            }

            // Generate the virtual gameMap: -1 = walkable field, 1 = wall ; -1 will be replaced by 0 in case of succesfull floodFill method
        
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < size; i++)
            {
                GameMap.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    GameMap[i].Add(-1);
                    randomNumber = random.Next(0, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        GameMap[i][j] = 1;
                    }
                    else floorCount++;
                }
            }


            do 
            {
                floorCount = generateNewMap(GameMap, wallsPercentage);
                //for (int i = 0; i < gameMap.Count; i++)
                //{
                int i = 0;    
                for (int j = 0; j < GameMap.Count; j++)
                    {
                        if (GameMap[i][j] == -1)
                        {
                            floodFill(GameMap, i, j);
                            break;
                        }
                    }
                
                //}
            } while (checkFloodFill(GameMap) != floorCount);


            // Print the map
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (GameMap[i][j] == 0) Drawer.DrawCell(Images[i][j], PicSize, Drawer.Floor, i, j);
                    else Drawer.DrawCell(Images[i][j], PicSize, Drawer.Wall, i, j);
                }
            }

        }


        static int generateNewMap(List<List<int>> gameMap, int wallsPercentage)
        {
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < gameMap.Count; i++)
            {
                for (int j = 0; j < gameMap.Count; j++)
                {
                    randomNumber = random.Next(0, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        gameMap[i][j] = 1;
                        
                    }
                    else
                    {
                        gameMap[i][j] = -1;
                        floorCount++;
                    }
                }
            }
            return floorCount;
        }


        static int checkFloodFill(List<List<int>> gameMap)
        {
            int count = 0;
            for (int i = 0; i < gameMap[0].Count; i++)
            {
                for (int j = 0; j < gameMap[1].Count; j++)
                {
                    if (gameMap[i][j] == 0) count++;
                }
            }
            return count;
        }
        
        static void floodFill(List<List<int>> gameMap, int x, int y)
        {
            
            // Base cases 
            if (x < 0 || x >= gameMap[0].Count ||
                y < 0 || y >= gameMap[1].Count)
                return;
            if (gameMap[x][y] == 1 || gameMap[x][y] == 0)
                return;

            // Replace the color at (x, y) 
            gameMap[x][y] = 0;

            // Recur for north, east, south and west 
            floodFill(gameMap, x + 1, y);
            floodFill(gameMap, x - 1, y);
            floodFill(gameMap, x, y + 1);
            floodFill(gameMap, x, y - 1);
        }
    }
}

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
        
        public Map(FoxDraw foxDraw, Drawer drawer)
        {
            FoxDraw = foxDraw;
            Drawer = drawer;
        }
        public void DrawMap(int size, int wallsPercentage) //, Canvas canvas
        {

            // TODO: Where to put it? Use Enum?
            IBitmap Floor = new Avalonia.Media.Imaging.Bitmap(@"../../../img/floor.png");
            IBitmap Wall = new Avalonia.Media.Imaging.Bitmap(@"../../../img/wall.png");
            IBitmap Skeleton = new Avalonia.Media.Imaging.Bitmap(@"../../../img/skeleton.png");
                       

            // Generate the map of images objects
            List<List<Image>> images = new List<List<Image>>();
            for (int i = 0; i < size; i++)
            {
                images.Add(new List<Image>());
                for (int j = 0; j < size; j++)
                {
                    images[i].Add(new Avalonia.Controls.Image());
                    images[i][j].Source = Floor;
                }
            }

            // Generate the virtual gameMap: -1 = walkable field, 1 = wall ; -1 will be replaced by 0 in case of succesfull floodFill method
            List<List<int>> gameMap = new List<List<int>>();
            Random random = new Random();
            int floorCount = 0; //wallsCount variable is needed in floodFill method
            int randomNumber;

            for (int i = 0; i < size; i++)
            {
                gameMap.Add(new List<int>());
                for (int j = 0; j < size; j++)
                {
                    gameMap[i].Add(-1);
                    randomNumber = random.Next(0, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        gameMap[i][j] = 1;
                    }
                    else floorCount++;
                }
            }


            do 
            {
                floorCount = generateNewMap(gameMap, wallsPercentage);
                //for (int i = 0; i < gameMap.Count; i++)
                //{
                int i = 0;    
                for (int j = 0; j < gameMap.Count; j++)
                    {
                        if (gameMap[i][j] == -1)
                        {
                            floodFill(gameMap, i, j);
                            break;
                        }
                    }
                
                //}
            } while (checkFloodFill(gameMap) != floorCount);


            // Print the map
            int picSize = 72;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (gameMap[i][j] == 0) Drawer.DrawCell(images, picSize, Floor, i, j);
                    else if (gameMap[i][j] == -1) Drawer.DrawCell(images, picSize, Skeleton, i, j);
                    else Drawer.DrawCell(images, picSize, Wall, i, j);
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

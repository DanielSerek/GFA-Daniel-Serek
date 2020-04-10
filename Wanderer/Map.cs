using System;

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

        public TileType[,] GameMap = null;
        public int MapSize;
        private Drawer drawer;
        // Holds information how many floor tiles were created, is needed for floodFill method 
        private int floorCount; 

        public Map(Drawer drawer, int mapSize)
        {
            this.drawer = drawer;
            MapSize = mapSize;
            // Generate the virtual GameMap
            GameMap = new TileType[MapSize, MapSize];
        }

        // Creates a game map
        public void CreateMap(int wallsPercentage)
        {
            int chf = 0; // Provides information how many tiles have been flooded
            // Generate new maps until the number of flooded tiles equals floor tiles
            do
            {
                floorCount = 0;
                floorCount = GenerateRandomMap(wallsPercentage);
                int i, j = 0;
                RandomFreeCell(out i, out j);
                FloodFill(i, j);
                chf = CheckFloodFill();
            } while (chf != floorCount);
            ChangeFloodedToFloor();
            PrintMap();
        }

        // If the map doesn't pass floodfill method, a new map is generated
        int GenerateRandomMap(int wallsPercentage)
        {
            Random random = new Random();
            int randomNumber;

            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    randomNumber = random.Next(1, 100);
                    if (randomNumber <= wallsPercentage)
                    {
                        GameMap[i, j] = TileType.Wall;
                    }
                    else
                    {
                        GameMap[i, j] = TileType.Floor;
                        floorCount++;
                    }
                }
            }
            return floorCount;
        }

        // Resolves boundary conditions (not to get outside of the array) and returns a type of a tile
        public TileType GetTile(int x, int y)
        {
            if (x < 0 || x >= MapSize ||
                y < 0 || y >= MapSize) return TileType.Wall;
            return GameMap[x, y];
        }

        public void PrintMap()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (GameMap[i, j] == TileType.Wall) drawer.DrawMapImage(Drawer.ImgType.Wall, i, j);
                    else drawer.DrawMapImage(Drawer.ImgType.Floor, i, j);
                }
            }
        }

        // Change of flooded tiles back to floor tiles
        void ChangeFloodedToFloor()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    if (GameMap[i, j] == TileType.Flooded)
                        GameMap[i, j] = TileType.Floor;
                }
            }
        }


        // Count how many tiles have been flooded
        int CheckFloodFill()
        {
            int count = 0;
            foreach (var tile in GameMap)
            {
                if (tile == TileType.Flooded) count++;
            }
            return count;
        }

        void FloodFill(int x, int y)
        {
            // Base cases 
            if (x < 0 || x >= MapSize ||
                y < 0 || y >= MapSize)
                return;
            if (GameMap[x, y] == TileType.Flooded || GameMap[x, y] == TileType.Wall)
                return;

            // Replace the tile type at (x, y) 
            GameMap[x, y] = TileType.Flooded;

            // Recur for north, east, south and west 
            FloodFill(x + 1, y);
            FloodFill(x - 1, y);
            FloodFill(x, y + 1);
            FloodFill(x, y - 1);
        }
             
        //Generate a random free cell 
        public void RandomFreeCell(out int i, out int j)
        {
            Random random = new Random();
            do
            {
                i = random.Next(1, MapSize);
                j = random.Next(1, MapSize);
            } while (GetTile(i, j) != TileType.Floor);
        }
    }
}

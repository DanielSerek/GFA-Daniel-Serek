using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    //Handles all the game logic and control related stuff
    class GameControl
    {
        private DrawerUtil Drawer;
        private GameMap Map;
        private Block CurrentBlock; //Currently "playable" block

        public GameControl(DrawerUtil drawer, GameMap map)
        {
            Drawer = drawer;
            Map = map;
            //Create first block to start the game
            GenerateNewBlock();
        }

        public void GameStep()
        {
            //TODO: handle automatic block downfall
        }

        //Handles touchdown event -> our block is to be merged into the map
        //And new playable block has to be generated
        public void Touchdown()
        {
            //Merging the played block into the game map content
            var newCells = CurrentBlock.GetCellContent();
            foreach(var cell in newCells)
            {
                Map.SetCellToFilled(cell.Item1, cell.Item2);
            }

            //Creating new playable block
            GenerateNewBlock();
        }

        //Generates a newly spawned random playable block at the top of the map
        public void GenerateNewBlock()
        {
            CurrentBlock = BlockFactory.CreateBlockRandom(Drawer, 5, 0);
        }

        //Handles the collision and if no obstruction, we move the block
        //Also handles the touchdown scenario (played block is finished)
        public async void Move(Block.Direction dir)
        {
            //Creates the virtual block to check for potential collisions
            Block MovedBlock = CurrentBlock.CreateMoved(dir);

            //Checks for obstructed place
            if (MovedBlock.CheckCollision(Map))
            {
                //Down collision is a special case: touchdown
                if (dir == Block.Direction.Down)
                {
                    //Handles touchdown event
                    Touchdown();
                }
            }
            else
            {
                //No obstruction -> can move the block 
                CurrentBlock.Move(dir);
            }
        }

        //What happens if we press a key on the keyboard
        public void HandleInput(KeyEventArgs e)
        {
            switch (e.Key)
            {
                //Down, Right, Left arrow keys
                //Note: Calls our own Move, handling now just the block movement
                //but also collision handling and everything
                case Key.Down:  Move(Block.Direction.Down); break;
                case Key.Right: Move(Block.Direction.Right); break;
                case Key.Left:  Move(Block.Direction.Left); break;
            }
        }

        //Draw the whole map and the currently played block too
        public void Draw()
        {
            Map.Draw();
            CurrentBlock.Draw();
        }
    }
}

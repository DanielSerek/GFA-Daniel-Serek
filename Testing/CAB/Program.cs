using System;

namespace CAB
{
    class Program
    {
        static void Main(string[] args)
        {
            CowsAndBulls game = new CowsAndBulls();
            string rndNumber = game.RandomNumber();

            do
            {
                string guess = game.UserInput();
                Console.WriteLine($"Guessed Cows: {game.Guess(rndNumber, guess)}");
            } while (game.Status == "Playing");

            if(game.Status == "Finished") Console.WriteLine($"You needed {game.Guesses} guesses.");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CAB
{
    public class CowsAndBulls
    {
        public string Status;
        public int Guesses;
        public int GuessedBulls;
        public int GuessedCows;
        
        public CowsAndBulls()
        {
            Status = "Playing";
            Guesses = 0;
            GuessedBulls = 0;
            GuessedCows = 0;
        }

        /// <summary>
        /// Generate a random number and parse it to string
        /// </summary>
        /// <returns></returns>
        public string RandomNumber()
        {
            Random random = new Random();
            int rndNum;
            string randomNumberString = "";
            for (int i = 0; i < 4; i++)
            {
                rndNum = random.Next(0, 9);
                randomNumberString += rndNum.ToString();
            }
            Console.WriteLine(randomNumberString);
            return randomNumberString;
        }

        /// <summary>
        /// The method returns user input
        /// </summary>
        /// <returns></returns>
        public string UserInput()
        {
            Console.Write("Guess the number: ");
            string guess = Console.ReadLine();
            return guess;
        }

        /// <summary>
        /// The method verifies whether the user input is in correct format
        /// </summary>
        /// <returns></returns>
        public bool CheckUserInput(string guess)
        {
            if (guess.Length != 4) return false;
            try
            {
                if (int.Parse(guess) >= 0 && int.Parse(guess) <= 9999)
                {
                    return true;
                }
                else return true;
            }
            catch (Exception e)
            {

                Console.WriteLine("The number was not in a correct format.");
                return false;
            }
            
        }

        /// <summary>
        /// The method returns string of cows and bulls guessed (bulls is the number of bulls deducted with the number of cows)
        /// </summary>
        /// <param name="numberToBeGuessed"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string Guess(string numberToBeGuessed, string guess)
        {
            if (guess == "X") return "The input was wrong.";
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guess[i] == numberToBeGuessed[i])
                    {
                        GuessedCows++;
                        break;
                    }
                    else if (numberToBeGuessed[i] == guess[j])
                    {
                        GuessedBulls++;
                        break;
                    }
                }
            }

            if (GuessedCows == 4) Status = "Finished";
            else Status = "Playing";

            return $"You guessed {GuessedCows} Cows and {GuessedBulls} Bulls";
        }
    }
}

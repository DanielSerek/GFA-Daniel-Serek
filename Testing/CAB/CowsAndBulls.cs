using System;
using System.Collections.Generic;
using System.Text;

namespace CAB
{
    public class CowsAndBulls
    {
        public string Status;
        public int Guesses;
        
        public CowsAndBulls()
        {
            Status = "Playing";
            Guesses = 0;
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
        /// The method returns the user input number and checks that the number is in correct format
        /// </summary>
        /// <returns></returns>
        public string UserInput()
        {
            Console.Write("Guess the number: ");
            try
            {
                string guess = Console.ReadLine();
                if (guess.Length != 4) return "X";
                if (int.Parse(guess) >= 0 && int.Parse(guess) <= 9999)
                {
                    Guesses++;
                    return guess;
                }
                else return "X";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "X";
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
            int guessedBulls = 0;
            int guessedCows  = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guess[i] == numberToBeGuessed[i])
                    {
                        guessedCows++;
                        break;
                    }
                    else if (numberToBeGuessed[i] == guess[j])
                    {
                        guessedBulls++;
                        break;
                    }
                }
            }

            if (guessedCows == 4) Status = "Finished";
            else Status = "Playing";

            return $"You guessed {guessedCows} Cows and {guessedBulls} Bulls";
        }
    }
}

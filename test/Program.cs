using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace test
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"../../../test.txt";
            string[] swear =
                {"fuck", "bloody", "cock", "shit", "fucker", "fuckstick", "asshole", "dick", "piss", "cunt"};
            SwearWordsRead(path, swear);
        }
        static void SwearWordsRead(string pathToFile, string[] wordsToSearch)
        {
            Dictionary<string, int> swearWords = wordsToSearch.ToDictionary(word => word, word => 0, StringComparer.InvariantCultureIgnoreCase);
            var reader = new StreamReader(pathToFile);
            while (!reader.EndOfStream)
            {
                string[] arrayStrings = reader.ReadLine().ToLower().Split(" ");
                {
                    foreach (var str in arrayStrings)
                    {
                        if (swearWords.ContainsKey(str))
                        {
                            swearWords[str]++;
                        }
                    }
                }
            }
            foreach (var swearWord in swearWords)
            {
                Console.WriteLine($"Word: {swearWord.Key} || Number: {swearWord.Value}");
            }
        }
    }
}

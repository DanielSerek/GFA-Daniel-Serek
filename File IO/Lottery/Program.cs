using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = null;

            try
            {
                input = File.ReadAllLines(@"lottery.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Get the input array into a jagged array using helpArray
            string[][] splitInput = new string[input.Length][];
            string[] helpArray;

            for (int i = 0; i < input.Length; i++)
            {
                helpArray = input[i].Split(";");
                splitInput[i] = new string[helpArray.Length] ;
                splitInput[i] = helpArray;
            }

            // Get the numbers and their occurrence into a Dictionary
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();
            for (int i = 0; i < splitInput.Length; i++)
            {
                for (int j = 11; j < splitInput[i].Length; j++)
                {
                    if (numbersCount.ContainsKey(Int32.Parse(splitInput[i][j])))
                    {
                        numbersCount[Int32.Parse(splitInput[i][j])]++;
                    }
                    else numbersCount.Add(Int32.Parse(splitInput[i][j]), 1);
                }
            }

            // Sort the array by number of the occurrences
            var numbersCountSorted = numbersCount.OrderBy(x => x.Value).TakeLast(5);


            foreach (var number in numbersCountSorted)
            {
                Console.WriteLine($"{number.Key} : {number.Value}");
            }
        }
    }
}

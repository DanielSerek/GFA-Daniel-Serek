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
            //GetLotteryNumbers();
            PetraLottery();
        }


        private static void PetraLottery()
        {
            StreamReader reader = new StreamReader(@"lottery.csv");
            
            List<int> listA = new List<int>();
            List<int> listB = new List<int>();
            List<int> listC = new List<int>();
            List<int> listD = new List<int>();
            List<int> listE = new List<int>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(int.Parse(values[11]));
                listB.Add(int.Parse(values[12]));
                listC.Add(int.Parse(values[13]));
                listD.Add(int.Parse(values[14]));
                listE.Add(int.Parse(values[15]));
            }

            listA.AddRange(listB);
            listA.AddRange(listC);
            listA.AddRange(listD);
            listA.AddRange(listE);

            var dict = listA.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderBy(x => x.Count).TakeLast(5);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

        }

        static void GetLotteryNumbers()
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
                splitInput[i] = new string[helpArray.Length];
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

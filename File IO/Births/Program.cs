using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Births
{
    class Program
    {
        static void Main(string[] args)
        {

            /*    // Create a function that
            // - takes the name of a CSV file as a parameter,
            //   - every row is in the following format: <person name>;<birthdate in YYYY-MM-DD format>;<city name>
            // - returns the year when the most births happened.
            //   - if there were multiple years with the same number of births then return any one of them

            // You can find such a CSV file in this directory named births.csv
            // If you pass "births.csv" to your function, then the result should be either 2006, or 2016.*/


            string[] input = null;
            try
            {
                input = File.ReadAllLines(@"births.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            string[,] splitInput = new string[input.Length, 3];
            string[] help = new string[3];
            for (int i = 0; i < input.Length; i++)
            {
                help = input[i].Split(";");
                for (int j = 0; j < 3; j++)
                {
                    splitInput[i, j] = help[j];
                    help[j]="";
                }
            }

            Dictionary<string, int> years = new Dictionary<string, int>();
            for (int i = 0; i < splitInput.GetLength(0); i++)
            {
                if (!years.ContainsKey(splitInput[i, 1].Substring(0,4)))
                {
                    years.Add(splitInput[i, 1].Substring(0, 4), 1);
                }
                else years[splitInput[i, 1].Substring(0,4)]++;
            }

            string keyOfMaxValue = years.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; // "a"

            string maxYear = "";
            int maxValue = 0;
            foreach (var year in years)
            {
                if (year.Value > maxValue)
                {
                    maxValue = year.Value;
                    maxYear = year.Key;
                }
            }
            Console.WriteLine($"{keyOfMaxValue} : {years.Values.Max()}");
            Console.WriteLine($"{maxYear} : {maxValue}");
        }
    }
}

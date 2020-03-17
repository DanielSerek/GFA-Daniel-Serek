using System;
using System.Collections.Generic;
using System.IO;

namespace Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = null;
            try
            {
                input = File.ReadAllLines(@"../../../input.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            string[,] IPaddresses = new string[input.Length,2];
            for (int i = 0; i < input.Length; i++)
            {
                IPaddresses[i, 0] = input[i].Substring(27, 11);
                IPaddresses[i, 1] = input[i].Substring(41, 4);
            }

            List<string> uniqueAddresses = UniqueAddresses(IPaddresses);

            for (int i = 0; i < uniqueAddresses.Count; i++)
            {
                Console.WriteLine(uniqueAddresses[i]);
            }
            Console.WriteLine(uniqueAddresses.Count);

            Console.WriteLine();
            Ratio(IPaddresses);
            Console.WriteLine();

            Dictionary<string, double> result = RatioPerIndividualAddress(IPaddresses);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

        }

        static void Ratio (string[,] input)
        {
            double countPost = 0;
            double countGet = 0;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (input[i, 1].Contains("POST")) countPost++;
                if (input[i, 1].Contains("GET")) countGet++;
            }
            Console.WriteLine($"Total POSTs: {countPost}, Total GETs: {countGet}, the ratio is {countPost/countGet}");
        }

        static Dictionary<string, double> RatioPerIndividualAddress (string[,] input)
        {
            Dictionary<string, double> count = new Dictionary<string, double>();
            List<string> uniqueAddresses = UniqueAddresses(input);
            double countPost = 0;
            double countGet = 0;
            double result = 0;
            for (int i = 0; i < uniqueAddresses.Count; i++)
            {
                countGet = 0; 
                countPost = 0;
                for (int j = 0; j < input.GetLength(0); j++)
                 {
                    if (input[j, 0].Contains(uniqueAddresses[i]) && input[j, 1].Contains("POST")) countPost++;
                    if (input[j, 0].Contains(uniqueAddresses[i]) && input[j, 1].Contains("GET")) countGet++;
                }
                if (countPost == 0) result = 1;
                else if (countGet == 0) result = 0;
                else result = countGet / countPost;
                Console.WriteLine($"{uniqueAddresses[i]} contains Gets: {countGet} and Posts: {countPost}");
                count.Add(uniqueAddresses[i], result);
            }
            return count;
        }

        static List<string> UniqueAddresses(string[,] input) {
            List<string> uniqueAddresses = new List<string>();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (!uniqueAddresses.Contains(input[i,0]))
                {
                    uniqueAddresses.Add(input[i, 0]);
                }
            }
            return uniqueAddresses;
        }
    }
}

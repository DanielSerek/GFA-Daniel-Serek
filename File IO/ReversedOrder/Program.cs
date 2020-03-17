using System;
using System.IO;

namespace ReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = File.ReadAllLines(@"../../../input.txt");
                string[] output = new string[input.Length];
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    output[input.Length - i - 1] = input[i] + Environment.NewLine; // "\r\n";
                }

                string outputString = String.Concat(output); ;

                File.WriteAllText(@"../../../output.txt", outputString); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

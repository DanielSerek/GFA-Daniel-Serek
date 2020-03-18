using System;
using System.IO;

namespace EncodedLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = File.ReadAllLines(@"encoded-lines.txt");
                string[] output = new string[input.Length];
                char ch;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        ch = Convert.ToChar(input[i][j]);
                        if (ch == 32) output[i] += ch;
                        else
                        {
                            ch--;
                            output[i] += ch;
                        }
                    }
                    output[i] += Environment.NewLine;
                }
                string outputString = String.Concat(output); ;
                Console.WriteLine(outputString);
                File.WriteAllText(@"../../../output.txt", outputString); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

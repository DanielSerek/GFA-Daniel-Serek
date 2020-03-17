using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CountChars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            CountChars(@"./../../../countchar.txt");
        }

        static void CountChars(string inputFile)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();
            //string line = "";
            //int count = 1;

            try
            {
                string readcontent = File.ReadAllText(inputFile);
                //char[] charsToTrim = { ' ', '.', '-' };
                string filecontent = readcontent.Trim(' ', '.', '-');
                //string filecontent = readcontent.Replace(" ", "");
                //filecontent = filecontent.Replace(".", "");
                //filecontent = filecontent.Replace("-", "");
                Console.WriteLine(filecontent);

                for (int i = 0; i < filecontent.Length; i++)
                {
                    if (!chars.ContainsKey(filecontent[i]))
                    {
                        chars.Add(filecontent[i], 1);
                    }
                    else
                    {
                        chars[filecontent[i]] += 1; 
                    }
                }

                foreach (var character in chars)
                {
                    Console.WriteLine($"{character.Key} : {character.Value}");
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read/write into the file: " + e.Message);
            }
        }
    }
}

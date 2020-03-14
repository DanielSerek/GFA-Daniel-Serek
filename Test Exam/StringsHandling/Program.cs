using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StringsHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            FileHandling(@"./../../../inputFile.txt", @"./../../../sorted-file.txt");
        }

        static void FileHandling(string inputFile, string outputFile)
        {
            Dictionary<int, string[]> lines = new Dictionary<int, string[]>();
            string line = "";
            int count = 1;

            try
            {
                using (var reader = new StreamReader(inputFile))
                {
                    using (var writer = new StreamWriter(outputFile))
                    {
                        do
                        {
                            // Reading each line
                            line = reader.ReadLine();
                            // If line is not null or empty, we read the line and put it into a string array
                            if (!string.IsNullOrEmpty(line)) 
                            {
                                string[] lineArray = line.Split(' ');
                                // The string array is added into a Dictionary
                                lines.Add(count, lineArray);
                                count++;
                            }
                        } while (!reader.EndOfStream);

                        foreach (KeyValuePair<int, string[]> orderedLine in lines.OrderBy(key => key.Value.Length))
                        {
                            for (int i = 0; i < orderedLine.Value.Length; i++)
                            {
                                writer.Write(orderedLine.Value[i] + " ");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read/write into the file: " + e.Message);
            }
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ReadingWritingIntoAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"I found {Cleanfile(@"./../../../inputFile.txt")} dirty words.");
        }

        static int Cleanfile(string fileName)
        {
            try
            {
                string line;
                string[] dirtyWords = new string[] {  "fucker", "fuck", "fuckstick", "bloody", "cock", "shit", "asshole", "dick", "piss", "cunt" }; 

                using (var reader = new StreamReader(fileName))
                {
                    using (var writer = new StreamWriter(@"./../../../fixed-file.txt"))
                    {
                        // Counting number of dirty words
                        int count = 0;  
                        int lineNumber = 0;
                        int foundAt;

                        do
                        {
                            // Reading each line
                            line = reader.ReadLine();  
                            // If line is empty, we skip and read the next one
                            if (string.IsNullOrEmpty(line))  
                                Console.WriteLine($"Line number {lineNumber}");
                            {
                                // Going through all dirty words list
                                for (int i = 0; i < dirtyWords.Length; i++ )  
                                {
                                    // Checking whether line contains a dirty word, the whitespace is needed to make sure that is really a dirty word
                                    if (line.ToLower().Contains(" " + dirtyWords[i]))  

                                    {
                                        Console.WriteLine($"Found {dirtyWords[i]}");
                                        // Identifying the first position of a dirty word
                                        foundAt = line.ToLower().IndexOf(" " + dirtyWords[i]);
                                        // The Remove methods needs first position and number of characters to remove, needs to be increased for one whitespace
                                        line = line.Remove(foundAt, dirtyWords[i].Length + 1);
                                        count++;
                                        
                                        // Using Regex method
                                        //line = Regex.Replace(line, concat, "", RegexOptions.IgnoreCase); // Replace words without case-sensitiveness using Regex
                                    }
                                }
                                lineNumber++;
                            }
                            
                            writer.WriteLine(line);

                        } while (!reader.EndOfStream);
                        return count;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read/write into the file: " + e.Message);
                return -1;
            }

        }
    }
}

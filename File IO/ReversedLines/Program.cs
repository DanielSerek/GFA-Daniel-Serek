using System;
using System.IO;
using System.Text;

namespace ReversedLines
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseLines();
        }

        static void ReverseLines()
        {
            try
            {
                string line;
     
                StringBuilder newline = new StringBuilder();

                using (var reader = new StreamReader(@"./../../../inputFile.txt"))
                {
                    using (var writer = new StreamWriter(@"./../../../fixed-file.txt"))
                    {
                        do
                        {                      
                            line = reader.ReadLine();  // Reading each line

                            for (int i = line.Length - 1; i >= 0; i--)  // Reading characters from the end of each line to the beginning
                            {
                                newline.Append(line[i]);
                            }
                            writer.WriteLine(newline);
                            newline.Clear();   // Deleting the content of the string

                        } while (!reader.EndOfStream);
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

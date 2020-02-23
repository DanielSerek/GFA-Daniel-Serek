using System;
using System.IO;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a function that reads all lines of a file and writes the read lines to an other file (a.k.a copies the file)
            // It should take the filenames as parameters
            // It should return a boolean that shows if the copy was successful

            bool success;
            success = CopyFile(@"../../../test.txt", "../../../test2.txt");
            Console.WriteLine(success);

        }

        static bool CopyFile(string fileName, string copiedFileName) // The method returns a boolean value
        {
            bool success = false;
            try
            {
                string line;

                using(var reader = new StreamReader(fileName))
                {
                    using(var writer = new StreamWriter(copiedFileName))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                success = true; // Returns true if the file was successfully copied
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read/write into the file");
            }

            return success;
        }
    }
}

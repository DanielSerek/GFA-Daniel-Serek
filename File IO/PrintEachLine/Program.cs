using System;
using System.IO;

namespace PrintEachLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that opens a file called "my-file.txt", then prints
            // each line from the file.
            // If the program is unable to read the file (for example it does not exist),
            // then it should print the following error message: "Unable to read file: my-file.txt"

            string fileName = @"my-file.txt";

            try
            {
                StreamReader reader = new StreamReader(fileName);
                //Console.WriteLine(reader.ReadToEnd());

                string line;
                int i = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{i}: " + line);
                    i++;
                }
                reader.Dispose();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Unable to read file: {fileName}");
            }

            // Write a function that takes a filename as string,
            // then returns the number of lines the file contains.
            // It should return zero if it can't open the file, and
            // should not raise any error.
            Console.WriteLine("\n\n");
            Console.WriteLine($"The file {fileName} contains {CountLines(fileName)}. lines.");
        }
        
        static int CountLines(string fileName)
        {
            int i = 0;
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    i++;
                }
                reader.Dispose();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Unable to read file: {fileName}");
            }
            return i;
            

        }

    }
}

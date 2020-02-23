using System;
using System.IO;

namespace writingFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"./../../../lorem-ipsum.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Hello from the file!");
            }


            // Write a function that is able to manipulate a file
            // By writing your name into it as a single line
            // The file should be named "my-file.txt"
            // In case the program is unable to write the file,
            // It should print the following error message: "Unable to write file: my-file.txt"
            WriteSingleLine("Daniel Šerek");


            // Create a function that takes 3 parameters: a path, a word and a number
            // and is able to write into a file.
            // The path parameter should be a string that describes the location of the file you wish to modify
            // The word parameter should also be a string that will be written to the file as individual lines
            // The number parameter should describe how many lines the file should have.
            // If the word is 'apple' and the number is 5, it should write 5 lines
            // into the file and each line should read 'apple'
            // The function should not raise any errors if it could not write the file.
            WriteMultipleLines($"../../../I will never.txt", "I will never procrastinate", 555);

        }

        static void WriteMultipleLines (string path, string word, int num)
        {
            
            // Create and write several lines into a file
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    for (int i = 0; i < num; i++)
                    {
                        writer.WriteLine(word);
                    }                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to write file");                
            }

            StreamReader reader = new StreamReader(path);


            // Print out the file
            try
            {
                string line;
                int j = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{j}: " + line);
                    j++;
                }
                reader.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read file");
            }

        }

        // Write a single line into a file
        static void WriteSingleLine (string name)
        {
            try
            {
                string path = @"./../../../my-file.txt";
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(name);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to write file: my-file.txt");
            }


        }
    }
}

using System;
using System.IO;

namespace ReadingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Reads the content from `lorem-psum.txt` in the `assets` folder line by line to a string List
                string[] content = File.ReadAllLines(@"../../../assets/lorem-ipsum.txt");
                // Prints the first line of the file
                Console.WriteLine(content[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Uh-oh, could not read the file!");
            }

            Console.ReadLine();
        }
    }
}

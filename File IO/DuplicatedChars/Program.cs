using System;
using System.IO;

namespace DuplicatedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a method that decrypts the duplicated-chars.txt 
            Decrypt();
        }

        static void Decrypt()
        {
            try
            {
                char ch;

                using (var reader = new StreamReader(@"duplicated-chars.txt"))
                {
                    using (var writer = new StreamWriter(@"./../../../fixed-file.txt"))
                    {
                        do
                        {
                            reader.Read(); //We need to read every other character (this is void reading)
                            ch = (char)reader.Read();
                            writer.Write(ch);
                        } while (!reader.EndOfStream);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read/write into the file");
            }
        }
    }
}

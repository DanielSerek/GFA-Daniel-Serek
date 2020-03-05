using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TODOApplication
{
    public class TasksManager
    {

        public void AddNewTask(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Unable to add: no task provided");
            }
            else
            {
                using (var writer = new StreamWriter(@"./../../../tasks.txt", true)) // true is there not to overwrite existing file
                {

                    string jsonString;
                    string str = "< > ";

                    for (int i = 1; i < args.Length; i++)
                    {
                        str += args[i] + " ";
                    }

                    Console.WriteLine(str);
                    jsonString = JsonSerializer.Serialize(str);
                    writer.WriteLine(jsonString);
                }
            }
        }

        public void ListAllTasks()
        {
            using (var reader = new StreamReader(@"./../../../tasks.txt"))
            {
                int lineNumber = 1;
                string line;
                string deserializedLine;
                try
                {
                    do
                    {
                        // Reading file
                        line = reader.ReadLine();
 
                        // Checking it the file is empty
                        if (string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("No todos for today.");
                            break;
                        }

                        // Deserializing file
                        deserializedLine = JsonSerializer.Deserialize<string>(line);
                        Console.WriteLine($"{lineNumber} -  {deserializedLine}");
                        lineNumber++;
                    } while (!reader.EndOfStream);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void RemoveTask(string[] args)
        {

            if      (ErrorHandling(args) == 1) { Console.WriteLine("Unable to remove: no index provided"); }
            else if (ErrorHandling(args) == 2) { Console.WriteLine("Unable to remove: index is not a number"); }
            else if (ErrorHandling(args) == 3) { Console.WriteLine("Unable to remove: index is out of bound"); }
            else
            {
                try
                {
                    // Read file into a List, remove specific line and write the list into a new file
                    List<string> linesList = File.ReadAllLines(@"./../../../tasks.txt").ToList();
                    linesList.RemoveAt(Int32.Parse(args[1]) - 1);
                    File.WriteAllLines(@"./../../../tasks.txt", linesList.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void CheckTask(string[] args)
        {
            if      (ErrorHandling(args) == 1) { Console.WriteLine("Unable to check: no index provided"); }
            else if (ErrorHandling(args) == 2) { Console.WriteLine("Unable to check: index is not a number"); }
            else if (ErrorHandling(args) == 3) { Console.WriteLine("Unable to check: index is out of bound"); }
            else 
            {
                try
                {
                    // Read file into a list
                    List<string> linesList = File.ReadAllLines(@"./../../../tasks.txt").ToList();
                    // Deserialize the item from the list into a string
                    string lineToBeChecked = JsonSerializer.Deserialize<string>(linesList[Int32.Parse(args[1]) - 1]);
                    // Replace < > with <X>
                    if (lineToBeChecked.Contains("< >")) lineToBeChecked = lineToBeChecked.Replace("< >", "<X>");
                    // Serialize the string back
                    string jsonString = JsonSerializer.Serialize(lineToBeChecked);
                    // Put the string back to the list
                    linesList[Int32.Parse(args[1]) - 1] = jsonString;
                    // Write all list into a new file
                    File.WriteAllLines(@"./../../../tasks.txt", linesList.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public int ErrorHandling(string[] args)
        {
            if (args.Length < 2)
            {
                return 1;
            }
            // Checks whether the string contains a number
            else if (!args[1].All(char.IsDigit))
            {
                return 2;
            }
            else if (args.Length < Int32.Parse(args[1]) || Int32.Parse(args[1]) < 1)
            {
                return 3;
            }
            
            else return 0;
        }
    }
}

using Newtonsoft.Json;
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

        // This method reads the objects into a list and gets the number of objects
        public void CheckTheFile()
        {
            using (var reader = new StreamReader(@"./../../../tasks.txt"))
            {
                string line;
                try
                {
                    do
                    {
                        line = reader.ReadLine();
                        Task.TasksList.Add(JsonConvert.DeserializeObject<Task>(line));
                    } while (!reader.EndOfStream);
                    // Get a number of objects in the file
                    Task.TaskNumber = Task.TasksList.Count();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

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
                    // Get all the arguments from the command line into one concatenated string
                    string str = "";
                    for (int i = 1; i < args.Length; i++)
                    {
                        str += args[i] + " ";
                    }

                    Task.TasksList.Add(new Task(str, false));
                    Console.WriteLine($"taskslist count: {Task.TasksList.Count}, tasknumber: {Task.TaskNumber}");
                    string jsonString = JsonConvert.SerializeObject(Task.TasksList[Task.TaskNumber]);
                    writer.WriteLine(jsonString);
                    Task.TaskNumber++;
                }
            }
        }

        public void ListAllTasks()
        {
            using (var reader = new StreamReader(@"./../../../tasks.txt"))
            {
                string line;
                int objectsCount = 0;
                try
                {
                    do
                    {
                        // Reading file
                        line = reader.ReadLine();
 
                        // Checking if the file is empty
                        if (string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("No todos for today.");
                            break;
                        }

                        // Deserializing file
                        Task task = JsonConvert.DeserializeObject<Task>(line);
                        
                        // Reading the boolean status of the task
                        string checkStatus = "<X>";
                        if (!task.Status) checkStatus = "< >";

                        Console.WriteLine($"{objectsCount + 1} - {checkStatus} {task.TaskContent}");
                        objectsCount++;
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

            if      (args.Length < 2)                           { Console.WriteLine("Unable to remove: no index provided"); }
            else if (!args[1].All(char.IsDigit))                { Console.WriteLine("Unable to remove: index is not a number"); }
            else if (Task.TaskNumber < Int32.Parse(args[1]))    { Console.WriteLine("Unable to remove: index is out of bound"); }
            else
            {
                try
                {
                    // Read file into a List, remove specific line and write the list into a new file
                    List<string> linesList = File.ReadAllLines(@"./../../../tasks.txt").ToList();
                    linesList.RemoveAt(Int32.Parse(args[1]) - 1);
                    Task.TaskNumber = linesList.Count;
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
            try
            {
                if      (args.Length < 2)                           { Console.WriteLine("Unable to check: no index provided"); }
                else if (!args[1].All(char.IsDigit))                { Console.WriteLine("Unable to check: index is not a number"); }
                else if (Task.TaskNumber < Int32.Parse(args[1]))    { Console.WriteLine("Unable to check: index is out of bound"); }
                else
                {
                    string lineToWrite = "";
                    string jsonString = "";

                    using (StreamReader reader = new StreamReader(@"./../../../tasks.txt"))
                    {
                        // Read the file until the line with the object that needs to be checked is reached
                        for (int i = 1; i <= Int32.Parse(args[1]); ++i)
                            lineToWrite = reader.ReadLine();

                        // Deserialize the task object and change its status
                        Task task = JsonConvert.DeserializeObject<Task>(lineToWrite);
                        if (task.Status) task.Status = false;
                        else task.Status = true;

                        // Serialize the task object back
                        jsonString = JsonConvert.SerializeObject(task);
                    }

                    // Get the original file into a string array (needs to be used for file rewriting)
                    string[] lines = File.ReadAllLines(@"./../../../tasks.txt");

                    using (StreamWriter writer = new StreamWriter(@"./../../../tasks.txt"))
                    {
                        for (int i = 1; i <= lines.Length; ++i)
                        {
                            // When the right line is reached, the object is replaced
                            if (i == Int32.Parse(args[1]))
                            {
                                writer.WriteLine(jsonString);
                            }
                            // Otherwise the rest of the lines are saved as they were (using previous string array)
                            else
                            {
                                writer.WriteLine(lines[i - 1]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

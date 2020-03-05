using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TODOApplication
{
    class TODO_app
    {
        static void Main(string[] args)
        {
            TasksManager tasksManager = new TasksManager();

            //For testing purpose only
            //string[] test = new string[2];
            //test[0] = "-r";
            //test[1] = "apple";
            //tasksManager.RemoveTask(test);

            if (args.Length == 0)
            {
                Console.WriteLine("Command Line Todo application\n=============================\n");
                Console.WriteLine("Command line arguments:\n-l   Lists all the tasks\n-a   Adds a new task\n" +
                                                        "-r   Removes a task\n-c   Completes a task");
            }

            if (args.Length > 0) 
            {
                switch (args[0])
                {
                    case "-a":
                        tasksManager.AddNewTask(args);
                        break;;

                    case "-l":
                        tasksManager.ListAllTasks();
                        break;;

                    case "-r":
                        tasksManager.RemoveTask(args);
                        break;;

                    case "-c":
                        tasksManager.CheckTask(args);
                        break;

                    default:
                        Console.WriteLine("Unsupported argument");
                        break;
                }
            }
        }
    }
}

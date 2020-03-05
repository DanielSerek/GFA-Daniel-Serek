using System;
using System.Collections.Generic;
using System.Text;

namespace TODOApplication
{
    public class Task
    {
        public string TaskContent;
        public bool   Status;
        public static int TaskNumber = 0;
        public static List<Task> TasksList = new List<Task>();

        public Task(string task, bool status)
        {
            TaskContent = task;
            Status = status;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TODOApplication
{
    public class Tasks
    {
        public string Task;
        public bool   Completed;

        public Tasks(string task, bool completed)
        {
            Task = task;
            Completed = completed;
        }



    }
}

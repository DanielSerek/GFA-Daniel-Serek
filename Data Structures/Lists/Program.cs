using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("William");
            Console.WriteLine(!names.Any()? "empty": "not empty");
            names.Add("John");
            names.Add("Amanda");
            Console.WriteLine(names.Count());
            Console.WriteLine(names[2]);
            Console.WriteLine("\n");

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine("\n");

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(i+1 + ". " + names[i]);
            }

            Console.WriteLine("\n");

            names.RemoveAt(1);

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine("\n");

            for (int i = names.Count - 1; i >=0; i--)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine("\n");
            names.Clear();
            Console.WriteLine(!names.Any() ? "empty" : "not empty");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listA = new List<string>();
            listA.Add("Apple");
            listA.Add("Avocado");
            listA.Add("Blueberries");
            listA.Add("Durian");
            listA.Add("Lychee");

            // copy list B into list A 
            List<string> listB = new List<string>(listA);
            listB.Remove("Durian");
            listA.Add("Kiwifruit");

            foreach (string item in listB)
            {
                Console.WriteLine(item);
            }

            string x = null;
            Console.WriteLine(listA.Count);
            Console.WriteLine(listB.Count);
            if (listA.Count >= listB.Count)
            {   
                x = "List A is the same or longer than list B";
            }
            else
            {
                x = "List B is longer than list A";
            }
            Console.WriteLine(x);

            Console.WriteLine(listA.IndexOf("Avocado"));
            Console.WriteLine(listB.IndexOf("Durian"));

            // Addition multiple items at the same time
            listB.AddRange(new string[]
            {
            "Passion Fruit",
            "Pomelo"
            });
            foreach (string item in listB)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n");
            Console.WriteLine(listA[2]);
        }
    }
}

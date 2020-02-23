using System;
using System.Collections.Generic;
using System.Linq;

namespace Map_introduction_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>(); 
            map.Add("978-1-60309-452-8", "A Letter to Jo");
            map.Add("978-1-60309-459-7", "Lupus");
            map.Add("978-1-60309-444-3", "Red Panda and Moon Bear");
            map.Add("978-1-60309-461-0", "The Lab");

            foreach (KeyValuePair<string, string> pair in map)
            {
                Console.WriteLine(pair.Value + " (ISBN: " + pair.Key + ")");
            }
            Console.WriteLine("\n");

            map.Remove("978-1-60309-444-3");
         
            // Remove item in the dictionary using a value
            foreach (KeyValuePair<string, string> pair in map)
            {
                Console.WriteLine(pair.Value + " (ISBN: " + pair.Key + ")");
                if (pair.Value == "The Lab")
                {
                    map.Remove(pair.Key);
                }
            }
            Console.WriteLine("\n");

            foreach (KeyValuePair<string, string> pair in map)
            {
                Console.WriteLine(pair.Value + " (ISBN: " + pair.Key + ")");
            }
            Console.WriteLine("\n");

            map.Add("978-1-60309-450-4", "They Called Us Enemy");
            map.Add("978-1-60309-453-5", "Why Did We Trust Him?");
            // map.Add("478-0-61159-424-8", "For testing");


            //Vytisknout hodnoty key a value v různém pořadí
            foreach (KeyValuePair<string, string> pair in map)
            {
                Console.WriteLine(pair.Value + " (ISBN: " + pair.Key + ")");
            }
            Console.WriteLine("\n");


            //Check if the dictionary contains a specific number
            if (!map.ContainsKey("478-0-61159-424-8"))
            {
                Console.WriteLine("The dictionary does not contain the number \"478 - 0 - 61159 - 424 - 8\""); 
            }
            else
            {
                Console.WriteLine("The dictionary contains the number");
            }


            //Lookup a value based on a key and print it out
            string test;    
            if(map.TryGetValue("978-1-60309-453-5", out test));
            Console.WriteLine(test);

        }
    }
}

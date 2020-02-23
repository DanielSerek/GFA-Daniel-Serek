using System;
using System.Collections.Generic;
using System.Linq;

namespace HashSet_use
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: input array that contains three duplicate strings.
            string[] array1 =
            {
            "cat",
            "dog",
            "cat",
            "leopard",
            "tiger",
            "cat"
        };

            // Part 2: use HashSet constructor to ensure unique strings.
            var hash = new HashSet<string>(array1);

            // Part 3: convert to array of strings again.
            string[] array2 = hash.ToArray();

            // Part 4: display the resulting array.
            Console.WriteLine(string.Join(",", array2));
        }
    }
    
}

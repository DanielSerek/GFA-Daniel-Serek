using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = new List<string>();
            shoppingList.Add("Eggs");
            shoppingList.Add("Milk");
            shoppingList.Add("Fish");
            shoppingList.Add("Apples");
            shoppingList.Add("Bread");
            shoppingList.Add("Chicken");

            Console.Write("What item would you like to check? ");
            string item = Console.ReadLine(); 

            // Check if a list contains a specific item
            if (shoppingList.Contains(item))
            {
                Console.WriteLine($"The shopping list contains {item}.");
            }
            else
            {
                Console.WriteLine($"The shopping list does not contain {item}.");
            }


        }
    }
}

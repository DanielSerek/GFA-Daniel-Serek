using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_database
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> productsDatabase = new Dictionary<string, int>();
            productsDatabase.Add("Eggs", 200);
            productsDatabase.Add("Milk", 200);
            productsDatabase.Add("Fish", 400);
            productsDatabase.Add("Apples", 150);
            productsDatabase.Add("Bread", 50);
            productsDatabase.Add("Chicken", 550);

            // Find a product price
            int findPrice;
            if (productsDatabase.TryGetValue("Fish", out findPrice)) Console.WriteLine(findPrice);

            // What is the most expensive product, average price, number of products below 300
            int mostExpensiveProduct = 0;
            int count = 0;
            double sum = 0;
            int productsBelow300 = 0;
            bool buy = false;
            string cheapestProduct = null;
            int lowestPrice = productsDatabase.Values.First();


            foreach (KeyValuePair<string, int> pair in productsDatabase)
            {

                if (pair.Value > mostExpensiveProduct)
                {
                    mostExpensiveProduct = pair.Value;
                }
                if (pair.Value < 300) productsBelow300++;
                sum += pair.Value;
                count++;
                if (pair.Value == 125) buy = true;
                if (pair.Value < lowestPrice) cheapestProduct = pair.Key;

            }
            Console.WriteLine($"The most expensive product costs: {mostExpensiveProduct}.");
            Console.WriteLine($"The average price is: {sum / count}.");
            Console.WriteLine($"{productsBelow300} products are below 300.");
            Console.WriteLine($"We can buy something for 125: {buy}");
            Console.WriteLine($"The cheapest product is: {cheapestProduct}");

            // Which products cost less than 201
            Console.WriteLine("\nProducts that cost less than 201");
            foreach (KeyValuePair<string, int> pair in productsDatabase)
            {
                if (pair.Value < 201)
                {
                    Console.WriteLine(pair.Key);
                }
            }

            // Which products cost more thna 150
            Console.WriteLine("\nProducts that cost more than 150");
            foreach (KeyValuePair<string, int> pair in productsDatabase)
            {
                if (pair.Value > 150)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}

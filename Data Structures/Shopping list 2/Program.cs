using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_list_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> shoppingList = new Dictionary<string, double>();
            shoppingList.Add("Milk", 1.07);
            shoppingList.Add("Rice", 1.59);
            shoppingList.Add("Eggs", 3.14);
            shoppingList.Add("Cheese", 12.60);
            shoppingList.Add("Chicken Breasts", 9.40);
            shoppingList.Add("Apples", 2.31);
            shoppingList.Add("Tomato", 2.58);
            shoppingList.Add("Potato", 1.75);
            shoppingList.Add("Onion", 1.10);

            Dictionary<string, double> bobShoppingList = new Dictionary<string, double>();
            bobShoppingList.Add("Milk", 3);
            bobShoppingList.Add("Rice", 2);
            bobShoppingList.Add("Eggs", 2);
            bobShoppingList.Add("Cheese", 1);
            bobShoppingList.Add("Chicken Breasts", 4);
            bobShoppingList.Add("Apples", 1);
            bobShoppingList.Add("Tomato", 2);
            bobShoppingList.Add("Potato", 1);

            Dictionary<string, double> aliceShoppingList = new Dictionary<string, double>();
            aliceShoppingList.Add("Rice", 1);
            aliceShoppingList.Add("Eggs", 5);
            aliceShoppingList.Add("Chicken Breasts", 2);
            aliceShoppingList.Add("Apples", 1);
            aliceShoppingList.Add("Tomato", 10);


            //How much does Bob pay?
            double bobPay = 0;
            foreach (KeyValuePair<string, double> pair in shoppingList)
            {
                foreach (KeyValuePair<string, double> bob in bobShoppingList)
                {
                    if (pair.Key == bob.Key)
                    {
                        bobPay += pair.Value * bob.Value;
                    }
                }
            }
            Console.WriteLine("Bob pays: " + bobPay + "\n");


            //How much does Alice pay?
            double alicePay = 0;
            foreach (KeyValuePair<string, double> pair in shoppingList)
            {
                foreach (KeyValuePair<string, double> alice in aliceShoppingList)
                {
                    if (pair.Key == alice.Key)
                    {
                        alicePay += pair.Value * alice.Value;
                    }
                }
            }
            Console.WriteLine("Alice pays: " + alicePay + "\n");


            //Who buys more "something"?
            Console.WriteLine(checkWhoBuysMore("Rice", bobShoppingList, aliceShoppingList));
            Console.WriteLine(checkWhoBuysMore("Potato", bobShoppingList, aliceShoppingList));
            Console.WriteLine("\n");
 

            //Who buys more products in total?
            if (differentProducts(bobShoppingList, aliceShoppingList) == "Both")
            {
                Console.WriteLine("Both buy the same amount of products");
            }
            else
            {
                Console.WriteLine(differentProducts(bobShoppingList,aliceShoppingList) + " buys more kinds of products.");
            }
            Console.WriteLine("\n");


            //Who buys more pieces óf products?
            Console.WriteLine(whoBuysMorePieces(bobShoppingList, aliceShoppingList) + " buys more pieces.");

        }

        static string checkWhoBuysMore (string keyWord, Dictionary<string, double> bobShoppingList, Dictionary<string, double> aliceShoppingList)
        {
            string output = null;
            foreach (KeyValuePair<string, double> bob in bobShoppingList)
            {
                foreach (KeyValuePair<string, double> alice in aliceShoppingList)
                {

                    if (bob.Key == keyWord && alice.Key == keyWord )
                    {                                              
                        if ((bob.Value > alice.Value) || (alice.Value == 0 && bob.Value != 0))
                        {
                            output = "Bob buys more " + keyWord;
                        }
                        else if ((bob.Value < alice.Value) || (bob.Value == 0 && alice.Value != 0))
                        {
                            output = "Alice buys more " + keyWord;
                        }
                        else
                        {
                            output = "Both of them buy the same amount of " + keyWord;
                        }
                    }

                    if (bob.Key == keyWord && alice.Key != keyWord)
                    {
                        output = "Bob buys more " + keyWord;
                    }
                    else if (alice.Key == keyWord && alice.Key != keyWord)
                    {
                        output = "Alice buys more " + keyWord;
                    }
                }
            }
            if (output == null)
            {
                output = "The keyword was not found.";
            }
            return output;
        }

        static string differentProducts(Dictionary<string, double> bobShoppingList, Dictionary<string, double> aliceShoppingList)
        {
            int aliceCounter = 0;
            int bobCounter = 0;
            string who = null;
            aliceCounter = aliceShoppingList.Count;
            bobCounter = bobShoppingList.Count;

            if (aliceCounter > bobCounter)
            {
                who = "Alice";
            }
            else if (aliceCounter < bobCounter)
            {
                who = "Bob";
            }
            else
            {
                who = "Both";
            }
            return who;
        }

        static string whoBuysMorePieces (Dictionary<string, double> bobShoppingList, Dictionary<string, double> aliceShoppingList)
        {
            double aliceCounter = 0;
            double bobCounter = 0;
            string who = null;

            foreach (KeyValuePair<string, double> bob in bobShoppingList)
            {
                bobCounter += bob.Value;
            }
            Console.WriteLine("Bob buys " + bobCounter + " pieces.");

            foreach (KeyValuePair<string, double> alice in aliceShoppingList)
            {
                aliceCounter += alice.Value;
            }
            Console.WriteLine("Alice buys " + aliceCounter + " pieces.");

            if (aliceCounter > bobCounter)
            {
                who = "Alice";
            }
            else if (aliceCounter < bobCounter)
            {
                who = "Bob";
            }
            else
            {
                who = "Both";
            }
            return who;
        }
    }
}

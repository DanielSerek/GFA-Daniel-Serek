using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> telephoneBook = new Dictionary<string, string>();
            telephoneBook.Add("William A. Lathan", "405-709-1865");
            telephoneBook.Add("John K. Miller", "402-247-8568");
            telephoneBook.Add("Hortensia E. Foster", "606-481-6467");
            telephoneBook.Add("Amanda D. Newland", "319-243-5613");
            telephoneBook.Add("Brooke P. Askew", "307-687-2982");

            foreach (KeyValuePair<string, string> pair in telephoneBook)
            {
                Console.WriteLine(pair.Value + " (" + pair.Key + ")");
            }
            Console.WriteLine("\n");

            string getNumber;
            if (telephoneBook.TryGetValue("John K. Miller", out getNumber)) 
            Console.WriteLine(getNumber);


            // Look up a key using a value
            foreach (KeyValuePair<string, string> pair in telephoneBook)
            {
                if (pair.Value == "307-687-2982")
                {
                    Console.WriteLine(pair.Key); 
                }
            }


            // Check if a key exists in the dictionary
            if(telephoneBook.ContainsKey("Chris E. Myers"))
            {
                Console.WriteLine("The number exists.");
            }
            else
            {
                Console.WriteLine("The number does not exist.");
            }

        }
    }
}

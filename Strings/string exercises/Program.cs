using System;
using System.Text;

namespace string_exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            string example = "In a dishwasher far far away";
            example = example.Replace("dishwasher", "galaxy");
            Console.WriteLine(example);
            Console.WriteLine("\n");


            string url = "https//www.reddit.com/r/nevertellmethebots";
            // Accidentally I got the wrong URL for a funny subreddit. It's probably "odds" and not "bots"
            // Also, the URL is missing a crucial component, find out what it is and insert it too!
            // Try to solve it more than once using different string functions!

            url = url.Replace("bots", "odds");
            url = url.Insert(5, ":");            
            Console.WriteLine(url);
            Console.WriteLine("\n");


            StringBuilder quote = new StringBuilder();
            quote.Append("Hofstadter's Law: It you expect, even when you take into account Hofstadter's Law.");
            quote.Insert(21, "always takes longer than ");
            // When saving this quote a disk error has occured. Please fix it.
            // Add "always takes longer than" to the StringBuilder (quote) between the words "It" and "you"
            // Using pieces of the quote variable (instead of just redefining the string)
            Console.WriteLine(quote);
            Console.WriteLine("\n");

            // Add "My todo:" to the beginning of the todoText
            // Add " - Download games" to the end of the todoText
            // Add " - Diablo" to the end of the todoText but with indentation

            // Expected output:

            // My todo:
            //  - Buy milk
            //  - Download games
            //      - Diablo

            string toDoText = " - Buy milk\n";
            toDoText = toDoText.Insert(0, "My todo: \n");
            toDoText += " - Download games\n";
            toDoText += "\t- Diablo";
            Console.WriteLine(toDoText);
            Console.WriteLine("\n");



            // Create a method that can reverse a String, which is passed as the parameter
            // Use it on this reversed string to check it!

            string reversed = ".eslaf eb t'ndluow ecnetnes siht ,dehctiws erew eslaf dna eurt fo sgninaem eht fI";
            Console.WriteLine(Reverse(reversed));




        }

        static string Reverse (string input)
        {
            string output = null;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;
        }


    }
}

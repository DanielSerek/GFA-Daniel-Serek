using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesAsFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Page  
    {
        public string Content;
    }

    class Book
    {
        private List<Page> Pages; // List of objects - "Pages" with string content

        public Book()   // Constructor - creates instances of Books
        {
            Pages = new List<Page>();
        }

        public void Add(Page page) // Methods - creates new pages
        {
            Pages.Add(page);
        }

        public int CountBlankPages()
        {
            int counter = 0;
            foreach (var page in Pages)
            {
                if (!page.Content.Any())
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Personal_Finance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> expenses = new List<int>();
            expenses.Add(500);
            expenses.Add(1000);
            expenses.Add(1250);
            expenses.Add(175);
            expenses.Add(800);
            expenses.Add(120);

            double sum = 0;
            int max = 0;
            int min = expenses[0];
            int count = 0;
            foreach (int expense in expenses)
            {
                sum += expense;
                if (expense > max)
                {
                    max = expense;
                }
                if (expense < min)
                {
                    min = expense;
                }
                count++;
            }

            Console.WriteLine($"We spent in total: {sum}");
            Console.WriteLine($"Our greatest expense was: {max}");
            Console.WriteLine($"Our cheapest expense was: {min}");
            Console.WriteLine($"The average amount of spending was: {sum/count}");
        }
    }
}

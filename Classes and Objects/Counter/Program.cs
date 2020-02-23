using System;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter count1 = new Counter(0);
            Console.WriteLine($"The number is: {count1.Get()}");

            count1.Add();
            Console.WriteLine($"The number is: {count1.Get()}");

            count1.Reset();
            Console.WriteLine($"The number is: {count1.Get()}");
            
            count1.Add(27);
            Console.WriteLine($"The number is: {count1.Get()}");
        }
    }
}

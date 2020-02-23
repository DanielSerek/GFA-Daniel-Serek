using System;

namespace Power___recursive
{
    class Program
    {
        static void Main(string[] args)
        {

            // Given base and n that are both 1 or more, compute recursively(no loops) the value of base to the n power, so powerN(3, 2) is 9(3 squared).
            Console.WriteLine(Power(2, 4));
                            
        }


        public static int Power(int baseNumber, int n)
        {
            if (n == 1) return baseNumber;
            else return baseNumber *= Power(baseNumber, n - 1);
        }
    }
}

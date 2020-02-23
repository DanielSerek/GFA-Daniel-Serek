using System;
using System.Collections.Generic;
using System.Text;

namespace ComparableInterface
{
    public class Domino : IComparable<Domino>, IPrintable
    {
        public readonly int[] values;

        public Domino(int valueA, int valueB)
        {
            this.values = new int[] { valueA, valueB };
        }

        public int CompareTo(Domino other)
        {
            if (values[0] + values[1] > other.values[0] + other.values[1]) return 1;
            else if (values[0] + values[1] < other.values[0] + other.values[1]) return -1;
            else return 0;
            //return values[0].CompareTo(other.values[0]);
        }

        public int[] GetValues()
        {
            return values;
        }

        public void PrintAllFields(int a, int b)
        {
            Console.WriteLine($"{a} : {b}");
        }
    }
}

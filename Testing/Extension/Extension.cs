using System;
using System.Collections.Generic;

namespace Extension
{

    public class Extension
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int MaxOfThree(int a, int b, int c)
        {
            if ((a >= b) && (a >= c)) return a;
            if ((b >= a) && (b >= c)) return b;
            if ((c >= a) && (c >= b)) return c;
            else return -1;
        }

        public double Median(List<int> pool)
        {
            List<int> sortedPNumbers = new List<int>(pool);
            sortedPNumbers.Sort();
            int mid = sortedPNumbers.Count / 2;

            if (sortedPNumbers.Count % 2 != 0) return sortedPNumbers[mid];
            else return ((sortedPNumbers[mid] + sortedPNumbers[mid - 1]) / 2);
        }

        public bool IsVowel(char c)
        {
            return (new List<char>() { 'a', 'u', 'o', 'e', 'i' }).Contains(c);
        }

        public string Translate(string hungarian)
        {
            string teve = hungarian;
            int length = teve.Length;
            for (int i = 0; i < length; i++)
            {
                char c = teve[i];
                if (IsVowel(c))
                {
                    teve = string.Join(c + "v" + c, teve.Split(c));
                    i += 2;
                    length += 2;
                }
            }

            return teve;
        }
    }
}

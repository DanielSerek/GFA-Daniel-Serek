using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci
{
    class Calculation
    {
        public int Calculate(int n)
        {
            if (n <= 1) return n;
            else return Calculate(n - 2) + Calculate(n - 1);
        }
    }
}

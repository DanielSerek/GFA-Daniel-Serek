using System;
using System.Collections.Generic;
using System.Text;

namespace Apples
{
    /*Create a sum method in your class which takes a List of integers as parameter
        It should return the sum of the elements in the list */
    class Sum
    {
        public int SumOfTheList(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0) return 0;
            //if ((numbers ?? new List<int>()).Count == 0) return 0;
            if (numbers.Count == 1) return numbers[0];

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }


    }
}

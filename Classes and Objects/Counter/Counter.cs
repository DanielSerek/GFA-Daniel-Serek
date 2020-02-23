using System;
using System.Collections.Generic;
using System.Text;

namespace Counter
{
    class Counter
    {
        public int Num;
        public int initialValue;

        public Counter (int num)
        {
            string input = Console.ReadLine();

            try
            {
                 num = Int32.Parse(input);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                num = 0;
            }

            Num = num;
            initialValue = num;
        }

        public string Get() // Get the current value as string
        {
            string num = Num.ToString();
            return num;
        }

        public void Add()  // Increase the counter's value by one
        {
            Num++;
        }

        public void Add(int num)  // Add to the counter another whole number
        {
            Num = num;
        }

        public void Reset()  // Reset to the initial value
        {
            Num = initialValue;
        }

    }
}

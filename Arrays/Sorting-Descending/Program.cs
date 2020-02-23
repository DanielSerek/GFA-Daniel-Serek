using System;

namespace Sorting_Descending
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 0, 12, 4, 6, 14, 3, 7, 6, 9 };
            SelectionSort(test);

            foreach (int item in test)
            {
                Console.Write(item + " ");
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[maxIndex]) maxIndex = j;
                }
                int tmp = array[i];
                array[i] = array[maxIndex];
                array[maxIndex] = tmp;
            }
        }

    }
}

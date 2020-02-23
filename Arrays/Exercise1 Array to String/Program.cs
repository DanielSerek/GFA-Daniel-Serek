using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 4, 5, 6, 77, 89 };
            Console.WriteLine(array2String(array));
        }

        static string array2String(int[] arr)
        {
            string ret = "[";
            for(int i=0; i < arr.Length; i++)
            {
                ret += arr[i].ToString();
                if (i < arr.Length - 1) ret += ", ";
            }
            return ret + "]";
        }

    }

}

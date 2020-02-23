using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "xrejxsjx..x..x.ss.d.x.s...x.X";
            str = str.ToLower();
            Console.WriteLine(ReplaceX(str));
        }

        public static string ReplaceX(string str)
        {
            if (str.Length == 0) return "";
            Console.WriteLine(str);

            if (str.Contains('x')) // If string contains 'x' character, find it and remove it
            {
                int index = str.IndexOf(@"x");  
                str = str.Remove(index, 1);
                return ReplaceX(str);
            }
            else return str; // If strind does not contain 'x', return existing string
  
        }


    }
}

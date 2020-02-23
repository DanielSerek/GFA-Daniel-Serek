using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
         
            string input = "this searching is what I'm  in";
            string q = "searching";

            int position = -1;
            bool match = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == q[0])
                {
                    match = true;
                    position = i;
                    for (int j = 0; j < q.Length; j++)
                    {
                        if (i + j >= input.Length || input[i + j] != q[j])
                        {
                            match = false;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(match + " " + position);

            if (match)
            {
                Console.WriteLine("The position of sentence is: " + position);
            }



        }
    }
}

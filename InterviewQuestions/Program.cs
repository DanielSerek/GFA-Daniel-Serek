using System;
using System.Collections;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            // https://ozanecare.com/c-interview-questions-and-answers/

            
            // Guess the output of the following code - the result is 1
            int i;
            for (i = 10; i > 1; i--); // when i = 1 the condition is false and the number is passed to the next line
                Console.WriteLine(i);


            // Guess the output following codes - the result is 0
            i = 10;
            while (i-- > 1) ; // when i = 1 the condition is false, it terminates the loop and it also decrease i value because post decrements (i-_
            Console.WriteLine(i);


            // Guess the output following codes
            i = 1;
            while (i++ < 11 - ++i) ;  // 1 < 11 - 3 (9), 3 < 11 - 5 (6), when i = 7 the condition is false and the code goes to the next line
            {
                Console.Write(i + "\t");
                i++;
            }
            Console.WriteLine();
            

            // Guess the output following codes 10 6 2 -2 -6 -10 -14
            i = 10;
            for (; ; )  // for(initialize; condition; increment/decrement)
            {
                Console.Write(i + " ");
                if (i >= -10)
                    i -= 4;
                else
                    break;
            }
            Console.WriteLine();



            // Guess the output following codes
            for (i = 0; i < 10; ++i)
            {
                Console.Write(i + ' ');  // ASCII for space is 32, space character is transformed into a ASCII number
            }
            Console.WriteLine();


            // Guess the output following codes
            ArrayList a1 = new ArrayList();   // ArrayList is used to store elements of any data types
            a1.Add(1);   // integer
            a1.Add('1'); // character
            a1.Add("1"); // string
            Console.Write(a1[0]);
            Console.Write(a1[1]);
            Console.Write(a1[2]);
            Console.WriteLine();

                       
            // What will be the output?
            // Answer:https://youtu.be/woJzwnWoCnQ
            // Jagged array = array of an arrays, can store arrays in which length of each array index can differ
            int[][] x = new int[3][];
            x[0] = new int[1];  // the first array has just one element with "0"
            x[1] = new int[2];  // the second array has two elements with "0"
            x[2] = new int[5] { 66, 'C', 67, 68, 69 }; // Character C is converted to ASCII of 67
            Console.Write(x[2][1]);
            Console.WriteLine();


            // Guess the output following codes
            i = 25;
            string s = (i++ < 15) ? "Cardiff" : (i++ < 25) ? "London" : "Monaco";
            Console.WriteLine(s);
            Console.WriteLine(i);


            // Guess the output following codes
            i = 6;
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            i = arr[arr[i] / 2];  // i = 4
            Console.WriteLine(arr[i]/2); // 2




            // Guess the output following codes
            float j = 10;
            double d = 35.56;
            fun(j);  // Float datatype is sub datatype of double, it is executed as float
            fun(d);  // it is executed as double

        }

        static void fun (double d)
        {
            Console.WriteLine(d);
        }
    }
}

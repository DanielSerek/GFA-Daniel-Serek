using System;
using System.IO;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = null;
            try
            {
                input = File.ReadAllLines(@"../../../win-o.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            string result = null;
            for (int i = 0; i < input.Length; i++)
            {
                if      (AllHorizontalLine(i, input) && input[i][0] == 'X') result = "X won";
                else if (AllHorizontalLine(i, input) && input[i][0] == 'O') result = "O won";
                else if (AllVerticalLine(i, input) && input[0][i] == 'X')   result = "X won";
                else if (AllVerticalLine(i, input) && input[0][i] == 'O')   result = "O won";
                else if (DiagonalLeft(input) == 'X')                        result = "X won";
                else if (DiagonalRight(input) == 'O')                       result = "O won";
            }
            if (string.IsNullOrEmpty(result)) result = "Draw";
            Console.WriteLine(result);
        }

        static bool AllHorizontalLine(int lineNumber, string[] input) => input[lineNumber].All(ch => ch == input[lineNumber][0]);

        static bool AllVerticalLine(int row, string[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[0][row] != input[i][row]) return false;
            }
            return true;
        }

        static char DiagonalLeft(string[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[0][0] != input[i][i]) return '0';
            }
            return input[0][0];
        }

        static char DiagonalRight(string[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[0][input.Length - 1] != input[i][input.Length - 1 - i]) return '0';
            }
            return input[0][0];
        }
    }
}



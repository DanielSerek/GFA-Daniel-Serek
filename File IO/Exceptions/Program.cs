using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try  // Prevents the program breaking when attempting dividing by zero
            {
                int divisor = int.Parse(Console.ReadLine());
                // If the input value for divisor was 0 the program breaks
                int result = 12 / divisor;
                // The program doesn't reach this line if the input was 0
                Console.WriteLine(result);
            }
            catch (DivideByZeroException e)
            {
                // This line only runs if the input was 0
                Console.WriteLine("Can't divide by zero!");
            }
            catch (Exception e)
            {
                // This line only runs if uncatched exception generated
                Console.WriteLine("uuups, some serious thing happened!");
            }
            finally
            {
                Console.ReadLine();
            }

        }

    }
}

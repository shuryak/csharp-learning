using System;

namespace ExcFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            try
            {
                Console.WriteLine("Result: " + (x / y));
            }
            catch (DivideByZeroException) when (x == 0 && y == 0)
            {
                Console.WriteLine("0 / 0 is undefined.");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}

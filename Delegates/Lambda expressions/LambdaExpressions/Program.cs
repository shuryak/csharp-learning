using System;

namespace LambdaExpressions
{
    internal static class Program
    {
        private delegate int Operation(int x, int y);

        private delegate int SingleParameterOperation(int a);

        private delegate void Parameterless();

        private delegate bool Filter(int num);
        
        private static void Main(string[] args)
        {
            Operation op = (x, y) => x + y;
            Console.WriteLine(op(25, 11));
            
            // - - - - - - - - - -

            Operation newOp = (x, y) => { return x + y; };
            Console.WriteLine(newOp(7, 4));

            // - - - - - - - - - -

            SingleParameterOperation square = a => a * a;
            Console.WriteLine(square(15));
            
            // - - - - - - - - - -

            Parameterless pl = () => Console.WriteLine("Hello World!");
            pl();
            
            // - - - - - - - - - -

            int[] myArray = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            
            Console.WriteLine(SumWhere(myArray, x => x <= 8));
            Console.WriteLine(SumWhere(myArray, x => x >= 89));
        }
        
        private static int SumWhere(int[] arr, Filter filter)
        {
            int result = 0;
            
            foreach (int i in arr)
            {
                if (filter(i)) result += i;
            }

            return result;
        }
    }
}

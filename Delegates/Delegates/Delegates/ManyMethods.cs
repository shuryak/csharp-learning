using System;

namespace Delegates
{
    public static class ManyMethods
    {
        public static int ReturnAsSame(int num)
        {
            int result = num;
            Console.WriteLine(result);
            return result;
        }

        public static int MinusOne(int x)
        {
            int result = x - 1;
            Console.WriteLine(result);
            return result;
        }
        
        public static int Squaring(int a)
        {
            int result = a * a;
            Console.WriteLine(result);
            return result;
        }
    }
}
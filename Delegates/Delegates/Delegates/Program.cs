using System;

namespace Delegates
{
    internal delegate void Print();
    
    internal delegate int Operation(int a, int b);

    internal delegate int MyDelegate(int num);

    internal delegate void OtherDelegate(string str);

    internal delegate T GDelegate<T>(T val);
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Print sth;
            
            int userValue = Convert.ToInt32(Console.ReadLine());

            if (userValue % 2 == 0)
            {
                sth = Printer.PrintEven;
            }
            else
            {
                sth = Printer.PrintOdd;
            }
            
            sth();

            // - - - - - - - - - -
            Console.WriteLine();
            
            MathOperations math = new MathOperations();

            Operation del = math.Sum;
            Console.WriteLine(del(3, 9));
            del = math.Multiply;
            Console.WriteLine(del(3, 9));

            // - - - - - - - - - -
            Console.WriteLine();

            MyDelegate myDel = ManyMethods.ReturnAsSame;
            myDel += ManyMethods.Squaring;
            myDel += ManyMethods.MinusOne;
            myDel += ManyMethods.Squaring;
            myDel += ManyMethods.Squaring;
            
            Console.WriteLine("Return " + myDel(5));

            Console.WriteLine(">>> New:");
            
            myDel -= ManyMethods.Squaring;
            
            Console.WriteLine("Return " + myDel(5));
            
            // - - - - - - - - - -
            Console.WriteLine();

            OtherDelegate firstDelegate = OtherMethods.Greet;
            firstDelegate += OtherMethods.HowAreYou;

            OtherDelegate secondDelegate = OtherMethods.WhatsUp;
            secondDelegate += OtherMethods.Bye;

            OtherDelegate generalDelegate = firstDelegate + secondDelegate;

            generalDelegate("Mike");
            
            // - - - - - - - - - -
            Console.WriteLine();
            
            Invoke_Delegate(sth);
            
            // - - - - - - - - - -
            Console.WriteLine();

            GDelegate<int> sqDel = Squaring;
            
            Console.WriteLine(sqDel(5));
        }

        private static void Invoke_Delegate(Print _del)
        {
            _del?.Invoke();
        }

        private static int Squaring(int num)
        {
            return num * num;
        }
    }
}
using System;

namespace AnonymousMethods
{
    internal static class Program
    {
        private delegate void MessageHandler(string message);

        private delegate int Operation(int x, int y);
        
        private static void Main(string[] args)
        {
            MessageHandler handler = delegate(string mes)
            {
                Console.WriteLine(mes);
            };
            handler("String to print...");
            
            // - - - - - - - - - -
            
            ShowMessage("Another string to print...", delegate(string mes)
            {
                Console.WriteLine(mes);
            });
            
            // - - - - - - - - - -

            MessageHandler newHandler = delegate
            {
                Console.WriteLine("One more string to print...");
            };
            newHandler("Argument for the delegate.");
            
            // - - - - - - - - - -
            
            Operation op = delegate(int x, int y)
            {
                return x + y;
            };
            Console.WriteLine(op(3, 18));
            
            // - - - - - - - - - -

            int z = 10;
            Operation newOp = delegate(int x, int y)
            {
                return x + y + z;
            };
            Console.WriteLine(newOp(3, 18));
        }

        private static void ShowMessage(string mes, MessageHandler handler)
        {
            handler(mes);
        }
    }
}
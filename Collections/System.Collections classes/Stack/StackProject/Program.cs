using System;
using System.Collections; // Attention!

namespace StackProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");
            stack.Push("Fifth");

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop().ToString());
            }

            Console.ReadLine();
        }
    }
}

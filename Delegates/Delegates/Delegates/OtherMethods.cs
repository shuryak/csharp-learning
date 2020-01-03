using System;

namespace Delegates
{
    public static class OtherMethods
    {
        public static void Greet(string name)
        {
            Console.WriteLine("Hello " + name + "!");
        }

        public static void HowAreYou(string name)
        {
            Console.WriteLine("How are you " + name + "?");
        }

        public static void WhatsUp(string name)
        {
            Console.WriteLine("What's up " + name + "?");
        }
        
        public static void Bye(string name)
        {
            Console.WriteLine("Bye " + name + "!");
        }
    }
}
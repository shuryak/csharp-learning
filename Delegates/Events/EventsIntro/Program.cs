using System;

namespace EventsIntro
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Person paul = new Person("Paul", "Weaver", 24);
            
            paul.AgeChanged += AgeChanged;

            try
            {
                paul.Age = 30;
                paul.Age = 45;
                paul.Age = 27;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        private static void AgeChanged(object sender, EventArgs args)
        {
            Person curState = (Person)sender;
            Console.WriteLine($"Age changed to {curState.Age}.");
        }
    }
}
using System;

namespace EventsProject
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Person paul = new Person("Paul", "Weaver");
            
            paul.FirstNameChanged += FirstNameChanged;
            paul.LastNameChanged += LastNameChanged;

            paul.FirstName = "Calvin";
            paul.LastName = "Foster";
            
            Console.WriteLine(paul.GetFullName());
        }
        
        private static void FirstNameChanged(object sender, NameChangedArgs args)
        {
            Person prevState = (Person)sender;
            
            Console.WriteLine($"Allow changing the first name from {prevState.FirstName} to {args.NewName}? (y / n)");

            bool userResponse = Console.ReadLine() == "n" ? true : false;

            if (userResponse) args.Canceled = true;
        }
        
        private static void LastNameChanged(object sender, NameChangedArgs args)
        {
            Person prevState = (Person)sender;

            Console.WriteLine($"Allow changing the last name from {prevState.LastName} to {args.NewName}? (y / n)");

            bool userResponse = Console.ReadLine() == "n" ? true : false;

            if (userResponse) args.Canceled = true;
        }
    }
}

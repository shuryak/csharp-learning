using System;

namespace YieldProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Thomas = new Person("Thomas", "Brooks");

            Thomas.AddChild("Sophie", "Brooks");
            Thomas.AddChild("James", "Brooks");
            Thomas.AddChild("Tyler", "Brooks");

            Console.WriteLine("{0} {1} has {2} children:", Thomas.Firstname, Thomas.Lastname, Thomas.GetChildrenCount());
            foreach (Person child in Thomas)
            {
                Console.WriteLine(child.Firstname + " " + child.Lastname);
            }

            Console.WriteLine("\n----------\n");

            Numbers sqr = new Numbers(5);

            Console.WriteLine("Squares of numbers from 0 to {0}", sqr.SqrNum);
            foreach (int i in sqr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n----------\n");

            Kindergarten kg = new Kindergarten(30); // Create a kindergarten with 30 places

            // Add children to kindergarten:
            kg.AddChild("Edward", "Lambert");
            kg.AddChild("Ethan", "Watkins");
            kg.AddChild("Mary", "Nash");
            kg.AddChild("Emily", "Lewis");

            Console.WriteLine("{0} / {1} places in kindergarten are occupied by:", kg.OccupiedPlaces ,kg.Places);
            foreach (Person child in kg.GetChildrens(10))
            {
                Console.WriteLine(child.Firstname + " " + child.Lastname);
            }

            Console.ReadLine();
        }
    }
}

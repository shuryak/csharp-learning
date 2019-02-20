using System;
using System.Collections; // Attention!

namespace DynamicArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog Rocky = new Dog("Rocky", 2);

            int[] simpleArray = new int[] { 8, 10, 30 };
            ArrayList firstList = new ArrayList(); // Attention!

            firstList.Add("Hello, World!");
            firstList.Add(5);
            firstList.Add(10.2);
            firstList.Add(Rocky);
            firstList.Add(simpleArray); // Attention!
            firstList.AddRange(simpleArray); // Attention!

            // Here we can no longer add simpleArray elements separately, but only can add the array simpleArray itself as an element of the collection:
            ArrayList secondList = new ArrayList() { "Hello, World!", 5, 10.2, Rocky, simpleArray };

            Console.WriteLine("Decomposing the firstList collection by type:\n");
            foreach (object i in firstList)
            {
                Console.WriteLine(i.GetType());
            }
            Console.WriteLine("\nCount of elements in the collection: " + firstList.Count);

            Console.WriteLine("\nDecomposing the secondList collection by type:\n");
            foreach (object i in secondList)
            {
                Console.WriteLine(i.GetType());
            }
            Console.WriteLine("\nCount of elements in the collection: " + secondList.Count);

            Console.ReadLine();
        }
    }
}

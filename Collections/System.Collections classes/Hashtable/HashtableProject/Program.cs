using System;
using System.Collections; // Attention!

namespace HashtableProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();

            hash.Add("James", new Person("James", "Brooks"));
            hash.Add("Veronica", new Person("Veronica", "Tucker"));
            hash.Add("Michael", new Person("Michael", "Charles"));
            hash.Add("Nancy", new Person("Nancy", "Stafford"));
            hash.Add("Scott", new Person("Scott", "Barton"));
            hash.Add("Julia", new Person("Julia", "Patterson"));

            Console.WriteLine("Values:\n");
            foreach (Person p in hash.Values)
            {
                Console.WriteLine(p.Firstname + " " + p.Lastname);
            }

            Console.WriteLine("\n----------\n");

            Console.WriteLine("Keys:\n");
            foreach (object p in hash.Keys)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("\n----------\n");

            Console.WriteLine("Key — Value:\n");
            foreach (object key in hash.Keys)
            {
                Person p = (Person)hash[key];
                Console.WriteLine("\"" + key + "\"" + " — " + "\"" + p.Firstname + " " + p.Lastname + "\"");
            }

            Console.ReadLine();
        }
    }
}
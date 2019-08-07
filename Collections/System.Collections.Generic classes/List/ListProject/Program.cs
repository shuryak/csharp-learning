using System;
using System.Collections.Generic; // Attention!

namespace ListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person("Alban", "Smith"));
            persons.Add(new Person("William", "Parks"));
            persons.Add(new Person("Jack", "Tucker"));

            persons[0].Firstname = "George";

            Person[] personRange = new Person[] { new Person("Christopher", "Charles"), new Person("Peter", "Carroll") };

            persons.AddRange(personRange);

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Firstname + " " + p.Lastname);
            }

            Console.ReadLine();
        }
    }
}
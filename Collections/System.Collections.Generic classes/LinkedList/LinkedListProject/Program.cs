using System;
using System.Collections.Generic;

namespace LinkedListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Person> persons = new LinkedList<Person>();

            persons.AddLast(new Person("Anthony", "Fletcher"));
            persons.AddFirst(new Person("Sharon", "Watkins"));
            persons.AddLast(new Person("George", "Caldwell"));
            LinkedListNode<Person> helen = persons.AddLast(new Person("Helen", "Fields"));

            Console.WriteLine(helen.Value.Firstname);
            Console.WriteLine(helen.Previous.Value.Firstname);

            Console.WriteLine("\n----------\n");

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Firstname + " " + p.Lastname);
            }

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

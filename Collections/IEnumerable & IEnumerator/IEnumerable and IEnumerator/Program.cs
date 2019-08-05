using System;

namespace IEnumerable_and_IEnumerator
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
            foreach(Person child in Thomas)
            {
                Console.WriteLine(child.Firstname + " " + child.Lastname);
            }

            Console.ReadLine();
        }
    }
}

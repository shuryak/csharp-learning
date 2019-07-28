using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparer_and_IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Thomas = new Person("Thomas", "Brooks");

            Thomas.AddChild("Caren", "Brooks");
            Thomas.AddChild("Aaron", "Brooks");
            Thomas.AddChild("Barbara", "Brooks");
            Thomas.AddChild("Brian", "Brooks");
            Thomas.AddChild("Chad", "Brooks");

            Thomas.SortChildren();

            Console.WriteLine("{0} {1} has {2} children:", Thomas.Firstname, Thomas.Lastname, Thomas.GetChildrenCount());
            foreach (Person child in Thomas)
            {
                Console.WriteLine(child.Firstname + " " + child.Lastname);
            }

            Console.ReadLine();
        }
    }
}

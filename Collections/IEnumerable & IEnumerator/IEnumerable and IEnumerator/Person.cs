using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IEnumerable_and_IEnumerator
{
    class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Person(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        ArrayList Childrens = new ArrayList();

        public void AddChild(string firstname, string lastname)
        {
            Childrens.Add(new Person(firstname, lastname));
        }

        public int GetChildrenCount()
        {
            return Childrens.Count;
        }

        public Person this[int index]
        {
            get { return (Person)Childrens[index]; }
        }

        /* Foreign implementation
        public IEnumerator GetEnumerator()
        {
            return Childrens.GetEnumerator();
        }
        */

        public IEnumerator GetEnumerator()
        {
            return new PersonEnumerator(this);
        }
    }
}

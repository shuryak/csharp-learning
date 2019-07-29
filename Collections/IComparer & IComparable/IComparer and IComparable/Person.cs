using System;
using System.Collections;

namespace IComparer_and_IComparable
{
    class Person : IComparable//, IComparer
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

        public IEnumerator GetEnumerator()
        {
            return new PersonEnumerator(this);
        }

        public new string ToString()
        {
            return Firstname + " " + Lastname;
        }

        public void SortChildren()
        {
            Childrens.Sort(new PersonSort());
        }

        public int CompareTo(object obj)
        {
            Person person = (Person)obj;

            string personName1 = this.ToString();
            string personName2 = person.ToString();

            return personName1.CompareTo(personName2);
        }

        /*
        int IComparer.Compare(object person1, object person2)
        {
            string personName1 = ((Person)person1).ToString();
            string personName2 = ((Person)person2).ToString();

            return personName1.CompareTo(personName2);
        }
        */

        class PersonSort : IComparer
        {
            int IComparer.Compare(object person1, object person2)
            {
                string personName1 = ((Person)person1).ToString();
                string personName2 = ((Person)person2).ToString();

                return personName2.CompareTo(personName1);
            }
        }
    }
}

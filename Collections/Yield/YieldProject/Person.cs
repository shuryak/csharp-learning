using System.Collections;

namespace YieldProject
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

        /*public Person this[int index]
        {
            get { return (Person)Childrens[index]; }
        }*/

        public IEnumerator GetEnumerator()
        {
            foreach (Person p in Childrens)
            {
                yield return p;
            }
        }
    }
}

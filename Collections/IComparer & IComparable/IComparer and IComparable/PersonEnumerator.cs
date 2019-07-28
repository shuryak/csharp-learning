using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IComparer_and_IComparable
{
    class PersonEnumerator : IEnumerator
    {
        int currentIndex = -1;
        Person person;

        public PersonEnumerator(Person person)
        {
            this.person = person;
        }

        public object Current
        {
            get { return person[currentIndex]; }
        }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex >= person.GetChildrenCount())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}

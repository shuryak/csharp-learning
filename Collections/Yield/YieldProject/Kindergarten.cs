using System.Collections;

namespace YieldProject
{
    class Kindergarten
    {
        private Person[] childrens;
        private int index = 0;
        public int Places
        {
            get { return childrens.Length; }
        }
        public int OccupiedPlaces
        {
            get { return childrens.Length - (childrens.Length - index); }
        }

        public Kindergarten(int places)
        {
            childrens = new Person[places];
        }

        public bool AddChild(string firstname, string lastname)
        {
            if (index < Places)
            {
                childrens[index] = new Person(firstname, lastname);
                index++;
                return true;
            }
            return false;
        }

        public IEnumerable GetChildrens(int num) // Named iterator
        {
            for (int i = 0; i < num; i++)
            {
                if (i == OccupiedPlaces)
                {
                    yield break;
                }
                else
                {
                    yield return childrens[i];
                }
            }
        }
    }
}

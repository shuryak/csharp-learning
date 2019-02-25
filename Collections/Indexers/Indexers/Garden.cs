using System.Collections;

namespace Indexers
{
    class Garden
    {
        ArrayList Plants = new ArrayList();

        public Garden(string[] name)
        {
            Plants.AddRange(name);
        }

        public string this[int index]
        {
            get { return (string)Plants[index]; }
        }

        public int GetPlantsNumber()
        {
            return Plants.Count;
        }
    }
}

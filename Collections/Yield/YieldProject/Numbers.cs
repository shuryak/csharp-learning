using System.Collections;

namespace YieldProject
{
    class Numbers
    {
        public int SqrNum { get; set; }

        public Numbers(int num)
        {
            SqrNum = num;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i <= SqrNum; i++)
            {
                yield return i * i;
            }
        }
    }
}

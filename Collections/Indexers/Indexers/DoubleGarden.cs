namespace Indexers
{
    class DoubleGarden
    {
        int[] oneLine = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[,] threeLines = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        public int this[int i]
        {
            get { return oneLine[i]; }
        }

        public int this[int v, int h]
        {
            get { return threeLines[v, h]; }
        }

        public int GetOneLength()
        {
            return oneLine.Length;
        }

        public int GetThreeLength()
        {
            return threeLines.GetLength(0);
        }

        public int GetThreeHeight()
        {
            return threeLines.Length / GetThreeLength();
        }
    }
}

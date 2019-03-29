namespace Indexers
{
    class SquareGarden
    {
        int[,] threeByThree = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        public int this[int v, int h]
        {
            get { return threeByThree[v, h]; }
            set { threeByThree[v, h] = value; }
        }

        public int GetLength()
        {
            return threeByThree.GetLength(0);
        }

        public int GetHeight()
        {
            return threeByThree.GetLength(1);
        }
    }
}
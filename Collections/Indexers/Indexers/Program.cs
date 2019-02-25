using System;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myPlants = new string[] { "Cactus", "Ficus", "Aloe", "Palm", "Dandelion" };
            Garden botanicalGarden = new Garden(myPlants);
            SquareGarden mySquareGarden = new SquareGarden();
            DoubleGarden myDoubleGarden = new DoubleGarden();

            Console.WriteLine("Plants in the botanicalGarden:\n");
            for (int i = 0; i < botanicalGarden.GetPlantsNumber(); i++)
            {
                Console.WriteLine(botanicalGarden[i]);
            }

            Console.WriteLine("\nNumbers in the mySquareGarden:\n");
            Console.WriteLine("Enter the vertical coordinates:");
            int v = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter horizontal coordinates:");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a value for these coordinates:");
            int value = Convert.ToInt32(Console.ReadLine());

            if (v < mySquareGarden.GetHeight() && h < mySquareGarden.GetLength())
            {
                mySquareGarden[v, h] = value;
                Console.WriteLine();
            }
            else Console.WriteLine("Invalid coordinates.\n");

            for (int i = 0; i < mySquareGarden.GetHeight(); i++)
            {
                for (int j = 0; j < mySquareGarden.GetLength(); j++)
                {
                    Console.Write(mySquareGarden[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nmyDoubleGarden:\n");

            for (int z = 0; z < myDoubleGarden.GetOneLength(); z++)
            {
                Console.Write(myDoubleGarden[z] + " ");
            }

            Console.WriteLine("\n");

            for (int m = 0; m < myDoubleGarden.GetThreeHeight(); m++)
            {
                for (int f = 0; f < myDoubleGarden.GetThreeLength(); f++)
                {
                    Console.Write(myDoubleGarden[m, f] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
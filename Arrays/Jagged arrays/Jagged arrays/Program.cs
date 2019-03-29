using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Jagged array with 5 elements:

            int[][] jagged = new int[5][];
            jagged[0] = new int[4] { 1, 2, 3, 4 };
            jagged[1] = new int[3] { 5, 6, 7 };
            jagged[2] = new int[2] { 8, 9 };
            jagged[3] = new int[7] { 10, 11, 12, 13, 14, 15, 16 };
            jagged[4] = new int[4] { 17, 18, 19, 20 };

            // Enumeration of jagged array with foreach:
            Console.WriteLine("Enumeration of jagged array with foreach:\n");
            foreach (int[] i in jagged)
            {
                foreach (int j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.WriteLine();
            }

            // Enumeration of jagged array with for:
            Console.WriteLine("\nEnumeration of jagged array with for:\n");
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} \t");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            // Jagged array, whose elements are multidimensional arrays:

            int[][,] mdJagged = new int[3][,]
            {
                new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } },
                new int[2, 2] { { 9, 10 }, { 11, 12 } },
                new int[3, 2] { { 13, 14 }, { 15, 16 }, { 17, 18 } }
            };

            // Enumeration of jagged array, whose elements are multidimensional arrays:
            Console.WriteLine("Enumeration of jagged array, whose elements are multidimensional arrays:\n");
            for (int i = 0; i < mdJagged.GetUpperBound(0) + 1; i++)
            {
                Console.WriteLine($"int[{mdJagged[i].GetUpperBound(0) + 1}, {mdJagged[i].GetUpperBound(1) + 1}]:");
                for (int j = 0; j < mdJagged[i].GetUpperBound(0) + 1; j++)
                {
                    for (int k = 0; k < mdJagged[i].GetUpperBound(1) + 1; k++)
                    {
                        Console.Write(mdJagged[i][j, k] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Enumeration of jagged array, whose elements are multidimensional arrays with foreach:
            Console.WriteLine("Enumeration of jagged array, whose elements are multidimensional arrays with foreach:\n");
            foreach (int[,] i in mdJagged)
            {
                foreach (int j in i)
                {
                    Console.Write(j + "\t");
                }
                Console.WriteLine();
            };
            Console.ReadLine();
        }
    }
}

using System;

namespace Multidimensional_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // One-dimensional array of 5 integers:

            int[] OneD = new int[5] { 1, 2, 3, 4, 5 };

            // Enumeration of one-dimensional array:
            Console.WriteLine("Enumeration of one-dimensional array:\n");
            foreach (int i in OneD)
            {
                Console.Write(i + " ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------------------------");
            Console.ResetColor();

            // Two-dimensional array 3x4 of integers:

            int[,] TwoD = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            /*
            myArray array initialization ways:
            1) int[,] myArray = new int[3, 2];
                // Filling an array which initialized in this way:
                int v = 1;
                for (int i = 0; i < myArray.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < (myArray.GetUpperBound(1) + 1); j++)
                    {
                        myArray[i, j] = v;
                        v++;
                    }
                }
            2) int[,] myArray = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } }; // We used this way
            3) int[,] myArray = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            4) int[,] myArray = new[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            5) int[,] myArray = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            // In arrays with a greater number of dimensions initialization takes place by analogy
            */

            // Enumeration of two-dimensional array in one line:
            Console.WriteLine("Enumeration of two-dimensional array in one line:\n");
            foreach (int i in TwoD)
            {
                Console.Write(i + " ");
            }
            // Enumeration of two-dimensional array by dimensions:
            Console.WriteLine("\n\nEnumeration of two-dimensional array by dimensions:\n");
            for (int i = 0; i < TwoD.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < (TwoD.GetUpperBound(1) + 1); j++)
                {
                    Console.Write(TwoD[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------------------------");
            Console.ResetColor();

            // Three-dimensional array 2x4x3 of integers:

            int[,,] ThreeD = new int[2, 4, 3] {
                { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } },
                { { 13, 14, 15 }, { 16, 17, 18 }, { 19, 20, 21 }, { 22, 23, 24 } }
            };

            // Enumeration of three-dimensional array by indexes:
            Console.WriteLine("Enumeration of three-dimensional array by indexes:\n");
            for (int i = 0; i < (ThreeD.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (ThreeD.GetUpperBound(1) + 1); j++)
                {
                    for (int k = 0; k < (ThreeD.GetUpperBound(2) + 1); k++)
                    {
                        Console.WriteLine($"[{i}, {j}, {k}] = " + ThreeD[i, j, k]);
                    }
                }
            };
            // Enumeration of a three-dimensional array by two first dimensions:
            Console.WriteLine("\nEnumeration of a three-dimensional array by two first dimensions:\n");
            for (int i = 0; i < (ThreeD.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (ThreeD.GetUpperBound(1) + 1); j++)
                {
                    Console.Write($"[{i}, {j}, ...] = {{");
                    for (int k = 0; k < (ThreeD.GetUpperBound(2) + 1); k++)
                    {
                        Console.Write(ThreeD[i, j, k] + ", ");
                    }
                    Console.Write("\b\b}");
                    Console.WriteLine();
                }
            };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            // Four-dimensional array 3x3x3x3 of integers:

            int[,,,] FourD = new int[3, 3, 3, 3]
            {
                {
                    { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } }, { { 19, 20, 21 }, { 22, 23, 24 }, { 25, 26, 27 } }
                },
                {
                    { { 28, 29, 30 }, { 31, 32, 33 }, { 34, 35, 36 } }, { { 37, 38, 39 }, { 40, 41, 42 }, { 43, 44, 45 } }, { { 46, 47, 48 }, { 49, 50, 51 }, { 52, 53, 54} }
                },
                {
                    { { 55, 56, 57 }, { 58, 59, 60 }, { 61, 62, 63 } }, { { 64, 65, 66 }, { 67, 68, 69 }, { 70, 71, 72 } }, { { 73, 74, 75 }, { 76, 77, 78 }, { 79, 80, 81 } }
                }
            };

            // Enumeration of four-dimensional array by indexes:
            Console.WriteLine("Enumeration of four-dimensional array by indexes:\n");
            for (int i = 0; i < (FourD.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (FourD.GetUpperBound(1) + 1); j++)
                {
                    for (int k = 0; k < (FourD.GetUpperBound(2) + 1); k++)
                    {
                        for (int m = 0; m < (FourD.GetUpperBound(3) + 1); m++)
                        {
                            Console.WriteLine($"[{i}, {j}, {k}] = " + FourD[i, j, k, m]);
                        }
                    }
                }
            };
            // Enumeration of a four-dimensional array by three first dimensions:
            Console.WriteLine("\nEnumeration of a four-dimensional array by three first dimensions:\n");
            for (int i = 0; i < (FourD.GetUpperBound(0) + 1); i++)
            {
                for (int j = 0; j < (FourD.GetUpperBound(1) + 1); j++)
                {
                    for (int k = 0; k < (FourD.GetUpperBound(2) + 1); k++)
                    {
                        Console.Write($"[{i}, {j}, ...] = {{");
                        for (int m = 0; m < (FourD.GetUpperBound(3) + 1); m++)
                        {
                            Console.Write(FourD[i, j, k, m] + ", ");
                        }
                        Console.Write("\b\b}");
                        Console.WriteLine();
                    }
                }
            };
            Console.ReadLine();
        }
    }
}
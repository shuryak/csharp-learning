using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sum<int>(10, 10)); // 1010

            Console.WriteLine("----------");

            UniversalArray<double> doubleArray = new UniversalArray<double>();

            doubleArray.Add(12.5);
            doubleArray.Add(11.9);
            doubleArray.Add(0.78);
            doubleArray.Add(2.0);

            for (int i = 0; i < doubleArray.GetCount(); i++)
            {
                Console.WriteLine(doubleArray.Get(i));
            }

            Console.WriteLine("----------");

            Console.WriteLine(sum<int, string>(99, "$")); // 99$

            Console.ReadLine();
        }

        static string sum<T>(T value1, T value2)
        {
            return value1.ToString() + value2.ToString();
        }
        static string sum<T, U>(T value1, U value2) // Overloading
        {
            return value1.ToString() + value2.ToString();
        }
    }

    public class UniversalArray<T>
    {
        T[] array = new T[10];
        int index = 0;

        public bool Add(T value)
        {
            if (index >= 10)
            {
                return false;
            }
            array[index++] = value;
            return true;
        }

        public T Get(int index)
        {
            if (index < this.index && index >= 0)
            {
                return array[index];
            }
            else
            {
                return default(T);
            }
        }

        public int GetCount()
        {
            return index;
        }
    }
}

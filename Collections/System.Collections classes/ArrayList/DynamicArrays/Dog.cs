using System;

namespace DynamicArrays
{
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Bark(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Name + ": *barking*");
            }
        }
    }
}

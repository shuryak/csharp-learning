using System;

namespace CoAndContraGeneralizedDelegates
{
    public class Person
    {
        public string Name { get; set; }
        public virtual void PrintInfo() => Console.WriteLine($"Person: {Name}");
    }
}

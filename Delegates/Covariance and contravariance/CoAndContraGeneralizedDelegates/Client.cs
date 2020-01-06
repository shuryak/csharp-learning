using System;

namespace CoAndContraGeneralizedDelegates
{
    public class Client : Person
    {
        public override void PrintInfo() => Console.WriteLine($"Client: {Name}");
    }
}

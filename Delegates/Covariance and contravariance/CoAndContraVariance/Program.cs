using System;

namespace CoAndContraVariance
{
    internal static class Program
    {
        delegate Person PersonDel(string firstname, string lastname);
    
        delegate void ClientInfo(Client client);
            
        private static void Main(string[] args)
        {
            PersonDel pd;
            pd = ReturnClient;
            Person harry = pd("Harry", "Smith");
            Console.WriteLine(harry.FirstName + " " + harry.LastName);
    
            // - - - - - - - - - -
    
            ClientInfo clientInfo = PrintPersonInfo;
            Client client = new Client("Mike", "Pierce");
            clientInfo(client);
        }
            
        private static Client ReturnClient(string firstname, string lastname)
        {
            return new Client(firstname, lastname);
        }
    
        private static void PrintPersonInfo(Person p)
        {
            Console.WriteLine(p.FirstName + " " + p.LastName);
        }
    }
}

namespace CoAndContraGeneralizedDelegates
{
    internal static class Program
    {
        private delegate T User<out T>(string name);

        private delegate void GetInfo<in T>(T user);
        
        private static void Main(string[] args)
        {
            User<Client> newClient = GetClient;
            User<Person> firstPerson = newClient;
            User<Person> secondPerson = GetClient;

            Person p = firstPerson("Mike");
            p.PrintInfo();
            
            // - - - - - - - - - -

            GetInfo<Person> personInfo = PersonInfo;
            GetInfo<Client> clientInfo = personInfo;
            
            Client client = new Client { Name = "Harry" };
            clientInfo(client);
        }

        private static Client GetClient(string name)
        {
            return new Client {Name = name};
        }

        private static void PersonInfo(Person p)
        {
            p.PrintInfo();
        }
    }
}

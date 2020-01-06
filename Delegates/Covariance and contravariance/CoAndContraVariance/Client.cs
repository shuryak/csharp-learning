namespace CoAndContraVariance
{
    public class Client : Person
    {
        public Client(string firstname, string lastname) : base(firstname, lastname) { }

        public int Budget { get; set; }
    }
}

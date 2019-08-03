using System;
using System.Collections; // Attention!

namespace QueueProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");
            queue.Enqueue("Fifth");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue().ToString());
            }
        }
    }
}

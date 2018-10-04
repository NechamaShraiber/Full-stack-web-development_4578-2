using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Collections_and_Tasks
{
    class Program
    {
        static ConcurrentBag<int> numbers = new ConcurrentBag<int>();

        static void AddNumbers()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(rnd.Next(100));
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(AddNumbers);
            Task t2 = new Task(AddNumbers);
            t1.Start();
            t2.Start();
            t1.Wait();
            t2.Wait();
            Console.WriteLine("Count: " + numbers.Count);
        }
    }
}

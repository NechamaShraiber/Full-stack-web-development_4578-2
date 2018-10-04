using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Example
{
    class Program
    {
        static void Print1()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write("1 ");
                Thread.Sleep(100);
            }
        }

        static void Print2()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write("2 ");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Print1);
            Task t2 = new Task(Print2);

            t1.Start();
            t2.Start();

            Console.WriteLine("End 1");

            t1.Wait(); // The Main will wait for t1 to end.
            t2.Wait(); // The Main will wait for t2 to end.

            Console.WriteLine("End 2");
        }
    }
}

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Exceptions_Exercise
{
    class Program
    {
        static object lockFlag = new object();

        static void Main(string[] args)
        {
            Task parent = new Task(()=> {

                Task t1 = new Task(()=> {
                    int a = 0, b = 0;
                    lock (lockFlag)
                    {
                        Console.Write("Enter first number: ");
                        a = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        b = int.Parse(Console.ReadLine());
                    }
                    Thread.Sleep(3000);
                    Console.WriteLine(a / b);
                }, TaskCreationOptions.AttachedToParent);

                Task t2 = new Task(() => {
                    int[] array = new int[5];
                    for (int i = 0; i < array.Length; i++)
                        array[i] = i * i;
                    Thread.Sleep(10000);
                    Console.WriteLine(array[7]);
                }, TaskCreationOptions.AttachedToParent);

                Task t3 = new Task(() => {
                    string file = "";
                    lock (lockFlag)
                    {
                        Console.Write("Enter file name: ");
                        file = Console.ReadLine();
                    }
                    StreamReader reader = new StreamReader(file);
                }, TaskCreationOptions.AttachedToParent);

                t1.Start();
                t2.Start();
                t3.Start();
            });

            parent.Start();

            try
            {
                parent.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (Exception item in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                    Console.WriteLine(item.GetType().Name);
                    Console.WriteLine("---------------------------");
                }
            }
        }
    }
}

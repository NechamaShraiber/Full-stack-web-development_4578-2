using System;
using System.Threading;
using System.Threading.Tasks;

namespace Send_Object_to_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            Range range = new Range(start, end);

            Task t = new Task(obj => {

                Range r = obj as Range;

                for (int i = r.Start; i <= r.End; i++)
                {
                    Console.Write(i + " ");
                    Thread.Sleep(200);
                }
            }, range);

            t.Start();
            t.Wait();
        }
    }
}

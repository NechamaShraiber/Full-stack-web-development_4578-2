using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_Threads
{

     
    class Program
    {
        static Thread t1 = new Thread(Func1);
        static Thread t2 = new Thread(Func2);


        static void Func1()
        {
            Console.WriteLine("Func1 START");
            t2.Suspend();
            Thread.Sleep(5000);
            Console.WriteLine("Func1 END");
            t2.Resume();
        }

        static void Func2()
        {
            Console.WriteLine("Func2 START");
            Thread.Sleep(4000);
            Console.WriteLine("Func2 END");
        }
        static void Main(string[] args)
        {
            t1.Start();
            t2.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads_and_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Thread t = new Thread(() => {
                    int[] array = { 10, 20, 30, 40, 50 };
                    int sum = 0;
                    for (int i = 0; i <= array.Length; i++)
                    {
                        sum += array[i];
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Sum: " + sum);
                });
                t.Start();
                Console.WriteLine("Started...");
                t.Join(); // = Waiting - The Main will wait until t will end.
                Console.WriteLine("End of Try");
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("End of Main");
        }
    }
}

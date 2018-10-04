using System;
using System.Collections.Generic;
using System.Threading;

namespace Threads
{
    class Program
    {
        //ReaderWriterLock - Defines a lock that supports single writers and multiple readers.
        static ReaderWriterLock readerWriterLock = new ReaderWriterLock();

        // My Resource
        static List<int> numbers = new List<int> { 11, 22, 33, 44, 55 };

        // Read from Resource: 
        static void ShowNumber(object index)
        {
            // AcquireWriterLock-  Acquires the writer lock, 
            // using an Int value for the time-out (in milliseconds)
            readerWriterLock.AcquireReaderLock(1000);

            Console.Write(numbers[(int)index] + " ");
            readerWriterLock.ReleaseReaderLock();
        }

        // Write to Resource:
        static void AddNumber(object num)
        {
           
            // AcquireWriterLock-  Acquires the writer lock, 
            // using an Int value for the time-out (in milliseconds)
            readerWriterLock.AcquireWriterLock(1000);

            numbers.Add((int)num);
            readerWriterLock.ReleaseWriterLock();
        }

        static void Main(string[] args)
        {
            // Adding numbers: 
            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(AddNumber);
                t.Start(i * i);
            }

            // Showing the numbers: 
            for (int i = 0; i < numbers.Count; i++)
            {
                Thread t = new Thread(ShowNumber);
                t.Start(i);
            }

        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smiley
{
    class Data
    {
        public int HappySmilies;
        public int SadSmilies;

        public Data(int happy, int sad)
        {
            HappySmilies = happy;
            SadSmilies = sad;
        }
    }

    class Program
    {
        static object lockFlag = new object();

        static void PrintHappyAndSadSmilies(object data)
        {
            Data d = data as Data;

            Task child1 = new Task(() => {
                for (int i = 0; i < d.HappySmilies; i++)
                {
                    lock (lockFlag)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(":-) ");
                        Console.ResetColor();
                    }

                    Thread.Sleep(200);
                }
            }, TaskCreationOptions.AttachedToParent);

            Task child2 = new Task(() => {
                for (int i = 0; i < d.SadSmilies; i++)
                {
                    lock (lockFlag)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(":-( ");
                        Console.ResetColor();
                    }

                    Thread.Sleep(200);
                }
            }, TaskCreationOptions.AttachedToParent);

            child1.Start();
            child2.Start();
        }

        static void Main(string[] args)
        {
            int happy = int.Parse(Console.ReadLine());
            int sad = int.Parse(Console.ReadLine());
            Data data = new Data(happy, sad);
            Task parent = new Task(PrintHappyAndSadSmilies, data);
            parent.Start();
            parent.Wait();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    internal class ThreadConstructors
    {
        public static void RunMethods()
        {
            UsingThreadStartDelegateConstructor();
        }

        private static void UsingThreadStartDelegateConstructor()
        {
            //ThreadStart obj = new ThreadStart(ShowNumbers);
            //ThreadStart obj = ShowNumbers;

            //Thread t1 = new Thread(ShowNumbers)
            Thread t1 = new Thread(ShowNumbers)
            {
                Name = "Thread 1"
            };

            t1.Start();
        }

        private static void ShowNumbers()
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
        }

    }
}






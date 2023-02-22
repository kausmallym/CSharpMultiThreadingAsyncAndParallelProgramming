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
            //UsingThreadStartDelegateConstructor();
            UsingParameterizedThreadStartDelegate();
        }

        private static void UsingThreadStartDelegateConstructor()
        {
            //ThreadStart obj = new ThreadStart(ShowNumbers);
            //ThreadStart obj = ShowNumbers;

            //Thread t1 = new Thread(ShowNumbers)

            //ThreadStart obj = delegate () { ShowNumbers(); };
            
            //We can pass the code directly - not really a correct way but we do not have method names in anonymous method
            //ThreadStart obj = delegate () {
            //    {
            //        Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            //        for (int i = 0; i < 5; i++)
            //        {
            //            Console.WriteLine(i);
            //        }
            //    }
            //};

            ThreadStart obj = () => ShowNumbers();
            //Thread t1 = new Thread(ShowNumbers) //CLR is responsible for initialising the ThreadStart delegate
            Thread t1 = new Thread(obj)
            {
                Name = "Thread 1"
            };

            t1.Start();
        }

        private static void UsingParameterizedThreadStartDelegate()
        {
            ParameterizedThreadStart obj = new ParameterizedThreadStart(ShowNumbers);
            Thread t2 = new Thread(obj) { 
                Name = "Thread 2" 
            };
            t2.Start(10);

        }

        private static void ShowNumbers()
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void ShowNumbers(object maxNum)
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i <= Convert.ToInt32(maxNum); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}






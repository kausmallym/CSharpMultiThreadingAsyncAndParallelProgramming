﻿using System;
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






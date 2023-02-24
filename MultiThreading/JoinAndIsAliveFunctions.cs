using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    internal class JoinAndIsAliveFunctions
    {
        public static void RunMethods()
        {
            Console.WriteLine("Main method execution started");

            Thread t1 = new Thread(Method1);
            t1.Start();
            Thread t2 = new Thread(Method2);
            t2.Start();

            //force main thread to wait for child thread t1 and t2 to complete
            t1.Join();
            Console.WriteLine("Method 1 execution completed");
            t2.Join();
            Console.WriteLine("Method 2 execution completed");

            Console.WriteLine("Main method execution ended");
        }

        public static void Method1()
        {
            Console.WriteLine("Method1 execution started");
            Thread.Sleep(5000);
            Console.WriteLine("Method 1 is awake after sleep");
        }
        
        public static void Method2()
        {
            Console.WriteLine("Method2 execution started");
        }
    }
}

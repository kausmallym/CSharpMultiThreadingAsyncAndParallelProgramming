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

            Console.WriteLine("Main method execution ended");
        }

        public static void Method1()
        {
            Console.WriteLine("Method1 execution started");
        }
        
        public static void Method2()
        {
            Console.WriteLine("Method2 execution started");
        }
    }
}

namespace MultiThreading
{
    internal class ThreadConstructors
    {
        public static void RunMethods()
        {
            //UsingThreadStartDelegateConstructor();
            //UsingParameterizedThreadStartDelegate();
            UsingParameterizedThreadStartDelegateTypeSafe();
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
            Thread t2 = new Thread(obj)
            {
                Name = "Thread 2"
            };
            t2.Start(10);
            //t2.Start();
            //t2.Start("i am a string");
            //issue is if we do not add a parameter when starting the thread, or a value that is not int(a string),
            //no error will be displayed, but a run time error may be generated
        }

        private static void UsingParameterizedThreadStartDelegateTypeSafe()
        {
            int max = 50;
            NumberHelper nh = new NumberHelper(max);

            //If we try to pass a string value, it shows an error
            //NumberHelper nh1 = new NumberHelper("");

            //Use ThreadStart delegate object instead of ParameterizedThreadStart delegate since we are already supplying the parameter through the NumberHelper class object
            //We are not starging the Thread with a parameter
            ThreadStart obj = new ThreadStart(nh.ShowNumbersTypeSafe);

            Thread t3 = new Thread(obj)
            {
                Name = "Thread 3"
            };

            t3.Start();
        }

        private static void ShowNumbers()
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void ShowNumbers(object maxNum)
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i <= Convert.ToInt32(maxNum); i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    //Creating a helper class
    public class NumberHelper
    {
        private int _Number;
        public NumberHelper(int num)
        {
            _Number = num;
        }

        public void ShowNumbersTypeSafe()
        {
            Console.WriteLine($"Current running thread: {Thread.CurrentThread.Name}");
            for (int i = 0; i <= _Number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}






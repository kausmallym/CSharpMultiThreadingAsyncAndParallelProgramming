// See https://aka.ms/new-console-template for more information
// Application uses a single thread
//Thread t = Thread.CurrentThread;
//t.Name = "Main Thread";
//Console.WriteLine("Thread Name: {0}", t.Name);
//Console.WriteLine("Current thread Name: {0}", Thread.CurrentThread.Name);

Console.WriteLine("Main thread started");

//Creating Threads
Thread t1 = new Thread(Method1)
{
    Name = "Thread 1"
};

Thread t2 = new Thread(Method2)
{
    Name = "Thread 2"
};

Thread t3 = new Thread(Method3)
{
    Name = "Thread 3"
};

//Executing the methods
t1.Start();
t2.Start();
t3.Start();

Console.WriteLine("Main thread ended");

//Method1();
//Console.WriteLine("Method 1 execution is completed");

//Method2();
//Console.WriteLine("Method 2 execution is completed");

//Method3();
//Console.WriteLine("Method 3 execution is completed");

static void Method1()
{
    Console.WriteLine("Method 1 started using thread: {0}", Thread.CurrentThread.Name);
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Method 1: {0}", i);
    }
    Console.WriteLine("Method 1 completed using thread: {0}", Thread.CurrentThread.Name);
}

static void Method2()
{
    Console.WriteLine("Method 2 started using thread: {0}", Thread.CurrentThread.Name);
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Method 2: {0}", i);
        if (i == 2)
        {
            Console.WriteLine("Method 2 DB operation started");
            //Sleep for 10 seconds
            Thread.Sleep(10000);
            Console.WriteLine("Method 2 DB operation completed");
        }
    }
    Console.WriteLine("Method 2 completed using thread: {0}", Thread.CurrentThread.Name);
}

static void Method3()
{
    Console.WriteLine("Method 3 started using thread: {0}", Thread.CurrentThread.Name);
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Method 3: {0}", i);
    }
    Console.WriteLine("Method 3 completed using thread: {0}", Thread.CurrentThread.Name);
}
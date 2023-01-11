// See https://aka.ms/new-console-template for more information
// Application uses a single thread
Thread t = Thread.CurrentThread;
t.Name = "Main Thread";
Console.WriteLine("Thread Name: {0}", t.Name);
Console.WriteLine("Current thread Name: {0}", Thread.CurrentThread.Name);

Method1();
Console.WriteLine("Method 1 execution is completed");

Method2();
Console.WriteLine("Method 2 execution is completed");

Method3();
Console.WriteLine("Method 3 execution is completed");

static void Method1()
{
	for (int i = 0; i < 5; i++)
	{
		Console.WriteLine("Method 1: {0}", i);
	}
}

static void Method2()
{
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
}

static void Method3()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Method 3: {0}", i);
    }
}
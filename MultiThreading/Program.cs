// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
Thread t = Thread.CurrentThread;
t.Name = "Main Thread";
Console.WriteLine("Thread Name: {0}", t.Name);
Console.WriteLine("Current thread Name: {0}", Thread.CurrentThread.Name);
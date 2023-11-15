using System;
using System.Diagnostics;
using System.Reflection;
using System.Timers;

class Program
{
    static string fileName = "numbers.txt";
    static object fileLock = new object();
    static object outputLock = new object();
    static bool done = false;
    static void Main()
    {
        //1
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            Console.WriteLine("ID: {0}", process.Id);
            Console.WriteLine("Имя: {0}", process.ProcessName);
            Console.WriteLine("Приоритет: {0}", process.BasePriority);
            //Console.WriteLine("Время запуска: {0}", process.StartTime);
            Console.WriteLine("Текущее состояние: {0}", process.Responding ? "Работает" : "Не отвечает");
            //Console.WriteLine("Время использования процессора: {0}", process.TotalProcessorTime);
            Console.WriteLine();
        }

        //2
        AppDomain currentDomain = AppDomain.CurrentDomain;
        Console.WriteLine("Имя домена: {0}", currentDomain.FriendlyName);
        Console.WriteLine("Детали конфигурации: {0}", currentDomain.SetupInformation);
        Console.WriteLine("Загруженные сборки:");
        Assembly[] assemblies = currentDomain.GetAssemblies();
        foreach (Assembly assembly in assemblies)
        {
            Console.WriteLine(assembly.FullName);
        }
        Console.WriteLine();

        //3
        Console.Write("Введите число n: ");
        int n = int.Parse(Console.ReadLine());
        PrimeNumbers pn = new PrimeNumbers(n);
        Thread thread = new Thread(pn.Calculate);

        thread.Name = "PrimeThread";
        thread.Priority = ThreadPriority.AboveNormal;

        thread.Start();

        Console.WriteLine("Информация о потоке:");
        Console.WriteLine("Имя: {0}", thread.Name);
        Console.WriteLine("Приоритет: {0}", thread.Priority);
        Console.WriteLine("ID: {0}", thread.ManagedThreadId);
        Console.WriteLine("Статус: {0}", thread.ThreadState);
        Console.WriteLine();

        Thread.Sleep(3000);
        thread.Join();

        Console.WriteLine("Информация о потоке после завершения:");
        Console.WriteLine("Статус: {0}", thread.ThreadState);
        Console.WriteLine();

        //4
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        Thread evenThread = new Thread(() => PrintNumbers(0));
        Thread oddThread = new Thread(() => PrintNumbers(1));

        evenThread.Priority = ThreadPriority.Lowest;
        oddThread.Priority = ThreadPriority.Highest;

        evenThread.Start();
        oddThread.Start();

        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();

        done = true;

        evenThread.Join();
        oddThread.Join();

        Console.WriteLine("\nСодержимое файла {0}:", fileName);
        Console.WriteLine(File.ReadAllText(fileName));

        System.Timers.Timer timer = new System.Timers.Timer(3000);
        timer.Elapsed += OnTimerElapsed;
        timer.Start();
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
        timer.Stop();
        timer.Dispose();
    }
    static void PrintNumbers(int start)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        int n = start;

        while (!done)
        {
            lock (fileLock)
            {
                File.AppendAllText(fileName, n + "\n");
            }
            lock (outputLock)
            {
                Console.WriteLine("Поток {0} вывел число {1}", threadId, n);
            }
            n += 2;
            Thread.Sleep(new Random().Next(100, 1000));
        }
    }
    static void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Текущее время: {0}", e.SignalTime);
    }
}

class PrimeNumbers
{
    private int n;
    private string fileName = "primes.txt";

    public PrimeNumbers(int n)
    {
        this.n = n;
    }

    public void Calculate()
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    writer.WriteLine(i);
                }
                Thread.Sleep(100);
            }
        }
    }

    private bool IsPrime(int number)
    {
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

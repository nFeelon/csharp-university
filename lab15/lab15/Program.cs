using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TPLPrimeNumbers
{
    class Program
    {
        const int MaxSize = 10;
        static BlockingCollection<string> warehouse = new BlockingCollection<string>(MaxSize);
        static string[] products = new string[] { "Холодильник", "Телевизор", "Пылесос", "Микроволновка", "Утюг", "Фен", "Чайник", "Кофеварка", "Миксер", "Тостер" };
        static int[] supplierSpeeds = new int[] { 3, 4, 5, 6, 7 };
        static int[] consumerSpeeds = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static Random random = new Random();

        static void Main(string[] args)
        {
            //1
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Stopwatch stopwatch = new Stopwatch();
            Task<List<int>> task = Task.Run(() => FindPrimeNumbers(n));
            Console.WriteLine("Идентификатор задачи: {0}", task.Id);
            Console.WriteLine("Задача завершена? {0}", task.IsCompleted);
            Console.WriteLine("Статус задачи: {0}", task.Status);
            task.Wait();


            List<int> primeNumbers = task.Result;
            Console.WriteLine("Найдено {0} простых чисел за {1} миллисекунд.", primeNumbers.Count, stopwatch.ElapsedMilliseconds);
            foreach (int prime in primeNumbers)
                Console.WriteLine(prime);

            //2
            Stopwatch stopwatch2 = new Stopwatch();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Task<List<int>> task2a = Task.Run(() => FindPrimeNumbersCancel(n, ct), ct);
            Console.WriteLine("Идентификатор задачи: {0}", task2a.Id);
            Console.WriteLine("Задача завершена? {0}", task2a.IsCompleted);
            Console.WriteLine("Статус задачи: {0}", task2a.Status);
            Console.WriteLine("Нажмите любую клавишу для отмены задачи.");
            Console.ReadKey();
            cts.Cancel();
            try
            {
                primeNumbers = task2a.Result;
                Console.WriteLine("Найдено {0} простых чисел за {1} миллисекунд.", primeNumbers.Count, stopwatch2.ElapsedMilliseconds);
                foreach (int prime in primeNumbers)
                    Console.WriteLine(prime);
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Задача была отменена.");
                    else
                        Console.WriteLine("Произошла ошибка: {0}", e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }

            //3
            Task<int> task1 = Task.Run(() => 2 + 3);
            Task<int> task2 = Task.Run(() => 2 * 3);
            Task<int> task3 = Task.Run(() => 2 - 3);
            Task<int> task4 = Task.Run(async () =>
            {
                await Task.WhenAll(task1, task2, task3);
                int result1 = task1.Result;
                int result2 = task2.Result;
                int result3 = task3.Result;
                int result4 = result1 * result2 / result3;
                return result4;
            });

            //4
            Task<string> continuation1 = task4.ContinueWith(t =>
            {
                int result4 = t.Result;
                return $"Результат расчета по формуле: (2 + 3) * (2 * 3) / (2 - 3) = {result4}";
            });
            Task<string> continuation2 = new Task<string>(() =>
            {
                TaskAwaiter<int> awaiter = task4.GetAwaiter();
                int result4 = 0;
                awaiter.OnCompleted(() =>
                {
                    result4 = awaiter.GetResult();
                });
                return $"Результат расчета по формуле: (2 + 3) * (2 * 3) / (2 - 3) = {result4}";
            });
            continuation2.Start();

            Console.WriteLine(continuation1.Result);
            Console.WriteLine(continuation2.Result);

            //5
            Random random = new Random();
            int[] array = Enumerable.Range(0, 1000000).Select(i => random.Next(100)).ToArray();
            List<int> transformed = new List<int>();
            Stopwatch stopwatch3 = new Stopwatch();

            stopwatch3.Start();
            for (int i = 0; i < array.Length; i++)
                transformed.Add(array[i] * array[i]);
            stopwatch3.Stop();
            Console.WriteLine("Обычный цикл for занял {0} миллисекунд.", stopwatch3.ElapsedMilliseconds);
            transformed.Clear();

            stopwatch3.Restart();
            Parallel.For(0, array.Length, i =>
            {
                lock (transformed)
                {
                    transformed.Add(array[i] * array[i]);
                }
            });
            stopwatch3.Stop();
            Console.WriteLine("Параллельный цикл Parallel.For занял {0} миллисекунд.", stopwatch3.ElapsedMilliseconds);
            transformed.Clear();

            stopwatch3.Restart();
            foreach (int number in array)
                transformed.Add(number * number);
            stopwatch3.Stop();
            Console.WriteLine("Обычный цикл foreach занял {0} миллисекунд.", stopwatch3.ElapsedMilliseconds);
            transformed.Clear();

            stopwatch3.Restart();
            Parallel.ForEach(array, number =>
            {
                lock (transformed)
                {
                    transformed.Add(number * number);
                }
            });
            stopwatch3.Stop();
            Console.WriteLine("Параллельный цикл Parallel.ForEach занял {0} миллисекунд.", stopwatch3.ElapsedMilliseconds);

            //6
            Action action1 = () =>
            {
                Console.WriteLine("Начало первого метода.");
                Thread.Sleep(1000);
                Console.WriteLine("Конец первого метода.");
            };
            Action action2 = () =>
            {
                Console.WriteLine("Начало второго метода.");
                Thread.Sleep(2000);
                Console.WriteLine("Конец второго метода.");
            };

            Action action3 = () =>
            {
                Console.WriteLine("Начало третьего метода.");
                Thread.Sleep(3000);
                Console.WriteLine("Конец третьего метода.");
            };
            Parallel.Invoke(action1, action2, action3);
            Console.WriteLine("Все методы выполнены.");

            //7
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                Task.Run(() => Supplier(index));
            }
            for (int i = 0; i < 10; i++)
            {
                int index = i;
                Task.Run(() => Consumer(index));
            }
            Console.ReadKey();
        }

        static List<int> FindPrimeNumbers(int n)
        {
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2);
            for (int i = 3; i <= n; i += 2)
            {
                bool isPrime = true;
                for (int j = 0; primeNumbers[j] * primeNumbers[j] <= i; j++)
                    if (i % primeNumbers[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                if (isPrime)
                    primeNumbers.Add(i);
            }
            return primeNumbers;
        }
        static List<int> FindPrimeNumbersCancel(int n, CancellationToken ct)
        {
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2);
            for (int i = 3; i <= n; i += 2)
            {
                ct.ThrowIfCancellationRequested();
                bool isPrime = true;
                for (int j = 0; primeNumbers[j] * primeNumbers[j] <= i; j++)
                    if (i % primeNumbers[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                if (isPrime)
                    primeNumbers.Add(i);
            }
            return primeNumbers;
        }
        static void Supplier(int index)
        {
            while (true)
            {
                int productIndex = random.Next(products.Length);
                string product = products[productIndex];
                warehouse.Add(product);
                Console.WriteLine($"Поставщик {index + 1} привез товар {product}. На складе: {string.Join(", ", warehouse)}");
                Thread.Sleep(supplierSpeeds[index] * 1000);
            }
        }
        static void Consumer(int index)
        {
            while (true)
            {
                string product = warehouse.Take();
                Console.WriteLine($"Покупатель {index + 1} купил товар {product}. На складе: {string.Join(", ", warehouse)}");
                Thread.Sleep(consumerSpeeds[index] * 1000);
            }
        }
    }
}

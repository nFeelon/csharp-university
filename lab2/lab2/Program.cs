using System;
class Program
{
    static void Main()
    {
        Time[] times = new Time[]
        {
            new Time(1,11,51),
            new Time(3),
            new Time(4,20),
            new Time(6,55,24),
            new Time(7,59,59),
            new Time(10,30,45),
            new Time(12,7,37),
            new Time(15,35,33),
            new Time(16,24,21),
            new Time(17,20,16),
            new Time(17,42,8),
            new Time(19,56,6),
            new Time(20,27,2),
            new Time(21,11,16),
            new Time(23,30,18),
            new Time(0,25,30),
            new Time()
        };

        Console.WriteLine("Введите час: ");
        int targetH = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Время с {targetH} часами: ");
        foreach (var time in times)
        {
            if(time.Hours == targetH)
            {
                Console.WriteLine(time);
            }
        }
        Time time1 = Time.CreateTime();
        Time time2 = Time.Instance;
        Console.WriteLine($"Статический метод: {time1}");
        Console.WriteLine($"Статическое поле:  {time2}");

        int Hour1 = 20;
        int add = 2;
        int IDtime1;
        time1.AddTime(ref Hour1, add, out IDtime1);
        Console.WriteLine($"Новый час: {Hour1}, ID: {IDtime1}");

        Time.ClassInfo();

        Time a = new Time(3, 30, 25);
        Time b = new Time(3, 30, 25);
        bool Eq = a.Equals(b);
        Console.WriteLine($"A и B равны?: {Eq}");

        if(time1 is Time)
        {
            Console.WriteLine("time1 - объект класса Time");
            Console.WriteLine(time1.GetType().Name);
        }

        Console.WriteLine("\nНочное время:");
        foreach (var time in times)
        {
            if (time.Hours >= 0 && time.Hours <= 6)
            {
                Console.WriteLine(time);
            }
        }
        Console.WriteLine("\nУтреннее время:");
        foreach (var time in times)
        {
            if (time.Hours > 6 && time.Hours <= 12)
            {
                Console.WriteLine(time);
            }
        }
        Console.WriteLine("\nДневное время:");
        foreach (var time in times)
        {
            if (time.Hours > 12 && time.Hours <= 18)
            {
                Console.WriteLine(time);
            }
        }
        Console.WriteLine("\nВечернее время:");
        foreach (var time in times)
        {
            if (time.Hours > 18 && time.Hours <=23)
            {
                Console.WriteLine(time);
            }
        }

        var anonimTime = new
        {
            Hours = 0,
            Minutes = 0,
            Seconds = 0
        };
        Console.WriteLine(anonimTime.GetType().Name);
    }

}
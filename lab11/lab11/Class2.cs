public class TestClass
{
    public int number;

    public TestClass(int i)
    {
        number = i;
    }

    public void MultiplyNumber(int a)
    {
        number *= a;
        Console.WriteLine($"Метод класса вызвался!: {number}");
    }

    public override string ToString()
    {
        return $"{number}";
    }
}

public class Time
{
    private int hour;
    private int minute;
    private int second;

    public int Hours
    {
        get { return hour; }
        set
        {
            if (value >= 0 && value <= 23)
            {
                hour = value;
            }
            else
            {
                throw new ArgumentException("Диапазон часов от 0 до 23");
            }
        }
    }

    public int Minutes
    {
        get { return minute; }
        set
        {
            if (value >= 0 && value <= 59)
            {
                minute = value;
            }
            else
            {
                throw new ArgumentException("Диапазон минут от 0 до 59");
            }
        }
    }

    public int Seconds
    {
        get { return second; }
        set
        {
            if (value >= 0 && value <= 59)
            {
                second = value;
            }
            else
            {
                throw new ArgumentException("Диапазон минут от 0 до 59");
            }
        }
    }

    public Time(int hour = 0, int minute = 0, int second = 0)
    {
        Hours = hour;
        Minutes = minute;
        Seconds = second;
    }

    public void Timers(int i)
    {
        Console.WriteLine("Вызов метода с параметром " + i);
    }
    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
}
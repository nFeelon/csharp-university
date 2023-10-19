partial class Time
{
    private static int count = 0;
    private readonly int ID;

    private const int maxHours = 23;
    private const int maxMinutes = 59;
    private const int maxSeconds = 59;

    private int hour;
    private int minute;
    private int second;
    private int millisecond;

    public int Hours
    {
        get { return hour; }
        set
        {
            if (value >= 0 && value <= maxHours)
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
            if (value >= 0 && value <= maxMinutes)
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
            if (value >= 0 && value <= maxSeconds)
            {
                second = value;
            }
            else
            {
                throw new ArgumentException("Диапазон минут от 0 до 59");
            }
        }
    }
    public int Milliseconds
    {
        get { return millisecond; }
        private set { 
            if (value >= 0 && value <= 100) 
            {
                millisecond = value;
            } 
            else
            {
                throw new ArgumentException("Диапазон миллисекунд от 0 до 100");
            }
        }
    }
    static Time()
    {
        Console.WriteLine("Вызывается статический конструктор.");
    }

    private Time()
    {
        hour = 1;
        minute = 0;
        second = 0;
        ID = HashGenerate(hour, minute, second);
        count++;
    }
    public static Time CreateTime()
    {
        return new Time();
    }
    private static Time instance;
    public static Time Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Time(); 
            }
            return instance;
        }
    }

    public Time(int hour = 0, int minute = 0, int second = 0) 
    {
        Hours = hour;
        Minutes = minute;
        Seconds = second;
        ID = HashGenerate(hour, minute, second);
        count++;
    }

    public Time (int hour, int minute)
    {
        Hours = hour;
        Minutes = minute;
        Seconds = 0;
        ID = HashGenerate(hour, minute, second);
        count++;
    }
    private int HashGenerate(int hour, int minute, int second)
    {
        return this.GetHashCode()^hour.GetHashCode()^minute.GetHashCode()^second.GetHashCode();
    }


    public static void ClassInfo()
    {
        Console.WriteLine($"Создано объектов класса Time: {count}");
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + hour.GetHashCode();
            hash = hash * 23 + minute.GetHashCode();
            hash = hash * 23 + second.GetHashCode();
            return hash;
        }
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is Time))
        {
            return false;
        }
        Time otherTime = (Time)obj;
        return this.hour == otherTime.hour && this.minute == otherTime.minute && this.second == otherTime.second;
    }
    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}, ID: {ID}";
    }
}
class Program
{
    public static void Main(string[] args)
    {
        //1

        string[] months = new string[]
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        int n = 4;
        var query1 = from month in months where month.Length == n select month;
        Console.WriteLine($"\nМесяцы с длиной строки равной {n}: ");
        foreach( var month in query1)
            Console.WriteLine(month);

        string[] summer = new string[]
        {
            "June", "July", "August"
        };
        string[] winter = new string[]
        {
            "December", "January", "February"
        };
        var query2 = from month in months where summer.Contains(month) || winter.Contains(month) select month;
        Console.WriteLine("\nЛетние и зимние месяцы: ");
        foreach( var month in query2)
            Console.WriteLine(month);

        var query3 = from month in months orderby month select month;
        Console.WriteLine("\nМесяцы в алфавитном порядке: ");
        foreach (var month in query3)
            Console.WriteLine(month);

        var query4 = from month in months where month.Contains("u") && month.Length>=4 select month;
        Console.WriteLine("\nМесяцы, содержащие букву 'u' и длиной имени не менее 4-х: ");
        foreach(var month in query4)
            Console.WriteLine(month);

        //2

        List<Time> Times = new List<Time>()
        {
            new Time(5, 25, 29),
            new Time(0, 15, 30),
            new Time(0, 16, 15),
            new Time(16, 23, 0),
            new Time(3, 14, 45),
            new Time(7, 7, 59),
            new Time(22, 0, 0),
            new Time(12, 59, 25),
            new Time(14, 51, 10),
            new Time(22, 40, 59),
        };

        //3

        int hours = 22;
        var hours1 = from hour in Times where hour.Hours == hours select hour;
        Console.WriteLine($"\nВсе элементы с часами {hours}: ");
        foreach (var hour in hours1)
            Console.WriteLine(hour);

        var night = from hour in Times where hour.Hours >= 0 && hour.Hours <= 6 select hour;
        var morning = from hour in Times where hour.Hours > 6 && hour.Hours <= 12 select hour;
        var day = from hour in Times where hour.Hours > 12 && hour.Hours <= 18 select hour;
        var evening = from hour in Times where hour.Hours > 18 && hour.Hours <= 23 select hour;
        Console.WriteLine("\nСписок по времени суток: ");
        Console.WriteLine("-Ночь: ");
        foreach (var hour in night)
            Console.WriteLine(hour);
        Console.WriteLine("-Утро: ");
        foreach (var hour in morning)
            Console.WriteLine(hour);
        Console.WriteLine("-День: ");
        foreach (var hour in day)
            Console.WriteLine(hour);
        Console.WriteLine("-Вечер: ");
        foreach (var hour in evening)
            Console.WriteLine(hour);

        var minTime = Times.MinBy(a => a.Hours);
        Console.WriteLine($"\nМинимальное время: {minTime}");

        var equalTime = from hour in Times where hour.Hours == hour.Minutes select hour;
        Console.WriteLine($"\nПервый элемент, где совпадают часы и минуты: {equalTime.First()}");

        var orderTime = from hour in Times orderby hour.Hours select hour;
        Console.WriteLine("\nУпорядоченное время: ");
        foreach (var hour in orderTime)
            Console.WriteLine(hour);

        //4

        Random random = new Random();
        int[] numbers = new int[20];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 101);
        }
        Console.WriteLine("\nИсходный массив:");
        foreach (var number in numbers)
            Console.Write(number + " ");

        // Выбирает только четные числа, умножает их на 2, сортирует их по убыванию, группирует их по десяткам и выводит сумму каждой группы
        var query = from number in numbers
                    where number % 2 == 0
                    select number * 2
                    into doubled
                    orderby doubled descending
                    group doubled by doubled / 10
                    into groupByTen
                    select new { Key = groupByTen.Key, Sum = groupByTen.Sum() };

        Console.WriteLine("\nРезультат запроса:");
        foreach (var item in query)
            Console.WriteLine("Группа {0}0: Сумма {1}", item.Key, item.Sum);

        //5

        string[] countries = new string[] { "Беларусь", "Россия", "Украина", "Польша", "Литва", "Латвия", "Эстония" };
        string[] capitals = new string[] { "Минск", "Москва", "Киев", "Варшава", "Вильнюс", "Рига", "Таллин" };

        var query5 = from country in countries
                    join capital in capitals on Array.IndexOf(countries, country) equals Array.IndexOf(capitals, capital)
                    select new { Country = country, Capital = capital };

        Console.WriteLine("\nРезультат запроса:");
        foreach (var item in query5)
        {
            Console.WriteLine("{0} - {1}", item.Country, item.Capital);
        }
    }
}

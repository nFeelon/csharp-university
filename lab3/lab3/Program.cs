using System.Diagnostics.Metrics;

String str1 = new String("ABCD! Efgd, 124.");
String str2 = new String("5124? Sada. B23ab.");

Console.WriteLine(str1.Length());
Console.WriteLine(str2.Length());

Console.WriteLine(str1 > str2);
Console.WriteLine(str1 < str2);
Console.WriteLine(str1 == str2);
Console.WriteLine(str1 != str2);

Console.WriteLine((str1+25).Value);
Console.WriteLine((str2 * 'a').Value); ;
Console.WriteLine((-str1).Value);

Console.WriteLine(str1.HasControlChars());
Console.WriteLine((str2.RemovePunct()).Value);

String.Production p = new String.Production("Microsoft", 0);
String.Developer d = new String.Developer("Nikita Filon", 1, "GameDev");
String obj = new String("Hello", "Valve", 1, "Neapl", 2, "GameDev");
obj.ShowInfo();

Console.WriteLine((str1.Sum(str2)).Value);
Console.WriteLine(str1.Diff());
Console.WriteLine(str1.Count());

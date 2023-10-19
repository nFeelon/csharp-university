using System;
using System.Collections;

public static class Logger
{
    public static void Log(ArgumentException exc, bool fileLogger, bool consoleLogger)
    {
        if (fileLogger) FileLogger(exc);
        if (consoleLogger == true)
        {
            if (exc is InvalidButtonNameException)
            {
                ConsoleLogger(exc as InvalidButtonNameException);
            }
            else if (exc is InvalidWindowNameException)
            {
                ConsoleLogger(exc as InvalidWindowNameException);
            }
            else if (exc is InvalidStyleDescriptionException)
            {
                ConsoleLogger(exc as InvalidStyleDescriptionException);
            }
            else if (exc is InvalidCoordsException)
            {
                ConsoleLogger(exc as InvalidCoordsException);
            }
        }
    }

    private static void FileLogger(Exception exc)
    {
        string error = $"{DateTime.Now}, Info: {exc.Message}";
        using (StreamWriter file = new StreamWriter(@"..\..\..\log.txt", true))
        {
            file.WriteLine(error);
            file.Close();
        }
    }

    private static void ConsoleLogger(InvalidButtonNameException exc)
    {
        Console.WriteLine("\n------Error");
        Console.WriteLine($"Message: {exc.Message}");
        Console.WriteLine($"Wrong name: {exc.Value}");
        Console.WriteLine("Path: {0}", exc.TargetSite);
        foreach (DictionaryEntry d in exc.Data)
            Console.WriteLine("-> {0}, {1}", d.Key, d.Value);
    }

    private static void ConsoleLogger(InvalidWindowNameException exc)
    {
        Console.WriteLine("\n------Error");
        Console.WriteLine($"Message: {exc.Message}");
        Console.WriteLine($"Wrong name: {exc.Value}");
        Console.WriteLine("Path: {0}", exc.TargetSite);
        foreach (DictionaryEntry d in exc.Data)
            Console.WriteLine("-> {0}, {1}", d.Key, d.Value);
    }

    private static void ConsoleLogger(InvalidStyleDescriptionException exc)
    {
        Console.WriteLine("\n------Error");
        Console.WriteLine($"Message: {exc.Message}");
        Console.WriteLine($"Wrong description: {exc.Value}");
        Console.WriteLine("Path: {0}", exc.TargetSite);
        foreach (DictionaryEntry d in exc.Data)
            Console.WriteLine("-> {0}, {1}", d.Key, d.Value);
    }

    private static void ConsoleLogger(InvalidCoordsException exc)
    {
        Console.WriteLine("\n------Error");
        Console.WriteLine($"Message: {exc.Message}");
        Console.WriteLine($"Wrong lenght: {exc.Value}");
        Console.WriteLine("Path: {0}", exc.TargetSite);
        foreach (DictionaryEntry d in exc.Data)
            Console.WriteLine("-> {0}, {1}", d.Key, d.Value);
    }
}

using System.Text;

class Program
{
    static void Main(string[] args)
    {

        Boss boss = new Boss();
        boss.Upgrade += (this, Boss.UpgradeEventHandler upgradeEventHandler) =>
        {
            Console.WriteLine("Вы вызвали анонимную функцию!");
        };


        Robot robot1 = new Robot("R2-D2");
        Robot robot2 = new Robot("C-3PO");
        Cyborg cyborg1 = new Cyborg("Terminator");
        Cyborg cyborg2 = new Cyborg("Robocop");

        boss.Upgrade += robot1.OnUpgrade;
        boss.Upgrade += cyborg2.OnUpgrade;
        boss.TurnOn += robot2.OnTurnOn;
        boss.TurnOn += cyborg1.OnTurnOn;

        boss.RaiseUpgrade();
        Console.WriteLine("\n");
        boss.RaiseTurnOn(600);

        Console.WriteLine("\nПосле событий:");
        Console.WriteLine($"Имя робота 1: {robot1.Name}");
        Console.WriteLine($"Имя робота 2: {robot2.Name}");
        Console.WriteLine($"Имя киборга 1: {cyborg1.Name}");
        Console.WriteLine($"Имя киборга 2: {cyborg2.Name}");

        Console.ReadKey();

        string input = "Это пример строки, которая будет обработана разными методами.";
        Console.WriteLine("Исходная строка: " + input);

        Action<string> removePunctuation = RemovePunctuation;
        Func<string, string> addSymbols = AddSymbols;
        Func<string, string> toUpperCase = ToUpperCase;
        Func<string, string> removeExtraSpaces = RemoveExtraSpaces;
        Predicate<string> isPalindrome = IsPalindrome;

        removePunctuation(input);
        input = addSymbols(input);
        input = toUpperCase(input); 
        input = removeExtraSpaces(input);
        bool palindrome = isPalindrome(input); 

        Console.WriteLine("Обработанная строка: " + input);
        Console.WriteLine("Является ли строка палиндромом: " + palindrome);
    }

    static void RemovePunctuation(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if (!char.IsPunctuation(c))
            {
                sb.Append(c);
            }
        }
        s = sb.ToString();
    }

    static string AddSymbols(string s)
    {
        return "*" + s + "*";
    }

    static string ToUpperCase(string s)
    {
        return s.ToUpper();
    }

    static string RemoveExtraSpaces(string s)
    {
        return string.Join(" ", s.Split().Where(x => !string.IsNullOrWhiteSpace(x)));
    }

    static bool IsPalindrome(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] != s[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

}

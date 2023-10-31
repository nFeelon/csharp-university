public class Boss
{
    public delegate void UpgradeEventHandler(object sender, EventArgs e);
    public delegate void TurnOnEventHandler(object sender, TurnOnEventArgs e);

    public event UpgradeEventHandler Upgrade;
    public event TurnOnEventHandler TurnOn;

    public void RaiseUpgrade()
    {
        Console.WriteLine("Boss: Я повышаю уровень!");
        if (Upgrade != null)
        {
            Upgrade(this, EventArgs.Empty);
        }
    }

    public void RaiseTurnOn(int voltage)
    {
        Console.WriteLine($"Boss: Я включаюсь под напряжением {voltage} В!");
        if (TurnOn != null)
        {
            TurnOnEventArgs args = new TurnOnEventArgs(voltage);
            TurnOn(this, args);
        }
    }

}

public class TurnOnEventArgs : EventArgs
{
    public int Voltage { get; set; }
    public TurnOnEventArgs(int voltage)
    {
        Voltage = voltage;
    }

}

public class Robot
{
    public string Name { get; set; }

    public Robot(string name)
    {
        Name = name;
    }

    public void OnUpgrade(object sender, EventArgs e)
    {
        Console.WriteLine($"{Name}: Я получил новые возможности!");
    }

    public void OnTurnOn(object sender, TurnOnEventArgs e)
    {
        if (e.Voltage > 1000)
        {
            Console.WriteLine($"{Name}: Я сломался из-за перенапряжения!");
        }
        else
        {
            Console.WriteLine($"{Name}: Я успешно включился!");
        }
    }

}

public class Cyborg
{
    public string Name { get; set; }
    public Cyborg(string name)
    {
        Name = name;
    }

    public void OnUpgrade(object sender, EventArgs e)
    {
        Console.WriteLine($"{Name}: Я стал более человечным!");
    }

    public void OnTurnOn(object sender, TurnOnEventArgs e)
    {
        if (e.Voltage > 500)
        {
            Console.WriteLine($"{Name}: Я пострадал из-за перенапряжения!");
        }
        else
        {
            Console.WriteLine($"{Name}: Я успешно включился!");
        }
    }

}
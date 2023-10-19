using System;

partial class Time
{
    public void AddTime(ref int incHour, int add, out int ID)
    {
        incHour += add;
        if (incHour > maxHours)
        {
            incHour -= 24;
        }
        ID = HashGenerate(incHour, 0, 0);
    }
}

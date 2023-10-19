using System;

class InvalidCoordsException : ArgumentException
{
    public Point Value { get; }
    public InvalidCoordsException(string message, Point point) :base(message)
    {
        Value = point;
        Data.Add("Time: ", DateTime.Now);
    }
}

class InvalidButtonNameException : ArgumentException
{
    public string Value { get; }
    public InvalidButtonNameException(string message, string name) :base(message)
    {
        Value = name;
        Data.Add($"Time: ", DateTime.Now);
    }
}

class InvalidWindowNameException : InvalidButtonNameException
{
    public InvalidWindowNameException(string message, string name) :base(message,name)
    {
        //Data.Add($"Time: ", DateTime.Now);
    }
}

class InvalidStyleDescriptionException : ArgumentException
{
    public string Value { get; }
    public InvalidStyleDescriptionException(string message, string style) :base(message)
    {
        Value = style;
        Data.Add($"Time: ", DateTime.Now);
    }
}
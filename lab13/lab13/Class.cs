using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
#pragma warning disable SYSLIB0011

[Serializable]
public class Figure
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Color { get; set; }

    public Figure()
    {
        X = 0; Y = 0;
        Color = "White";
    }
    public Figure(int x, int y, string color)
    {
        X = x;
        Y = y;
        Color = color;
    }
}


[Serializable]
public class Rectangle : Figure
{
    public int Width { get; set; }
    public int Height { get; set; }

    public string Name;

    [JsonIgnore]
    public string Description;
    public Rectangle() : base()
    {
        Width = 0; Height = 0;
        Name = "";
        Description = "";
    }
    public Rectangle(int x, int y, string color, int width, int height, string name, string description) : base(x, y, color)
    {
        Width = width;
        Height = height;
        Name = name;
        Description = description;
    }
}

[Serializable]
public class Control : Rectangle
{
    public string Text { get; set; }
    public Control() : base()
    {
        Text = "";
    }
    public Control(int x, int y, string color, int width, int height, string name, string description, string text) : base(x, y, color, width, height, name, description)
    {
        Text = text;
    }
}

[Serializable]
public class Button : Control
{
    public string Action { get; set; }

    public Button() : base()
    {
        Action = "OK";
    }
    public Button(int x, int y, string color, int width, int height,string name, string description, string text, string action) : base(x, y, color, width, height,name, description, text)
    {
        Action = action;
    }
}

public abstract class Serializer
{
    public abstract void Serialize(Stream stream, object obj);
    public abstract object Deserialize(Stream stream, Type type);
}

public class BinarySerializer : Serializer
{
    private BinaryFormatter formatter;
    public BinarySerializer()
    {
        formatter = new BinaryFormatter();
    }
    public override void Serialize(Stream stream, object obj)
    {
        formatter.Serialize(stream, obj);
    }
    public override object Deserialize(Stream stream, Type type)
    {
        return formatter.Deserialize(stream);
    }
}
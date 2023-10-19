using System;
using System.Diagnostics;
using System.Globalization;

public enum WindowsStyle
{
    Classic,
    Modern,
    Futuristic
}

public class Rectangle : Figure, IShape
{
    protected double h, w;

    public double Height
    {
        get { return h; }
    }
    public double Width
    {
        get { return w; }
    }
    public Rectangle() : base() 
    {
        h = 0;
        w = 0;
    }
    public Rectangle(double x, double y, double h, double w) : base(x,y) 
    {
        this.h = h;
        this.w = w;
    }

    public override double Square
    {
        get { return h * w; }
    }
    public override double Perimeter
    {
        get { return 2 * (h + w); }
    }

    string IShape.Show()
    {
        return $"Interface rectangle: Center: ({center.X}, {center.Y}), Height: {h}, Width: {w}";
    } 
    public override string Show()
    {
        return $"Rectangle: Center: ({center.X}, {center.Y}), Height: {h}, Width: {w}";
    }
    public override string ToString()
    {
        return Show();
    }
}

public class Style
{
    protected string color;
    protected string style;
    
    public Style()
    {
        color = "black";
        style = "normal";
    }
    public Style(string color, string style)
    {
        
           this.color = color;
           this.style = style;
    }
    public string Show()
    {
        return $"Color: {color}, Style: {style}";
    }

    public string ToString()
    {
        return Show();
    }
}

public  partial class Control: Rectangle
{
    protected Style style;
    public Control() :base()
    {
        style = new Style();
    }
    public Control(double x, double y, double h, double w, string color, string style) : base(x, y, h, w)
    {
        this.style = new Style(color, style);
    }
}

public sealed class Button : Control
{
    public string text;
    public Button() : base()
    {
        text = "";
    }
    public Button(double x, double y, double h, double w, string color, string style, string text) : base(x,y,h,w,color,style)
    {
        this.text = text;
    }
    public override string Show()
    {
        Console.WriteLine("\nx. "+ style.ToString());
        return $"-Button: Center: ({center.X}, {center.Y}), Height: {h}, Width: {w}, Text: {text}";
    }
    public override string ToString()
    {
        return Show();
    }

}

public class Menu: Control
{
    protected List<Button> items;
    public int level;

    public Menu() : base()
    {
        items = new List<Button>();
        level = 0;
    }
    public Menu(double x, double y, double h, double w, string color, string style, List<Button> items, int level) :base(x,y,h,w,color,style)
    {
        this.items = items;
        this.level = level;
    }
    public void AddItem(Button item)
    {
        items.Add(item);
    }
    public void RemoveItem(Button item)
    {
        items.Remove(item);
    }
    public override string Show()
    {
        Console.WriteLine(style.ToString());
        Console.WriteLine("Buttons: ");
        foreach(Button item in items)
        {
            Console.WriteLine(item.ToString());
        }
        return $"\nMenu: Center: ({center.X}, {center.Y}), Height: {h}, Width: {w}, Level: {level}";
    }
    public override string ToString()
    {
        return Show();
    }
}

public class Window : Rectangle
{
    protected string title;
    protected List<Menu> menu;
    protected WindowsStyle windowsStyle;

    public List<Menu> Menu
    {
        get { return menu; }
    }
    public Window() : base()
    {
        title = "";
        menu = new List<Menu>();
        windowsStyle = WindowsStyle.Classic;
    }
    public Window(double x, double y, double h, double w, string title, WindowsStyle style) :base(x,y,h,w)
    {
        this.title = title;
        menu = new List<Menu>();
        windowsStyle = style;
    }
    public void AddMenu(Menu item)
    {
        menu.Add(item);
    }
    public void RemoveMenu(Menu item)
    {
        menu.Remove(item);
    }
    public override string Show()
    {
        Console.WriteLine("--Menu: ");
        foreach(Menu item in menu)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine(windowsStyle.ToString());
        return $"\n--Window: Center: ({center.X}, {center.Y}), Height: {h}, Width: {w}, Title: {title}";
    }
    public override string ToString()
    {
        return Show();
    }
}
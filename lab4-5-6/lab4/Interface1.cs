interface IShape
{
    double Square
    {
        get;
    }
    double Perimeter
    {
        get;
    }
    string Show();
}

public abstract class Figure : IShape
{
    protected Point center;

    public Figure() {
        center = new Point(0,0);
    }
    public Figure(double x, double y)
    {
        if(x > 999 || y > 999)
        {
            throw new InvalidCoordsException("Coords can't exceed 999", new Point(x,y));
        }
        else if (x<0 || y<0)
        {
            throw new ArgumentOutOfRangeException("Coords can't be negative");
        }
        else this.center = new Point(x,y);
    }
    public virtual double Square
    {
        get { return 0; }
    }
    public virtual double Perimeter {
        get { return 0; }
    }
    public virtual string Show()
    {
        return $"Center: ({center.X}, {center.Y})";
    }

    public override string ToString()
    {
        return Show();
    }
    public override bool Equals(object? obj)
    {
        if(obj == null || GetType() != obj.GetType()) return false;
        Figure f = (Figure)obj;
        return (center.X==f.center.X) && (center.Y==f.center.Y);
    }
    public override int GetHashCode()
    {
        return center.X.GetHashCode()^center.Y.GetHashCode();
    }
}

class Printer
{
    public Printer() { }
    public void IAmPrinting(IShape shape)
    {
        try
        {
            switch (shape)
            {
                case Window w:
                    Console.WriteLine(shape.ToString());
                    break;
                case Menu m:
                    Console.WriteLine(shape.ToString());
                    break;
                case Button b:
                    Console.WriteLine(shape.ToString());
                    break;
                case Control c:
                    Console.WriteLine(shape.ToString());
                    break;
                case Rectangle r:
                    Console.WriteLine(shape.ToString());
                    break;
                default:
                    throw new ArgumentException("Wrong type of shape");
            }
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine("Memory error: " + e.Message);
        }
    }
}

public struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
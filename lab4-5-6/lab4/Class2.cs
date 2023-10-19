public partial class Control : Rectangle
{
    public override string Show()
    {
        Console.WriteLine(style.ToString());
        return $"Control element: Center({center.X}, {center.Y}), Height: {h}, Width: {w}";
    }
    public override string ToString()
    {
        return Show();
    }
}
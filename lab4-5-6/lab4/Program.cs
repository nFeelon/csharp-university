class Program
{
    static void Main(string[] args)
    {
        try
        {
            int p = 1;
            int c = 0;
            if (c == 0) throw new DivideByZeroException("You can't divide by zero.");
            else p /= c;
        }
        catch (DivideByZeroException exc)
        {
            Console.WriteLine("\n------Error");
            Console.WriteLine($"Message: {exc.Message}");
            Console.WriteLine("Path: {0}", exc.TargetSite);
        }
        finally
        {
            Console.WriteLine("---");
        }

        bool fl = true;
        try
        {
            Char ch = Convert.ToChar(fl);
            Console.WriteLine("Success convert.");
        }
        catch (InvalidCastException exc)
        {
            Console.WriteLine("\n------Error");
            Console.WriteLine("Message: It is impossible to convert boolean to char");
            Console.WriteLine("Path: {0}", exc.TargetSite);
        }
        finally
        {
            Console.WriteLine("---");
        }

        try
        {
            Rectangle rec1 = new Rectangle(1000, 0, 25, 25);
        }
        catch (InvalidCoordsException exc)
        {
            Logger.Log(exc, true, true);
        }
        finally
        {
            Console.WriteLine("---");
        }

        try
        {
            Button btn1 = new Button(5, 5, 20, 20, "black", "12312312312214567", "12131231231231231233");
        }
        catch (InvalidCoordsException exc1)
        {
            Logger.Log(exc1, true, true);
        }
        catch (InvalidStyleDescriptionException exc)
        {
            Logger.Log(exc, true, true);
        }
        catch (InvalidButtonNameException exc)
        {
            Logger.Log(exc, true, true);
        }
        finally 
        {
            Console.WriteLine("---");
        }

        try
        {
            Window win1 = new Window(1,1,5,5,"12312312312312312312", WindowsStyle.Classic);
        }
        catch (InvalidCoordsException exc) 
        {
            Logger.Log(exc, true, true);
        }
        catch (InvalidWindowNameException exc)
        {
            Logger.Log(exc, true, true);
        }
        finally
        {
            Console.WriteLine("---");
        }

        Menu menu1 = new Menu(5,5,5,5,"black","normal",new List<Button>(), -1);

        // Лабораторная 6
        /* Лабораторные 4-5
        IShape element = new Rectangle(2,2,20,20);
        Printer printer = new Printer();
        printer.IAmPrinting(element);

        Button button1 = new Button(1,1, 10, 10, "red", "bold", "New game");
        Button button2 = new Button(1, 2, 10, 10, "red", "bold", "Exit");
        Button button3 = new Button(1, 3, 10, 10, "red", "light", "Settings");
        Console.WriteLine(((IShape)button1).Show());
        Console.WriteLine(button1.Show());

        Menu menu1 = new Menu(1,0, 100, 100, "darkred", "normal", new List<Button> {button1, button2, button3}, 1);

        Window window1 = new Window(0,0, 720, 1280, "Main window", WindowsStyle.Classic);
        window1.AddMenu(menu1);

        Console.WriteLine(window1.ToString());

        if(window1 is Rectangle)
        {
            Rectangle rect = window1 as Rectangle;
            Console.WriteLine("Window1 as Rectangle");
        }

        Console.WriteLine("\n\n---------");
        IShape[] shapes = new IShape[]
        {
            new Window(0, 0, 500, 500, "Main Window", WindowsStyle.Classic),
            new Menu(3, 3, 40, 40, "green", "normal", new List<Button>(), 0),
            new Button(2, 2, 30, 30, "blue", "italic", "Click me"),
            new Rectangle(0, 0, 10, 10)
        };
        foreach(IShape item in shapes)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\n\n\n_---------------_");
        SoftwareInterface software = new SoftwareInterface();
        SIController SIo = new SIController(software);
        SIo.AddRect(button1);
        SIo.AddRect(button2);
        SIo.AddRect(button3);
        SIo.AddRect(menu1);
        SIo.AddRect(window1);

        Console.WriteLine("\n--------\nAll elements of Interface: ");
        SIo.Print();
        Console.WriteLine();
        Console.WriteLine("\n----------\nTotal count of elements: " + SIo.GetTotalElements());

        List<Button> buttons = new List<Button>();
        buttons = SIo.SearchButtons();
        Console.WriteLine("\n---------\nAll buttons: ");
        foreach (var item in buttons)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();

        List<Menu> menu = new List<Menu>();
        menu = SIo.SearchMenu(1);
        Console.WriteLine("\n----------\nAll menus with level 1: ");
        foreach(var item in menu)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("\n------------\nFree space in Window: " +SIo.FreeSpace());
        */



    }

}
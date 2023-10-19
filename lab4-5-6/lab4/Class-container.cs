public class SoftwareInterface
{
    protected List<Figure> data;

   public SoftwareInterface()
    {
        data = new List<Figure>();
    }

    public void AddRect(Figure rect)
    {
        data.Add(rect);
    }
    public void RemoveRect(Figure rect)
    {
        data.Remove(rect);
    }
    public void Print()
    {
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    public int GetTotalElements()
    {
        return data.Count;
    }
    public List<Button> SearchButtons()
    {
        List<Button> buttons = new List<Button>();
        foreach(var item in data)
        {
            if(item is Button)
            {
                buttons.Add((Button)item);
            }
        }
        return buttons;
    }

    public List<Menu> SearchMenu(int level)
    {
        List<Menu> menus = new List<Menu>();
        foreach (var item in data)
        {
            if (item is Menu)
            {
                Menu o = (Menu)item;
                if(o.level== level)
                {
                    menus.Add(o);
                }
            }
        }
        return menus;
    }

    public double FreeSpace()
    {
        double freespace = 0;
        Window obj;
        foreach (var windows in data)
        {
            if(windows is Window)
            {
                obj = (Window)windows;
                freespace = obj.Square;
                List<Menu> menuW = obj.Menu;
                foreach (var menu in menuW)
                {
                    freespace -= menu.Square;
                }
                break;
            }
        }
        return freespace;
    }
}

public class SIController
{
    private SoftwareInterface SIobj;
    
    public SIController()
    {
        SIobj = new SoftwareInterface();
    }
    public SIController(SoftwareInterface sIobj)
    {
        SIobj = sIobj;
    }

    public void AddRect(Figure rect)
    {
        SIobj.AddRect(rect);
    }
    public void RemoveRect(Figure rect)
    {
        SIobj.RemoveRect(rect);
    }
    public void Print()
    {
        SIobj.Print();
    }
    public int GetTotalElements()
    {
        return SIobj.GetTotalElements();
    }
    public List<Button> SearchButtons()
    {
        return SIobj.SearchButtons();
    }
    public List<Menu> SearchMenu(int level)
    {
        return SIobj.SearchMenu(level);
    }
    public double FreeSpace()
    {
        return SIobj.FreeSpace();
    }
}
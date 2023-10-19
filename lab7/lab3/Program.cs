using System;
using System.ComponentModel.Design.Serialization;

partial class Program
{
    static void Main(string[] args)
    {
        CollectionType<string> obj1 = new CollectionType<string>();
        IOperations<string> a;
        obj1.Add("123");
        obj1.Add("abcd");
        obj1.Add("anonim");
        a = obj1;
        for (int i = 0; i < obj1.Collection.Count; i++)
        {
            a.View(i);
        }

        Stack<int> st1 = new Stack<int>();
        st1.Add(1);
        st1.Add(2);
        st1.Add(3);
        st1.Remove(1);
        for (int i = 0; i < st1.list.Count; i++)
        {
            st1.View(i);
        }

        Stack<double> st2 = new Stack<double>();
        st2.Add(1.5);
        st2.Add(2.3);
        st2.Add(3.1);
        st2.Add(-5.51);
        st2.Remove(1);
        for (int i = 0; i < st2.list.Count; i++)
        {
            st2.View(i);
        }

        Console.WriteLine("\n\n\n");
        CollectionType<Rectangle> obj2 = new CollectionType<Rectangle>();
        obj2.Add(new Button(2, 1, 5, 5, "black", "normal", "New game"));
        obj2.Add(new Button(2, 2, 5, 5, "white", "normal", "Options"));
        obj2.Add(new Button(2, 3, 5, 5, "redgreen", "normal", "Exit"));
        obj2.Add(new Rectangle(3, 5, 10, 20));
        obj2.Add(new Menu(6, 3, 50, 25, "rainbow", "bold", new List<Button>() {new Button(), new Button() }, 2));
        for (int i = 0; i < obj2.Collection.Count; i++)
        {
            obj2.View(i);
        }
        obj2.SaveInFile();
        Console.WriteLine("\n\n\n----Read:");
        LoadFromFile(ref obj2);
    }
}
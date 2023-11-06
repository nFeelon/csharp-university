using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Program
{
    static void Main(string[] args)
    {
        //1 задание

        FurnitureCollection fc = new FurnitureCollection();
        fc.Add(new Furniture("Стол", "Дерево", 5000));
        fc.Add(new Furniture("Стул", "Пластик", 1000));
        fc.Add(new Furniture("Диван", "Кожа", 15000));
        fc.Add(new Furniture("Шкаф", "Металл", 8000));
        Console.WriteLine("Содержимое коллекции:");
        foreach (Furniture f in fc)
        {
            f.PrintInfo();
        }
        fc.RemoveAt(1);
        fc.Remove(new Furniture("Диван", "Кожа", 15000));
        Console.WriteLine("Содержимое коллекции после удаления:");
        foreach (Furniture f in fc)
        {
            f.PrintInfo();
        }
        Furniture item = new Furniture("Шкаф", "Металл", 8000);
        if (fc.Contains(item))
        {
            Console.WriteLine("Коллекция содержит элемент:");
            item.PrintInfo();
        }
        else
        {
            Console.WriteLine("Коллекция не содержит элемент:");
            item.PrintInfo();
        }
        fc.Insert(1, new Furniture("Кресло", "Ткань", 3000));
        Console.WriteLine("Содержимое коллекции после вставки:");
        foreach (Furniture f in fc)
        {
            f.PrintInfo();
        }

        //2 задание

        ConcurrentBag<int> nums = new ConcurrentBag<int>();             
        for (int i = 0; i < 20; i++) nums.Add(i);
        Console.WriteLine("\nЭлементы первой коллекции до изменения:");
        foreach (int a in nums)
            Console.WriteLine(a);
        int n;
        for (int i = 0; i < 4; i++)
        {
            nums.TryTake(out n); 
            Console.WriteLine(n);
        }
        Console.WriteLine("\nЭлементы первой коллекции после изменения:");
        foreach (int a in nums)
            Console.WriteLine(a);
        List<int> nums2 = new List<int>();
        while (!nums.IsEmpty)
        {
            if (nums.TryTake(out n))
            {
                nums2.Add(n);
            }
        }

        Console.WriteLine("\nЭлементы второй коллекции:");
        foreach (int a in nums2)
            Console.WriteLine(a);
        if (nums2.Contains(11)) Console.WriteLine("\nnums2 содержит '11'");
        else Console.WriteLine("\nnums2 не содержит '11'");

        //3 задание

        ObservableCollection<FurnitureCollection> MyCollection = new ObservableCollection<FurnitureCollection>();

        MyCollection.CollectionChanged += MyCollection_onChange;

        MyCollection.Add(fc);
        MyCollection.RemoveAt(0);

    }
    private static void MyCollection_onChange(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine("Добавлен элемент в коллекцию MyCollection");
                break;
            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine("Удалён элемент в коллекцию MyCollection");
                break;
            case NotifyCollectionChangedAction.Replace:
                Console.WriteLine("Изменен элемент в коллекцию MyCollection");
                break;
        }
    }
}
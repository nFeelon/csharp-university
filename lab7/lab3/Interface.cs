using System;
using System.Net.Http.Headers;

public interface IOperations<T>
{
    void Add(T item);
    void Remove(T item);
    T View(int index);
}

partial class CollectionType<T> : String, IOperations<T> where T : class
{
    private List<T> collection;

    public CollectionType()
    {
        collection = new List<T>();
    }

    public CollectionType(string value, List<T> collection) : base(value)
    {
        this.collection = collection;
    }

    public List<T> Collection
    {
        get { return collection; }
        set { collection = value; }
    }

    public void Add(T item)
    {
        try
        {
            collection.Add(item);
            Console.WriteLine("Successfull add.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Add method is complete.");
        }

    }

    public void Remove(T item) { 
        try
        {
            collection.Remove(item);
            Console.WriteLine("Successfull remove.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: "+ e.Message);
        }
        finally
        {
            Console.WriteLine("Remove method is complete.");
        }
    }

    public T View(int index)
    {
        try
        {
            Console.WriteLine("Elem {0} in collection: {1}", index, collection[index]);
            return collection[index];
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return null;
        }
        finally
        {
            Console.WriteLine("View method is complete");
        }
    }

    public T Find(Predicate<T> predicate)
    {
        try
        {
            T result = collection.Find(predicate);
            Console.WriteLine("Elem was found by predicate: {0}", result);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: "+e.Message);
            return null;
        }
        finally
        {
            Console.WriteLine("Find method is complete");
        }
    }
}

class Stack<T> : IOperations<T>
{
    public List<T> list = new List<T>();
    public void Add(T item)
    {
        list.Add(item);
    }
    public void Remove(T item)
    {
        list.Remove(item);
    }
    public T View(int index)
    {
        Console.WriteLine(
            "Elem {0} in collection: {1}", index, list[index]);
        return list[index];
    }
}
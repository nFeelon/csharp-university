using System;
using System.Collections;
using System.Collections.Generic;

public class Furniture
{
    public string Name { get; set; }
    public string Material { get; set; }
    public double Price { get; set; }

    public Furniture(string name, string material, double price)
    {
        Name = name;
        Material = material;
        Price = price;
    }

    public void PrintInfo() => Console.WriteLine("Название: {0}, Материал: {1}, Цена: {2}", Name, Material, Price);
}

public class FurnitureCollection : IList<Furniture>
{
    private ArrayList _list;

    public FurnitureCollection() => _list = new ArrayList();
    public int Count
    {
        get { return _list.Count; }
    }
    public bool IsReadOnly
    {
        get { return _list.IsReadOnly; }
    }
    public Furniture this[int index]
    {
        get { return (Furniture)_list[index]; }
        set { _list[index] = value; }
    }

    public void Add(Furniture item) => _list.Add(item);
    public void Clear() => _list.Clear();
    public bool Contains(Furniture item) => _list.Contains(item);
    public void CopyTo(Furniture[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
    public IEnumerator<Furniture> GetEnumerator() => new FurnitureEnumerator(_list);
    public int IndexOf(Furniture item) => _list.IndexOf(item);
    public void Insert(int index, Furniture item) => _list.Insert(index, item);
    public bool Remove(Furniture item)
    {
        if (_list.Contains(item))
        {
            _list.Remove(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveAt(int index) => _list.RemoveAt(index);
    IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    private class FurnitureEnumerator : IEnumerator<Furniture>
    {
        private ArrayList _list;
        private int _index;
        public FurnitureEnumerator(ArrayList list)
        {
            _list = list;
            _index = -1;
        }
        public Furniture Current
        {
            get { return (Furniture)_list[_index]; }
        }
        object IEnumerator.Current
        {
            get { return _list[_index]; }
        }
        public void Dispose() { }
        public bool MoveNext()
        {
            _index++;
            return (_index < _list.Count);
        }

        public void Reset() => _index = -1;
    }
}
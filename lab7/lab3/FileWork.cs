using System;

partial class Program
{
    public static void LoadFromFile(ref CollectionType<Rectangle> objCollection)
    {
        string text = "";
        using (StreamReader sr = new StreamReader(@"..\..\..\file.txt"))
        {
            while (!sr.EndOfStream)
            {
                text = text+"\n"+sr.ReadLine();
            }
            Console.WriteLine(text);
            sr.Close();
        }
    }
}

partial class CollectionType<T>
{
    public void SaveInFile()
    {
        using (StreamWriter sw = new StreamWriter(@"..\..\..\file.txt", false))
        {
            for(int i = 0; i< Collection.Count; i++)
            {
                sw.WriteLine(Collection[i]);
            }
            sw.Close();
        }
    }
}

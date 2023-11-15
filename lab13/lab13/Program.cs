using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
#pragma warning disable SYSLIB0011

class Program
{
    static void Main(string[] args)
    {
        Button button = new Button(10, 20, "red", 100, 50, "Button", "This is a button!", "OK", "Submit");

        BinarySerializer ourClass = new BinarySerializer();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("button.dat", FileMode.OpenOrCreate))
        {
            ourClass.Serialize(fs, button);
        }
        using (FileStream fs = new FileStream("button.dat", FileMode.Open))
        {
            Button buttonBinary = (Button)binaryFormatter.Deserialize(fs);
            Console.WriteLine($"Бинарный формат: {buttonBinary.Text}, {buttonBinary.Action}");
        }

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        using (FileStream fs = new FileStream("button.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.SerializeAsync(fs, button, jsonOptions);
        }
        using (FileStream fs = new FileStream("button.json", FileMode.Open))
        {
            Button buttonJson = JsonSerializer.DeserializeAsync<Button>(fs).Result;
            Console.WriteLine($"Формат JSON: {buttonJson.Text}, {buttonJson.Action}");
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Button));
        using (FileStream fs = new FileStream("button.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, button);
        }
        using (FileStream fs = new FileStream("button.xml", FileMode.Open))
        {
            Button buttonXml = (Button)xmlSerializer.Deserialize(fs);
            Console.WriteLine($"Формат XML: {buttonXml.Text}, {buttonXml.Action}");
        }

        Rectangle rect = new Rectangle(10, 20, "red", 100, 50, "MyRect", "This is a rectangle");
        using (FileStream fs = new FileStream("rect.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.SerializeAsync(fs, rect, jsonOptions);
        }
        using (FileStream fs = new FileStream("rect.json", FileMode.Open))
        {
            Rectangle rectJson = JsonSerializer.DeserializeAsync<Rectangle>(fs).Result;
            Console.WriteLine($"Формат JSON: {rectJson.Color}, {rectJson.Description}");
        }

        List<Rectangle> rectList = new List<Rectangle>();
        rectList.Add(new Rectangle(15, 30, "red", 10, 100, "Rect1", "good rect"));
        rectList.Add(new Rectangle(10, 20, "red", 60, 100, "Rect2", "good rect"));
        rectList.Add(new Rectangle(5, 30, "red", 75, 150, "Rect3", "good rect"));
        rectList.Add(new Rectangle(6, 11, "red", 50, 200, "Rect4", "good rect"));
        using (FileStream fs = new FileStream("rectangles.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.SerializeAsync(fs, rectList, jsonOptions);
        }
        using (FileStream fs = new FileStream("rectangles.json", FileMode.Open))
        {
            List<Rectangle> rectanglesJson = JsonSerializer.DeserializeAsync<List<Rectangle>>(fs).Result;
            foreach (var rect1 in rectanglesJson)
            {
                Console.WriteLine($"X: {rect1.X}, Y: {rect1.Y}, Color: {rect1.Color}, Width: {rect1.Width}, Height: {rect1.Height}");
            }
        }

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("people.xml");
        XmlElement? xRoot = xDoc.DocumentElement;
        XmlNodeList? personNodes = xRoot?.SelectNodes("person");
        if (personNodes is not null)
        {
            foreach (XmlNode node in personNodes)
                Console.WriteLine(node.SelectSingleNode("@name")?.Value);
        }
        XDocument xdoc1 = XDocument.Load("people.xml");

        XElement root = xdoc1.Element("people");
        var names = from person in root.Elements("person")
                    select person.Attribute("name").Value;
        Console.WriteLine("Имена всех людей:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        var averages = from person in root.Elements("person")
                       select new
                       {
                           Name = person.Attribute("name").Value,
                           Average = person.Elements("age").Average(g => (int)g)
                       };
        Console.WriteLine("Возраст людей:");
        foreach (var item in averages)
        {
            Console.WriteLine($"{item.Name}: {item.Average}");
        }
    }
}

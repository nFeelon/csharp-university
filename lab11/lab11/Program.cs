using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string className = "TestClass";
        string parameterType = "System.Int32";
        string fileName = "output.json";

        Console.WriteLine("\nИмя класса: " + className);
        Console.WriteLine("Тип параметра: " + parameterType);
        Console.WriteLine("Имя файла: " + fileName);

        Console.WriteLine("\nИмя сборки: " + Reflector.GetAssemblyName(className));
        Console.WriteLine("Есть ли конструкторы?: " + Reflector.HasPublicConstructors(className));
        Console.WriteLine("Публичные методы: " + string.Join(", ", Reflector.GetPublicMethods(className)));
        Console.WriteLine("Поля и свойства: " + string.Join(", ", Reflector.GetFieldsAndProperties(className)));
        Console.WriteLine("Интерфейсы: " + string.Join(", ", Reflector.GetInterfaces(className)));
        Console.WriteLine("Методы с типом параметра: " + string.Join(", ", Reflector.GetMethodsByParameterType(className, parameterType)));

        object obj = Activator.CreateInstance(Type.GetType(className), 1);

        object[] parameters = new object[] { 5 };
        Console.WriteLine("Вызов метод класса со сгенерированными параметрами: " + Reflector.Invoke(obj, "MultiplyNumber", parameters));

        Reflector.WriteToFile(fileName, new
        {
            AssemblyName = Reflector.GetAssemblyName(className),
            HasPublicConstructors = Reflector.HasPublicConstructors(className),
            PublicMethods = Reflector.GetPublicMethods(className),
            FieldsAndProperties = Reflector.GetFieldsAndProperties(className),
            Interfaces = Reflector.GetInterfaces(className),
            MethodsByParameterType = Reflector.GetMethodsByParameterType(className, parameterType)
        });


        Console.WriteLine("\n\n--------------------------------------------------\n");
        string className2 = "Time";
        Console.WriteLine("\nИмя класса: " + className2);
        Console.WriteLine("Тип параметра: " + parameterType);

        Console.WriteLine("\nИмя сборки: " + Reflector.GetAssemblyName(className2));
        Console.WriteLine("Есть ли конструкторы?: " + Reflector.HasPublicConstructors(className2));
        Console.WriteLine("Публичные методы: " + string.Join(", ", Reflector.GetPublicMethods(className2)));
        Console.WriteLine("Поля и свойства: " + string.Join(", ", Reflector.GetFieldsAndProperties(className2)));
        Console.WriteLine("Интерфейсы: " + string.Join(", ", Reflector.GetInterfaces(className2)));
        Console.WriteLine("Методы с типом параметра: " + string.Join(", ", Reflector.GetMethodsByParameterType(className2, parameterType)));

        object obj2 = Activator.CreateInstance(Type.GetType(className2), 20,30,0);

        object[] parameters2 = new object[] { 5 };
        Console.WriteLine("Вызов метод класса со сгенерированными параметрами: " + Reflector.Invoke(obj2, "Timers", parameters2));

        Console.WriteLine("\n\n--------------------------------------------------\n");
        string className3 = "System.String";
        Console.WriteLine("\nИмя класса: " + className3);
        Console.WriteLine("Тип параметра: " + parameterType);

        Console.WriteLine("\nИмя сборки: " + Reflector.GetAssemblyName(className3));
        Console.WriteLine("Есть ли конструкторы?: " + Reflector.HasPublicConstructors(className3));
        Console.WriteLine("Публичные методы: " + string.Join(", ", Reflector.GetPublicMethods(className3)));
        Console.WriteLine("Поля и свойства: " + string.Join(", ", Reflector.GetFieldsAndProperties(className3)));
        Console.WriteLine("Интерфейсы: " + string.Join(", ", Reflector.GetInterfaces(className3)));
        Console.WriteLine("Методы с типом параметра: " + string.Join(", ", Reflector.GetMethodsByParameterType(className3, parameterType)));
        
        TestClass date = Reflector.Create<TestClass>(666);
        Console.WriteLine(date);
    }
}
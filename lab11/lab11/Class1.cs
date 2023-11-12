using System.Reflection;
using System.Text.Json;

static class Reflector
{
   public static string GetAssemblyName(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        return type.Assembly.FullName;
    }

    public static bool HasPublicConstructors(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        return type.GetConstructors().Length > 0;
    }

    public static IEnumerable<string> GetPublicMethods(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        return type.GetMethods().Select(m => m.Name);
    }

    public static IEnumerable<string> GetFieldsAndProperties(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        return type.GetFields().Select(f=>f.Name).Concat(type.GetProperties().Select(p=>p.Name));
    }

    public static IEnumerable<string> GetInterfaces(string className)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        return type.GetInterfaces().Select(i=>i.Name);
    }

    public static IEnumerable<string> GetMethodsByParameterType(string className, string parameterType)
    {
        Type type = Type.GetType(className);
        if (type == null)
            throw new ArgumentException("Неправильное имя класса!");
        Type paramType = Type.GetType(parameterType);
        if (paramType == null)
            throw new ArgumentException("Указан неверный тип параметра!");
        return type.GetMethods().Where(m=>m.GetParameters().Any(p=>p.ParameterType == paramType)).Select(m=>m.Name);
    }

    public static object Invoke(object obj, string methodName, object[] parameters)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);
        if (method == null)
            throw new ArgumentException("Invalid method name.");
        ParameterInfo[] paramInfos = method.GetParameters();
        if (parameters == null || parameters.Length != paramInfos.Length)
            throw new ArgumentException("Invalid number of parameters.");
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i] == null)
            {
                parameters[i] = GenerateValue(paramInfos[i].ParameterType);
            }
            else
            {
                parameters[i] = Convert.ChangeType(parameters[i], paramInfos[i].ParameterType);
            }
        }
        return method.Invoke(obj, parameters);
    }
    private static object GenerateValue(Type type)
    {
        Random random = new Random();
        if (type == typeof(int))
            return random.Next();
        else if (type == typeof(double))
            return random.NextDouble();
        else if (type == typeof(bool))
            return random.Next(2) == 0;
        else if (type == typeof(string))
            return Guid.NewGuid().ToString();
        else if (type == typeof(char))
            return (char)random.Next(32, 127);
        else if (type.IsEnum)
        {
            Array values = Enum.GetValues(type);
            return values.GetValue(random.Next(values.Length));
        }
        else
            return Activator.CreateInstance(type);
    }
    public static void WriteToFile(string fileName, object data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }

    public static T Create<T>(params object[] args) where T : class
    {
        Type type = typeof(T);
        ConstructorInfo constructor = type.GetConstructor(args.Select(a => a.GetType()).ToArray());
        if (constructor == null)
        {
            throw new ArgumentException("Не найдено подходящего конструктора!");
        }
        return (T)constructor.Invoke(args);
    }
}
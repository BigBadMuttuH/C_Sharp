using System.Reflection;
using System.Text;

namespace _007_Reflection;

public static class HomeWork
{
    public static void Hw01()
    {
        var o1 = Activator.CreateInstance(typeof(TestClass), 1, "AAAA", 1.5M, new[] { 'A', 'B' });
        var str = ObjectToString(o1);
        Console.WriteLine(str);

        var o2 = StringToObject(str);
        // Проверка типа объекта
        Console.WriteLine($"Тип объекта o2: {o2.GetType()}");

        // Вывод свойств объекта
        foreach (var prop in o2.GetType()
                     .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            Console.WriteLine($"{prop.Name} = {prop.GetValue(o2)}");

        // Сравнение свойств o1 и o2
        // Предполагается, что o1 и o2 принадлежат к одному и тому же типу
        // foreach (var prop in o1.GetType().GetProperties())
        // {
        //     var o1Value = prop.GetValue(o1);
        //     var o2Value = prop.GetValue(o2);
        //     Console.WriteLine($"{prop.Name} is equal: {Equals(o1Value, o2Value)}");
        // }
    }

    // Создать два метода, использующих рефлексию
    // StringToObjects(string s) - Сохраняет информацию в строку
    private static object StringToObject(string str)
    {
        var lines = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var typeName = lines[0].Split(':')[1].Trim();
        var type = Type.GetType(typeName, true);
        var obj = Activator.CreateInstance(type);

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(new[] { ':' }, 2);
            if (parts.Length < 2) continue;

            var name = parts[0].Trim();
            var value = parts[1].Trim();

            // Поиск свойств или полей с использованием атрибута CustomName
            var prop = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.Name == name || p.GetCustomAttribute<CustomNameAttribute>()?.Name == name);

            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == name || f.GetCustomAttribute<CustomNameAttribute>()?.Name == name);

            if (prop != null && prop.CanWrite)
            {
                SetPropertyValue(obj, prop, value);
                continue;
            }

            if (field != null) SetFieldValue(obj, field, value);
        }

        return obj;
    }

    private static void SetPropertyValue(object obj, PropertyInfo property, string value)
    {
        if (property.PropertyType == typeof(char[]))
            property.SetValue(obj, value.ToCharArray());
        else
            property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
    }

    private static void SetFieldValue(object obj, FieldInfo field, string value)
    {
        if (field.FieldType == typeof(char[]))
            field.SetValue(obj, value.ToCharArray());
        else
            field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
    }


    // ObjectToString(object o) - Восстанавливает класс из строки с информацией о методе
    private static string ObjectToString(object obj)
    {
        if (obj == null) return string.Empty;

        var type = obj.GetType();
        var sb = new StringBuilder();
        sb.AppendLine($"Type:{type.FullName}");

        // Обработка свойств
        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            var customNameAttr = prop.GetCustomAttribute<CustomNameAttribute>();
            var name = customNameAttr != null ? customNameAttr.Name : prop.Name;
            var value = prop.GetValue(obj);
            sb.AppendLine($"{name}:{value}");
        }

        // Обработка полей
        foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
        {
            var customNameAttr = field.GetCustomAttribute<CustomNameAttribute>();
            var name = customNameAttr != null ? customNameAttr.Name : field.Name;
            var value = field.GetValue(obj);
            sb.AppendLine($"{name}:{value}");
        }

        return sb.ToString();
    }
}
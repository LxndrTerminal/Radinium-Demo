using System;
using System.Reflection;

public class PropChecker
{

public static void DumpProperties(object obj)
{
    if (obj == null) { Console.WriteLine("null"); return; }
    var type = obj.GetType();
    Console.WriteLine($"Type: {type.FullName}");
    foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
        object? value;
        try { value = prop.GetValue(obj); }
        catch (Exception ex) { value = $"<exception: {ex.Message}>"; }
        Console.WriteLine($"{prop.Name}: {value}");
    }
}
}

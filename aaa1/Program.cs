using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main()
    {
        // Создание объекта для сериализации
        var myObject = new MyClass { Name = "John", Age = 30 };

        // Сериализация объекта в JSON
        string json = JsonSerializer.Serialize(myObject);

        Console.WriteLine(json);
    }
}

class MyClass
{
    public string Name { get; set; }
    public int Age { get; set; }
}
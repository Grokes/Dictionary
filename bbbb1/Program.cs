using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Создать словарь");
            Console.WriteLine("2. Открыть словарь");
            Console.WriteLine("3. Удалить словарь");
            Console.WriteLine("4. Просмотреть список словарей");
            Console.WriteLine("5. Выход");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Console.WriteLine("Введите название словаря:");
                    var name = Console.ReadLine();
                    var dictionary = new Dictionary<string, string>();
                    SaveDictionary(name, dictionary);
                    break;
                case "2":
                    Console.WriteLine("Введите название словаря:");
                    name = Console.ReadLine();
                    dictionary = LoadDictionary(name);
                    if (dictionary == null)
                    {
                        Console.WriteLine("Такого словаря не существует!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ваши слова:");
                        foreach (var pair in dictionary)
                        {
                            Console.WriteLine($"{pair.Key} - {pair.Value}");
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Введите название словаря:");
                    name = Console.ReadLine();
                    File.Delete($"{name}.json");
                    break;
                case "4":
                    var files = Directory.GetFiles(".", "*.json");
                    foreach (var file in files)
                    {
                        Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                    }
                    break;
                case "5":
                    return;
            }
        }
    }

    private static Dictionary<string, string> LoadDictionary(string name)
    {
        var json = File.ReadAllText($"{name}.json");
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
    }

    private static void SaveDictionary(string name, Dictionary<string, string> dictionary)
    {
        var json = JsonSerializer.Serialize(dictionary);
        File.WriteAllText($"{name}.json", json);
    }
}

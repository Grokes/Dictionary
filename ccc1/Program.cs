using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class DictionaryContent
{
    public string Word { get; set; }
    public string Translation { get; set; }
}

class Dictionary
{
    public string Name { get; set; }
    public List<DictionaryContent> Contents { get; set; } = new List<DictionaryContent>();
}

class Program
{
    private static string dictionariesFilePath = "dictionaries.json";
    private static List<Dictionary> dictionaries = new List<Dictionary>();

    static void Main(string[] args)
    {
        // Загрузка словарей при запуске
        LoadDictionaries();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Меню ===\n");
            Console.WriteLine("1. Создать словарь");
            Console.WriteLine("2. Открыть словарь");
            Console.WriteLine("3. Удалить словарь");
            Console.WriteLine("4. Просмотреть список словарей");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateDictionary();
                    break;
                case "2":
                    OpenDictionary();
                    break;
                case "3":
                    DeleteDictionary();
                    break;
                case "4":
                    ViewDictionaries();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }

            //Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения:");
            Console.ReadKey();
        }
    }

    static void CreateDictionary()
    {
        Console.Write("Введите название словаря: ");
        string name = Console.ReadLine();

        if (dictionaries.Exists(n => n.Name == name))
        {
            Console.WriteLine("Словарь с таким названием уже существует.");
            return;
        }

        Dictionary newDictionary = new Dictionary { Name = name };
        dictionaries.Add(newDictionary);
        SaveDictionaries();

        Console.WriteLine($"Словарь '{name}' успешно создан.");
    }

    static void OpenDictionary()
    {
        Console.Write("Введите название словаря: ");
        string name = Console.ReadLine();

        Dictionary dictionary = dictionaries.Find(n => n.Name == name);
        if (dictionary == null)
        {
            Console.WriteLine("Словарь не найден.");
            return;
        }

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Словарь: {dictionary.Name}");
            Console.WriteLine("=== Меню словаря ===");
            Console.WriteLine("1. Просмотреть все слова");
            Console.WriteLine("2. Добавить слово");
            Console.WriteLine("3. Вернуться в главное меню");
            Console.Write("Выберите действие (1-3): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ViewDictionaryContains(dictionary);
                    break;
                case "2":
                    AddDictionaryContains(dictionary);
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
            //Console.WriteLine(); Работает, и слава богу...
            Console.WriteLine("Нажмите любую клавишу для продолжения:");
            Console.ReadKey();
        }
    }

    static void DeleteDictionary()
    {
        Console.Write("Введите название словаря для удаления: ");
        string name = Console.ReadLine();

        Dictionary dictionary = dictionaries.Find(n => n.Name == name);
        if (dictionary == null)
        {
            Console.WriteLine("Словарь не найден.");
            return;
        }

        dictionaries.Remove(dictionary);
        SaveDictionaries();

        Console.WriteLine($"Словарь '{name}' успешно удален.");
    }

    static void ViewDictionaries()
    {
        if (dictionaries.Count > 0)
        {
            Console.WriteLine("Список словарей:");
            foreach (var dictionary in dictionaries)
            {
                Console.WriteLine(dictionary.Name);
            }
        }
        else
        {
            Console.WriteLine("Нет доступных словарей.");
        }
    }

    static void ViewDictionaryContains(Dictionary dictionary)
    {
        Console.WriteLine($"Слова в словаре '{dictionary.Name}':");

        if (dictionary.Contents.Count > 0)
        {
            foreach (var contain in dictionary.Contents)
            {
                Console.WriteLine($"{contain.Word} - {contain.Translation}");
            }
        }
        else
        {
            Console.WriteLine("Словарь пуст.");
        }
    }

    static void AddDictionaryContains(Dictionary dictionary)
    {
        Console.Write("Введите слово: ");
        string word = Console.ReadLine();

        Console.Write("Введите перевод: ");
        string translation = Console.ReadLine();

        DictionaryContent content = new DictionaryContent
        {
            Word = word,
            Translation = translation
        };

        dictionary.Contents.Add(content);
        SaveDictionaries();

        Console.WriteLine("Слово успешно добавлено в словарь.");
    }

    static void LoadDictionaries()
    {
        if (File.Exists(dictionariesFilePath))
        {
            string json = File.ReadAllText(dictionariesFilePath);
            dictionaries = JsonConvert.DeserializeObject<List<Dictionary>>(json);
        }
    }

    static void SaveDictionaries()
    {
        string json = JsonConvert.SerializeObject(dictionaries, Formatting.Indented);
        File.WriteAllText(dictionariesFilePath, json);
    }
}

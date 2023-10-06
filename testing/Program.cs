//using System;

//public class MyIntArray
//{
//    public string Word { get; set; }
//    public string Translation { get; set; }
//    private int[] array { get; set; };
//    private int size ;

//    public MyIntArray(int length = 5)
//    {
//        array = new int[length];
//        size = 0;
//    }

//    public void Add(int value)
//    {
//        if (size == array.Length)
//        {
//            Array.Resize(ref array, array.Length * 2);
//        }

//        array[size] = value;
//        size++;
//    }

//    public void Remove(int index)
//    {
//        if (index < 0 || index >= size)
//        {
//            throw new IndexOutOfRangeException("Index is out of range");
//        }

//        for (int i = index; i < size - 1; i++)
//        {
//            array[i] = array[i + 1];
//        }

//        size--;
//    }

//    public void SortRight()
//    {
//        Array.Sort(array, 0, size);
//    }

//    public void SortLeft()
//    {
//        Array.Sort(array, 0, size);
//        Array.Reverse(array, 0, size);
//    }

//    public int Size()
//    {
//        return size;
//    }

//    public override string ToString()
//    {
//        string result = "[";
//        for (int i = 0; i < size; i++)
//        {
//            result += array[i];
//            if (i < size - 1)
//            {
//                result += ", ";
//            }
//        }
//        result += "]";
//        return result;
//    }

//    public static void Remove(int[] array, int index)
//    {
//        if (index < 0 || index >= array.Length)
//        {
//            throw new IndexOutOfRangeException("Index is out of range");
//        }

//        for (int i = index; i < array.Length - 1; i++)
//        {
//            array[i] = array[i + 1];
//        }
//    }

//    public static void SortRight(int[] array)
//    {
//        Array.Sort(array);
//    }

//    public static void SortLeft(int[] array)
//    {
//        Array.Sort(array);
//        Array.Reverse(array);
//    }

//    public static void Print(int[] array)
//    {
//        Console.Write("[");
//        for (int i = 0; i < array.Length; i++)
//        {
//            Console.Write(array[i]);
//            if (i < array.Length - 1)
//            {
//                Console.Write(", ");
//            }
//        }
//        Console.WriteLine("]");
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        MyIntArray myArray = new MyIntArray();
//        myArray.Add(5);
//        myArray.Add(3);
//        myArray.Add(8);
//        Console.WriteLine(myArray.ToString()); // [5, 3, 8]

//        MyIntArray.SortRight(myArray.array);
//        Console.WriteLine(myArray.ToString()); // [3, 5, 8]

//        MyIntArray.SortLeft(myArray.array);
//        Console.WriteLine(myArray.ToString()); // [8, 5, 3]

//        MyIntArray.Remove(myArray.array, 1);
//        Console.WriteLine(myArray.ToString()); // [8, 3]

//        MyIntArray.Print(myArray.array); // [8, 3]
//    }
//}


using System;

//1.Задача: Напишите функцию, которая принимает на вход два числа и возвращает их сумму.

//delegate int SumDelegate(int num1, int num2);

//class Program
//{
//    static int Sum(int num1, int num2)
//    {
//        return num1 + num2;
//    }

//    static void Main()
//    {
//        SumDelegate sumDelegate = new SumDelegate(Sum);

//        int num1 = 10;
//        int num2 = 20;

//        int resultsum = sumDelegate(num1, num2);

//        Console.WriteLine($"Сумма чисел {num1} и {num2} равна: {resultsum}");

//        Console.ReadLine();
//    }
//}

//2.Задача: Напишите функцию, которая принимает на вход строку и выводит ее в консоль в верхнем регистре.


//3.Задача: Напишите функцию, которая принимает на вход список чисел и возвращает новый список, состоящий только из четных чисел.

//4. Задача: Напишите функцию, которая принимает на вход список строк и вычисляет общую длину всех строк.

//5. Задача: Напишите функцию, которая принимает на вход список чисел и возвращает среднее арифметическое значение.

//6. Задача: Напишите функцию, которая принимает на вход список строк и возвращает новый список, в котором каждая строка изменена таким образом,
//чтобы первая буква была в верхнем регистре, а остальные - в нижнем.

//7. Задача: Напишите функцию, которая принимает на вход список слов и возвращает новый список,
//содержащий только те слова, которые состоят только из букв верхнего регистра.


//namespace ArrayListLibray
//{
//    public class ArrayList
//    {
//        private int _length { get { return _array.Length; } }
//        private int[] _array;
//        public int Count { get; private set; }

//        public ArrayList()
//        {
//            _array = new int[7];
//            Count = 0;
//        }

//        public ArrayList(int length)
//        {
//            _array = new int[length];
//            Count = 0;
//        }

//        public ArrayList(int[] arr)
//        {
//            int length = (int)(arr.Length * 1.5);
//            _array = new int[length];
//            for (int i = 0; i < arr.Length; i++)
//            {
//                _array[i] = arr[i];
//            }
//            Count = arr.Length;
//        }

//        public int this[int index]
//        {
//            get
//            {
//                if (index > Count - 1)
//                {
//                    throw new Exception($"row 41, по индексу:{index} нет элемента");
//                }
//                return _array[index];
//            }
//            set
//            {
//                if (index > Count - 1)
//                {
//                    throw new IndexOutOfRangeException();
//                }
//                _array[index] = value;
//            }
//        }

//        public void Add(int element)
//        {
//            if (Count >= _array.Length)
//            {
//                Increathlength();
//            }
//            _array[Count++] = element;
//        }

//        private void Increathlength(int countElements = 1)
//        {
//            int newLength = _length;
//            while (newLength <= _length + countElements)
//            {
//                newLength = (int)(newLength * 1.5 + countElements);
//            }
//            int[] newArray = new int[newLength];
//            Array.Copy(_array, newArray, _length); _array = newArray;
//        }

//    }
//}

//Работа с файлами. Задания Повторили ООП. До 5.10

/*1)Напишите функцию для поиска  общего префикса среди массива строк.
Если общего префикса нет, верните пустую строку «».

Пример 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"

Пример 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.*/



//public string FindCommonPrefix(string[] strs)
//{
//    if (strs == null || strs.Length == 0)
//    {
//        return "";
//    }

//    string prefix = strs[0];

//    for (int i = 1; i < strs.Length; i++)
//    {
//        while (!strs[i].StartsWith(prefix))
//        {
//            prefix = prefix.Substring(0, prefix.Length - 1);

//            if (string.IsNullOrEmpty(prefix))
//            {
//                return "";
//            }
//        }
//    }

//    return prefix;
//}


//2)Создайте программу, которая создает новый файл в указанном каталоге. 
//При этом программа должна проверять, существует ли файл с таким именем в указанном каталоге. 
//Если файл существует, программа должна вывести сообщение об ошибке.

//using System;
//using System.IO;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Введите путь к каталогу:");
//        string directoryPath = Console.ReadLine();

//        Console.WriteLine("Введите имя файла:");
//        string fileName = Console.ReadLine();

//        string filePath = Path.Combine(directoryPath, fileName);

//        if (File.Exists(filePath))
//        {
//            Console.WriteLine("Ошибка: Файл с таким именем уже существует.");
//            return;
//        }

//        try
//        {
//            using (File.Create(filePath))
//            {
//                Console.WriteLine("Файл успешно создан.");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
//        }
//    }
//}






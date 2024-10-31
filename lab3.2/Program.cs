using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Пути к файлам
        string binaryFilePath = "randomNumbers.bin";
        string filteredBinaryFilePath = "filteredNumbers.bin";
        string toysFilePath = "toys.bin";
        string textFilePathSingle = "numbersSingle.txt";
        string textFilePathMultiple = "numbersMultiple.txt";
        string resultTextFilePath = "firstCharacters.txt";

        // Задание 4. Создаем и заполняем бинарный файл случайными числами
        Console.WriteLine("Задание 4");
        FileTasks.FillBinaryFileWithRandomData(binaryFilePath, 10, 1, 50);
        Console.WriteLine("Бинарный файл случайных чисел создан.");
        DisplayBinaryFileContent(binaryFilePath);

        // Задание 4. Убираем числа, кратные заданному значению k 
        Console.WriteLine("Введите число k, чтобы удалить из списка числа, кратные ему");
        int k = Convert.ToInt32(Console.ReadLine());
        FileTasks.RemoveMultiplesOfK(binaryFilePath, filteredBinaryFilePath, k);
        Console.WriteLine($"Файл без чисел, кратных {k}, создан.");
        DisplayBinaryFileContent(filteredBinaryFilePath);

        //// Задание 5. Создаем бинарный файл с информацией об игрушках
        Console.WriteLine("Задание 5");

        // Создаем файл с информацией об игрушках
        FileTasks.FillToyBinaryFile(toysFilePath);
        Console.WriteLine("Файл с информацией об игрушках создан.");
        DisplayToyFileContent(toysFilePath);

        // Поиск подходящих игрушек для ребенка 3 лет
        var suitableToys = FileTasks.FindToyForThreeYearOld(toysFilePath);

        if (suitableToys.Count > 0)
        {
            Console.WriteLine("Найдены игрушки, подходящие для ребенка 3 лет (кроме мяча):");
            foreach (var toy in suitableToys)
            {
                Console.WriteLine($"Игрушка: {toy.Name}, Цена: {toy.Price} руб., Возраст: {toy.MinAge}-{toy.MaxAge} лет");
            }
        }
        else
        {
            Console.WriteLine("Игрушка, подходящая для ребенка 3 лет, не найдена.");
        }

        // Задание 6. Создаем текстовый файл с числами по одному в строке
        Console.WriteLine("Задание 6");
        FileTasks.FillTextFileWithRandomIntegers(textFilePathSingle, 10, 1, 50);
        Console.WriteLine("Текстовый файл с числами по одному в строке создан.");
        DisplayTextFileContent(textFilePathSingle);

        // Задание 6. Находим сумму максимального и минимального элементов в файле
        int sumMaxMin = FileTasks.SumMaxAndMinInTextFile(textFilePathSingle);
        Console.WriteLine($"Сумма максимального и минимального элементов: {sumMaxMin}");

        // Задание 7. Создаем текстовый файл с числами в нескольких строках
        Console.WriteLine("Задание 7");
        FileTasks.FillTextFileWithMultipleNumbersInLine(textFilePathMultiple, 5, 3, 1, 50);
        Console.WriteLine("Текстовый файл с несколькими числами в строке создан.");
        DisplayTextFileContent(textFilePathMultiple);

        // Задание 7. Вычисляем сумму четных чисел в файле
        int sumEvenNumbers = FileTasks.SumEvenNumbersInTextFile(textFilePathMultiple);
        Console.WriteLine($"Сумма четных элементов: {sumEvenNumbers}");

        // Задание 8. Создаем новый текстовый файл с первыми символами строк исходного файла
        Console.WriteLine("Задание 8");
        FileTasks.WriteFirstCharacterOfEachLine(textFilePathSingle, resultTextFilePath);
        Console.WriteLine("Файл с первыми символами строк исходного файла создан.");
        DisplayTextFileContent(resultTextFilePath);
    }

    // Метод для вывода содержимого бинарного файла
    private static void DisplayBinaryFileContent(string filePath)
    {
        Console.WriteLine($"Содержимое файла {filePath}:");
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            List<int> numbers = new List<int>();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                numbers.Add(reader.ReadInt32());
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
        Console.WriteLine();
    }

    // Метод для вывода содержимого файла с данными об игрушках
    private static void DisplayToyFileContent(string filePath)
    {
        Console.WriteLine($"Содержимое файла {filePath}:");
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string name = reader.ReadString();
                int price = reader.ReadInt32();
                int minAge = reader.ReadInt32();
                int maxAge = reader.ReadInt32();
                Console.WriteLine($"Игрушка: {name}, Цена: {price} руб., Возраст: {minAge}-{maxAge} лет");
            }
        }
        Console.WriteLine();
    }

    // Метод для вывода содержимого текстового файла
    private static void DisplayTextFileContent(string filePath)
    {
        Console.WriteLine($"Содержимое файла {filePath}:");
        foreach (string line in File.ReadLines(filePath))
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class FileTasks
{
    // Задание 4. Создание и заполнение бинарного файла случайными данными
    public static void FillBinaryFileWithRandomData(string filePath, int count, int minValue, int maxValue)
    {
        var random = new Random();
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(random.Next(minValue, maxValue));
            }
        }
    }

    // Задание 4. Создание файла без чисел, кратных k
    public static void RemoveMultiplesOfK(string sourceFilePath, string targetFilePath, int k)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(sourceFilePath, FileMode.Open)))
        using (BinaryWriter writer = new BinaryWriter(File.Open(targetFilePath, FileMode.Create)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (number % k != 0)
                {
                    writer.Write(number);
                }
            }
        }
    }

    //Задание 5. Создание бинарного файла с записями об игрушках
    public static void FillToyBinaryFile(string filePath)
    {
        var toys = new List<(string Name, int Price, int MinAge, int MaxAge)>
        {
            ("Мяч", 100, 2, 5),
            ("Кукла", 200, 3, 6),
            ("Конструктор", 500, 4, 7),
            ("Машинка", 150, 2, 4)
        };

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            foreach (var toy in toys)
            {
                writer.Write(toy.Name);
                writer.Write(toy.Price);
                writer.Write(toy.MinAge);
                writer.Write(toy.MaxAge);
            }
        }
    }


    // Задание 5. Проверка наличия игрушки для ребенка 3 лет
    public static List<(string Name, int Price, int MinAge, int MaxAge)> FindToyForThreeYearOld(string filePath)
    {
        var suitableToys = new List<(string Name, int Price, int MinAge, int MaxAge)>();

        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string name = reader.ReadString();
                int price = reader.ReadInt32();
                int minAge = reader.ReadInt32();
                int maxAge = reader.ReadInt32();

                if (name != "Мяч" && minAge <= 3 && maxAge >= 3)
                {
                    suitableToys.Add((name, price, minAge, maxAge));
                }
            }
        }

        return suitableToys;
    }

    // Задание 6. Создание текстового файла со случайными целыми числами
    public static void FillTextFileWithRandomIntegers(string filePath, int count, int minValue, int maxValue)
    {
        var random = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(random.Next(minValue, maxValue));
            }
        }
    }

    // Задание 6. Нахождение суммы максимального и минимального элементов в текстовом файле
    public static int SumMaxAndMinInTextFile(string filePath)
    {
        var numbers = File.ReadLines(filePath).Select(int.Parse).ToList();
        Console.WriteLine($"Максимальный элемент - {numbers.Max()}");
        Console.WriteLine($"Минимальный элемент - {numbers.Min()}");
        return numbers.Max() + numbers.Min();
    }

    // Задание 7. Создание текстового файла с несколькими числами в строке
    public static void FillTextFileWithMultipleNumbersInLine(string filePath, int rows, int numbersPerRow, int minValue, int maxValue)
    {
        var random = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < rows; i++)
            {
                var line = string.Join(" ", Enumerable.Range(0, numbersPerRow).Select(_ => random.Next(minValue, maxValue)));
                writer.WriteLine(line);
            }
        }
    }

    // Задание 7. Сумма четных элементов в текстовом файле
    public static int SumEvenNumbersInTextFile(string filePath)
    {
        return File.ReadLines(filePath)
                   .SelectMany(line => line.Split(' ').Select(int.Parse))
                   .Where(number => number % 2 == 0)
                   .Sum();
    }

    // Задание 8. Создание текстового файла с первыми символами строк исходного файла
    public static void WriteFirstCharacterOfEachLine(string sourceFilePath, string targetFilePath)
    {
        using (StreamReader reader = new StreamReader(sourceFilePath))
        using (StreamWriter writer = new StreamWriter(targetFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    writer.WriteLine(line[0]);
                }
            }
        }
    }
}

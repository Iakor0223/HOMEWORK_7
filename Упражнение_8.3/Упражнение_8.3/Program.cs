using System;
using System.IO; // подключаем для работы с файлами

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите имя исходного файла (например, input.txt): ");
        string inputFileName = Console.ReadLine();

        // Проверяем, существует ли файл
        if (!File.Exists(inputFileName))
        {
            Console.WriteLine("Ошибка: файл '" + inputFileName + "' не найден. Работа программы завершена.");
            Console.ReadLine();
            return; // Завершаем выполнение метода Main и всей программы
        }

        // Имя файла, в который запишем результат
        string outputFileName = "dz.txt";

        // Читаем весь текст из исходного файла
        string content = File.ReadAllText(inputFileName);

        // Переводим весь текст в верхний регистр
        string upperContent = content.ToUpper();

        // Записываем измененный текст в выходной файл
        File.WriteAllText(outputFileName, upperContent);

        Console.WriteLine("Готово! Содержимое успешно записано заглавными буквами в файл: " + outputFileName);
        
        Console.ReadLine();
    }
}

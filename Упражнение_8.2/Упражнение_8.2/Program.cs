using System;

class Program
{
    // Метод, переворачивающий строку
    public static string ReverseString(string input)
    {
        // Проверка на случай, если передана пустая строка или null
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        // Создаем массив символов такой же длины, как исходная строка
        char[] reversedChars = new char[input.Length];

        // Заполняем массив с конца исходной строки
        for (int i = 0; i < input.Length; i++)
        {
            reversedChars[i] = input[input.Length - 1 - i];
        }

        // Преобразуем массив символов обратно в строку и возвращаем
        return new string(reversedChars);
    }

    static void Main(string[] args)
    {
        // Тест 1: Обычное слово
        string test1 = "Программирование";
        Console.WriteLine("Исходная: " + test1);
        Console.WriteLine("Обратная: " + ReverseString(test1) + "\n");

        // Тест 2: Фраза с пробелами и знаками препинания
        string test2 = "Привет, мир! 123";
        Console.WriteLine("Исходная: " + test2);
        Console.WriteLine("Обратная: " + ReverseString(test2) + "\n");

        // Тест 3: Ввод строки пользователем с клавиатуры
        Console.Write("Введите свою строку для проверки: ");
        string userInput = Console.ReadLine();
        Console.WriteLine("Результат: " + ReverseString(userInput));

        Console.ReadLine();
    }
}

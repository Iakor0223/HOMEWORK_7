using System;
using System.IO;

class Program
{
    public void SearchMail(ref string s)
    {
        if (string.IsNullOrEmpty(s)) return;

        // Разбиваем строку на массив частей по символу '#'
        // parts[0] — это ФИО, parts[1] — это e-mail
        string[] parts = s.Split('#');

        // Проверяем, что строка разделилась на 2 части
        if (parts.Length > 1)
        {
            //убираем пробелы по краям
            s = parts[1].Trim();
        }
        else
        {
            s = string.Empty;
        }
    }

    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "emails.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        Program prog = new Program();
        string[] lines = File.ReadAllLines(inputFile);

        for (int i = 0; i < lines.Length; i++)
        {
            prog.SearchMail(ref lines[i]);
        }

        File.WriteAllLines(outputFile, lines);
        Console.WriteLine("Готово! Адреса записаны в " + outputFile);
    }
}



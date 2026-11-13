using System;
using System.Collections.Generic; // Обязательно для использования List<Song>

class Song
{
    string name;   // название песни
    string author; // автор песни
    Song prev;     // связь с предыдущей песней в списке

    // Метод для заполнения поля name
    public void SetName(string songName)
    {
        name = songName;
    }

    // Метод для заполнения поля author
    public void SetAuthor(string songAuthor)
    {
        author = songAuthor;
    }

    // Метод для заполнения поля prev
    public void SetPrev(Song prevSong)
    {
        prev = prevSong;
    }

    // Метод для печати названия песни и ее исполнителя
    public string Title()
    {
        return name + " — " + author;
    }

    // Метод, который сравнивает между собой два объекта-песни
    public override bool Equals(object d)
    {
        Song otherSong = d as Song;

        // Если передан не объект Song или null, объекты не равны
        if (otherSong == null)
        {
            return false;
        }

        // Песни считаются одинаковыми, если совпадают и название, и автор
        return this.name == otherSong.name && this.author == otherSong.author;
    }
}

class Program
{
    static void Main()
    {
        // Создаем список из четырех песен
        List<Song> playlist = new List<Song>();

        // 1-я песня (предыдущей нет, поэтому prev = null)
        Song song1 = new Song();
        song1.SetName("Mr. Tambourine Man");
        song1.SetAuthor("Bob Dylan");
        song1.SetPrev(null);
        playlist.Add(song1);

        Song song2 = new Song();
        song2.SetName("I Walk The Line");
        song2.SetAuthor("Johnny Cash");
        song2.SetPrev(song1);
        playlist.Add(song2);
     
        Song song3 = new Song();
        song3.SetName("Hallelujah");
        song3.SetAuthor("Leonard Cohen");
        song3.SetPrev(song2);
        playlist.Add(song3);

        Song song4 = new Song();
        song4.SetName("Farewell Angelina");
        song4.SetAuthor("Joan Baez");
        song4.SetPrev(song3);
        playlist.Add(song4);

        // В цикле выводим информацию о каждой песне
        Console.WriteLine("Список песен:");
        foreach (Song s in playlist)
        {
            Console.WriteLine(s.Title());
        }

        // Сравниваем между собой первую и вторую песню в списке
        Console.WriteLine("\nСравнение первой и второй песни:");
        if (playlist[0].Equals(playlist[1]))
        {
            Console.WriteLine("Первая и вторая песни одинаковые.");
        }
        else
        {
            Console.WriteLine("Первая и вторая песни разные.");
        }

        Console.ReadLine();
    }
}


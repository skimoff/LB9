using System.Text;

namespace Task3;

class Program
{
    static Song[] songs = new Song[0];
    const string FilePath = "songs.txt";
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати пісню");
            Console.WriteLine("2. Видалити пісню");
            Console.WriteLine("3. Змінити пісню");
            Console.WriteLine("4. Пошук пісні");
            Console.WriteLine("5. Пошук за виконавцем");
            Console.WriteLine("6. Зберегти у файл");
            Console.WriteLine("7. Завантажити з файлу");
            Console.WriteLine("0. Вийти");
            Console.Write("Ваш вибір: ");

            switch (Console.ReadLine())
            {
                case "1": AddSong(); break;
                case "2": DeleteSong(); break;
                case "3": EditSong(); break;
                case "4": SearchSongs(); break;
                case "5": SearchByPerformer(); break;
                case "6": SaveToFile(); break;
                case "7": LoadFromFile(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }


        static void AddSong()
        {
            Song song = new Song();

            Console.Write("Назва пісні: ");
            song.Title = Console.ReadLine();

            Console.Write("П.І.Б. автора: ");
            song.Author = new Author(Console.ReadLine());

            Console.Write("Композитор: ");
            song.Composer = Console.ReadLine();

            Console.Write("Дата написання (у форматі dd.MM.yyyy): ");
            song.ReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Текст пісні: ");
            song.Lyrics = Console.ReadLine();

            Console.Write("Виконавці (через кому): ");
            song.Performers = Console.ReadLine().Split(',');

            Song[] newSongs = new Song[songs.Length + 1];
            for (int i = 0; i < songs.Length; i++)
                newSongs[i] = songs[i];
            newSongs[songs.Length] = song;
            songs = newSongs;

            Console.WriteLine("Пісню додано.");
        }

        static void DeleteSong()
        {
            Console.Write("Назва пісні для видалення: ");
            string title = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < songs.Length; i++)
            {
                if (songs[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Пісню не знайдено.");
                return;
            }

            Song[] newSongs = new Song[songs.Length - 1];
            for (int i = 0, j = 0; i < songs.Length; i++)
            {
                if (i != index)
                    newSongs[j++] = songs[i];
            }

            songs = newSongs;
            Console.WriteLine("Пісню видалено.");
        }

        static void EditSong()
        {
            Console.Write("Назва пісні для редагування: ");
            string title = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < songs.Length; i++)
            {
                if (songs[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Пісню не знайдено.");
                return;
            }

            Console.Write("Нова назва: ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) songs[index].Title = newTitle;

            Console.Write("Новий композитор: ");
            string newComposer = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newComposer)) songs[index].Composer = newComposer;

            Console.Write("Нова дата (dd.MM.yyyy): ");
            string newDate = Console.ReadLine();
            if (DateTime.TryParse(newDate, out DateTime dt)) songs[index].ReleaseDate = dt;

            Console.Write("Новий текст: ");
            string newLyrics = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLyrics)) songs[index].Lyrics = newLyrics;

            Console.Write("Нові виконавці (через кому): ");
            string newPerformers = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPerformers)) songs[index].Performers = newPerformers.Split(',');

            Console.WriteLine("Пісню оновлено.");
        }

        static void SearchSongs()
        {
            Console.Write("Ключове слово: ");
            string query = Console.ReadLine().ToLower();

            bool found = false;
            foreach (var song in songs)
            {
                if (song.Title.ToLower().Contains(query) ||
                    song.Author.ToString().ToLower().Contains(query) ||
                    song.Composer.ToLower().Contains(query) ||
                    song.Lyrics.ToLower().Contains(query))
                {
                    Console.WriteLine(song);
                    found = true;
                }
            }

            if (!found) Console.WriteLine("Нічого не знайдено.");
        }

        static void SearchByPerformer()
        {
            Console.Write("Виконавець: ");
            string performer = Console.ReadLine().ToLower();

            bool found = false;
            foreach (var song in songs)
            {
                foreach (var p in song.Performers)
                {
                    if (p.ToLower().Contains(performer))
                    {
                        Console.WriteLine(song);
                        found = true;
                        break;
                    }
                }
            }

            if (!found) Console.WriteLine("Нічого не знайдено.");
        }

        static void SaveToFile()
        {
            using StreamWriter writer = new StreamWriter(FilePath);
            foreach (var song in songs)
            {
                writer.WriteLine(song.Title);
                writer.WriteLine(song.Author.AuthorName);
                writer.WriteLine(song.Composer);
                writer.WriteLine(song.ReleaseDate.ToString("dd.MM.yyyy"));
                writer.WriteLine(song.Lyrics);
                writer.WriteLine(string.Join("|", song.Performers));
                writer.WriteLine("---");
            }

            Console.WriteLine("Збережено у текстовий файл.");
        }

        static void LoadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Файл не знайдено. Створено нову колекцію.");
                songs = new Song[0];
                return;
            }

            string[] lines = File.ReadAllLines(FilePath);
            Song[] loaded = new Song[lines.Length / 7];
            int index = 0;

            for (int i = 0; i < lines.Length; i += 7)
            {
                Song song = new Song();
                song.Title = lines[i];
                song.Author = new Author(lines[i + 1]);
                song.Composer = lines[i + 2];
                song.ReleaseDate = DateTime.ParseExact(lines[i + 3], "dd.MM.yyyy", null);
                song.Lyrics = lines[i + 4];
                song.Performers = lines[i + 5].Split('|');
                loaded[index++] = song;
            }

            songs = new Song[index];
            for (int i = 0; i < index; i++) songs[i] = loaded[i];

            Console.WriteLine("Завантажено з текстового файлу.");
        }


        Console.ReadKey();
    }
}
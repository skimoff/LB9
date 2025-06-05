namespace Task3;

public class Song
{
    private string? songTitle;
    private Author author;
    private DateTime date;
    private string? songText;
    private string? composer;
    private string[] performers;


    public Song(string title, Author author, DateTime date, string text, string? composer, string[] performers)
    {
        this.songTitle = title;
        this.author = author;
        this.date = date;
        this.songText = text;
        this.composer = composer;
        this.performers = performers;
    }

    public Song()
    {
        songTitle = "Noname";
        author = new Author();
        date = new DateTime();
        songText = "";
        composer = "Noname";
        performers = new string[0];
    }

    public string? SongTitle
    {
        get => songText;
        set => songText = value;
    }

    public Author Author
    {
        get => author;
        set => author = value;
    }

    public DateTime Date
    {
        get => date;
        set => date = value;
    }

    public string? SongText
    {
        get => songText;
        set => songText = value;
    }

    public string? Composer
    {
        get => composer;
        set => composer = value;
    }

    public string[] Performers
    {
        get => performers;
        set => performers = value;
    }

    public override string ToString()
    {
        return $"Назва: {songTitle}\nАвтор: {Author}\nКомпозитор: {Composer}\nРік: {date}\nТекст: {songText}\nВиконавці: {string.Join(", ", Performers)}\n";
    }
}
namespace Task3;

public class Song
{
    public string Title;
    public Author Author;
    public string Composer;
    public DateTime ReleaseDate;
    public string Lyrics;
    public string[] Performers;

    public override string ToString()
    {
        return $"Назва: {Title}\nАвтор: {Author}\nКомпозитор: {Composer}\nДата: {ReleaseDate.ToShortDateString()}\nТекст: {Lyrics}\nВиконавці: {string.Join(", ", Performers)}\n";
    }
}
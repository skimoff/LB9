namespace Task3;

public class Author
{
    private string? authorName;
    
    public Author(string? authorName)
    {
        this.authorName = authorName;
    }

    public Author()
    {
        authorName = "Noname";
    }

    public string? AuthorName
    {
        get => authorName;
        set => authorName = value;
    }
    

    public override string ToString()
    {
        return $"Name: {authorName}";
    }
}
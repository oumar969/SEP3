namespace Domain.Models;

public class BookRegistry
{
    public BookRegistry(string title, string author, string genre, string isbn, string description,
        string review)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Review = review;
    }

    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Review { get; set; }
}
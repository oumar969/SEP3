namespace Domain.DTOs;

public class BookBasicDto : BookRegistryDto
{
    public BookBasicDto(string title, string author, string genre, string isbn,
        string description, string review)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Review = review;
    }

    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public string Isbn { get; }
    public string Description { get; }
    public string Review { get; }
}
namespace Domain.DTOs;

public class BookRegistryCreationDto
{
    public BookRegistryCreationDto()
    {
    }

    public BookRegistryCreationDto(string title, string author, string genre, string isbn, string description)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
    }


    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public string Isbn { get; }
    public string Description { get; }
    public string Review { get; }
}
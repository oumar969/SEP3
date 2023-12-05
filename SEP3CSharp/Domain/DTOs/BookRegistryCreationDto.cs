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


    public string Title { get; init; }
    public string Author { get; init; }
    public string Genre { get; init;}
    public string Isbn { get; init;}
    public string Description { get;init; }
    public string Review { get; init;}
}
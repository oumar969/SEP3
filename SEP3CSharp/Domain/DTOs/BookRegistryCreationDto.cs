namespace Domain.DTOs;

public class BookRegistryCreationDto : BookRegistryDto
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

    public string Location { get; set; }

    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string Review { get; set; }
}
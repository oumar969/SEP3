namespace Domain.DTOs;

public class BookCreationDto
{
    public string UUID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Location { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string Review { get; set; }

    public BookCreationDto(string uuid)
    {
        UUID = uuid;
    }

    public BookCreationDto(string title, string author, string genre, string location, string isbn, string description)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Location = location;
        Isbn = isbn;
        Description = description;
    }
}
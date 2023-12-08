namespace Domain.DTOs;

public class BookRegistryCreationDto
{
    public BookRegistryCreationDto()
    {
    }

    public BookRegistryCreationDto(string title, string author, string genre, string isbn, string description,
        string reviews = "",
        bool isSuccesful = false, string message = "")
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Reviews = reviews;
        IsSuccesful = isSuccesful;
        Message = message;
    }


    public string Title { get; init; }
    public string Author { get; init; }
    public string Genre { get; init; }
    public string Isbn { get; init; }
    public string Description { get; init; }
    public string Reviews { get; set; }
    public bool IsSuccesful { get; set; }
    public string Message { get; set; }
}

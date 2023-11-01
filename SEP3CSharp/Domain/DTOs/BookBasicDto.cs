namespace Domain.DTOs;

public class BookBasicDto
{
    public string UUID { get; }
    public string Title { get;  }
    public string Author { get; }
    public string Genre { get; }
    public string Location { get; }
    public string Isbn { get;  }
    public string Description { get; }
    public string Review { get; }
    public bool IsAvailable { get; set; }
    public bool IsBorrowed { get; set; }
    


    public BookBasicDto(string uuid ,string title, string author, string genre, string location, string isbn, string description, string review)
    {
        UUID = uuid;
        Title = title;
        Author = author;
        Genre = genre;
        Location = location;
        Isbn = isbn;
        Description = description;
        Review = review;
    }
}
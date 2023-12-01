using Domain.Models;

namespace Domain.DTOs;

public class BookRegistryUpdateDto
{
    public BookRegistryUpdateDto(string isbn)
    {
        Isbn = isbn;
    }

    public BookRegistryUpdateDto(string isbn, string title, string author, string genre, string description)
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        Genre = genre;
        Description = description;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Location { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string Review { get; set; }
    public int? BorrowerId { get; set; }


    public User? Borrower { get; set; } // Brugeren, der har lånt bogen    
}
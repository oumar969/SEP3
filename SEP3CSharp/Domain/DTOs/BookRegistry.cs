using Domain.Models;

namespace Domain.DTOs;

public class BookRegistry : BookRegistryDto
{
    public BookRegistry(string id,string title, string author, string genre, string isbn,
        string description, string review)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Review = review;
    }

    public BookRegistry(string id, string isbn, User borrower)
    {
        Id = id;
        Isbn = isbn;
        BorrowerId = borrower;
    }
    public BookRegistry(string title, string author, string genre, string isbn,
        string description, string review)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Review = review;
    }
    
    public string Id { get; }
    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public string Isbn { get; }
    public string Description { get; }
    public string Review { get; }
    public User BorrowerId { get; }
}
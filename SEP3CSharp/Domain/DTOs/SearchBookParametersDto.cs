using Domain.Models;

namespace Domain.DTOs;

public class SearchBookParametersDto
{
    public string? Id { get;}
    public string? Title { get;}
    public string? Author { get;}
    public string? Isbn { get;}
    public string? Genre { get;}
    public string? Description { get;}
    public string? Review { get;}
    public string? isBorrowed { get;}

    public SearchBookParametersDto(string? id, string? title, string? author, string? isbn, string? genre, string? isBorrowed)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Genre = genre;
        this.isBorrowed = isBorrowed;
        
    }
}
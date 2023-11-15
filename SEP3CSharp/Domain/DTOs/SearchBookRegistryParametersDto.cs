namespace Domain.DTOs;

public class SearchBookRegistryParametersDto
{
    public SearchBookRegistryParametersDto(string? title, string? author, string? isbn, string? genre,
        string? description, string? review)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        Genre = genre;
        Description = description;
        Review = review;
    }

    public string? Title { get; }
    public string? Author { get; }
    public string? Isbn { get; }
    public string? Genre { get; }
    public string? Description { get; }
    public string? Review { get; }
}
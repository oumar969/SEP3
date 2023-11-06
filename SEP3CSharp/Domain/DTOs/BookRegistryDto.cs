namespace Domain.DTOs;

public interface BookRegistryDto
{
    public string Title { get; }
    public string Author { get; }
    public string Genre { get; }
    public string Isbn { get; }
    public string Description { get; }
    public string Review { get; }
}
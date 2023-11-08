using Newtonsoft.Json;

namespace Domain.Models;

public class BookRegistry
{
    public BookRegistry(string title, string author, string genre, string isbn, string description,
        string reviews)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Isbn = isbn;
        Description = description;
        Reviews = reviews;
    }

    [JsonProperty("isbn")] public string Isbn { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("author")] public string Author { get; set; }

    [JsonProperty("genre")] public string Genre { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("reviews")] public string Reviews { get; set; }
}
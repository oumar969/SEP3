package FileAccessServer.Models;

public class Book
{
  private String UUID;
  private String title;
  private String author;
  private String genre;
  private String ISBN;
  private String language;
  private String description;

  public Book(String UUID, String title, String author, String genre, String ISBN, String language, String description)
  {
    this.UUID = UUID;
    this.title = title;
    this.author = author;
    this.genre = genre;
    this.ISBN = ISBN;
    this.language = language;
    this.description = description;
  }
}

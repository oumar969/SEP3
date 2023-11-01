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

  public Book(String UUID, String title, String author, String genre,
      String ISBN, String language, String description)
  {
    this.UUID = UUID;
    this.title = title;
    this.author = author;
    this.genre = genre;
    this.ISBN = ISBN;
    this.language = language;
    this.description = description;
  }

  public void setUUID(String UUID)
  {
    this.UUID = UUID;
  }

  public void setTitle(String title)
  {
    this.title = title;
  }

  public void setAuthor(String author)
  {
    this.author = author;
  }

  public void setGenre(String genre)
  {
    this.genre = genre;
  }

  public void setISBN(String ISBN)
  {
    this.ISBN = ISBN;
  }

  public void setLanguage(String language)
  {
    this.language = language;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public String getUUID()
  {
    return UUID;
  }

  public String getTitle()
  {
    return title;
  }

  public String getAuthor()
  {
    return author;
  }

  public String getGenre()
  {
    return genre;
  }

  public String getISBN()
  {
    return ISBN;
  }

  public String getLanguage()
  {
    return language;
  }

  public String getDescription()
  {
    return description;
  }
}

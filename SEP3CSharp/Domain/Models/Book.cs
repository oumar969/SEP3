namespace Domain.Models;

public class Book
{
     public string UUID { get; set; }
     public string Title { get; set; }
     public string Author { get; set; }
     public string Genre { get; set; }
     public string Location { get; set; }
     public string Isbn { get; set; }
     public string Description { get; set; }
     public string Review { get; set; }

     public User? Borrower { get; set; } // Brugeren, der har lånt bogen
     // public Librarian? Librarian { get; set; }

     public Book(string title, string author, string genre, string location, string isbn, string description, string review)
     {
          Title = title;
          Author = author;
          Genre = genre;
          Location = location;
          Isbn = isbn;
          Description = description;
          Review = review;
     }
     
     
}
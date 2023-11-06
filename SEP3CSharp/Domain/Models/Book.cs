namespace Domain.Models;

public class Book
{
    public Book(string isbn)
    {
        Isbn = isbn;
    }

    public string UUID { get; }
    public string Isbn { get; set; }

    public string LoanerUuid { get; set; }
}
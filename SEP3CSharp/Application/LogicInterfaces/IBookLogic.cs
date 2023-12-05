using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book?> LoanAsync(string bookId, string userId);
    Task<Book?> DeliverAsync(Book book, User user);
    Task<Book?> GetByUuidAsync(string uuid);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> CreateAsync(string isbn);
    Task<Book> DeleteAsync(string uuid);
}
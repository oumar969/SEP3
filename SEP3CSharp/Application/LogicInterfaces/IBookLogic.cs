using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book?> LoanAsync(string bookId, string userId);
    Task<Book?> DeliverAsync(string bookId, string userId);
    Task<Book?> GetByUuidAsync(string uuid);
    Task<IEnumerable<Book>> GetAllBooksAsync(string isbn);
    Task<Book> CreateAsync(string isbn);
    Task<Book> DeleteAsync(string uuid);
}
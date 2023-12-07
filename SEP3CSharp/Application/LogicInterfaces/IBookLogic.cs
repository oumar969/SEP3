using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book?> LoanAsync(Book book, User user);
    Task<Book?> DeliverAsync(Book book, User user);
    Task<Book?> GetByUuidAsync(string uuid);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> CreateAsync(Book book);
    Task<Book> DeleteAsync(string uuid);
}
using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao : IGenericDao<Book>
{
    Task<Book?> LoanAsync(string bookId, string userId);
    Task<Book?> DeliverAsync(Book book, User user);
    Task<Book> CreateAsync(string isbn);
}
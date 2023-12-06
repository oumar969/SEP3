using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao : IGenericDao<Book>
{
    Task<Book?> LoanAsync(string bookId, string userId);
    Task<Book?> DeliverAsync(string bookId, string userId);
    Task<Book> CreateAsync(string isbn);
    Task<IEnumerable<Book>> GetAllAsync(string isbn);
    Task<Book?> DeleteAsync(string id);
}
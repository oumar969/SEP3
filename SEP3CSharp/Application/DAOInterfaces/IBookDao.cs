using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao : IGenericDao<Book>
{
    Task<Book?> LoanAsync(Book book, User user);
    Task<Book?> DeliverAsync(Book book, User user);
}
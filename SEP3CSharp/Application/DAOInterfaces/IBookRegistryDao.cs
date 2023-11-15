using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IBookRegistryDao : IGenericDao<BookRegistry>
{
    Task<Book?> GetByIdAsync(int bookId);

}
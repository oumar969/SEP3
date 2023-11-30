using Domain.DTOs;
using Domain.Models;
using FileData;
using BookRegistry = Domain.Models.BookRegistry;

namespace Application.DaoInterfaces;

public interface IBookRegistryDao : IGenericDao<BookRegistry>
{
    Task<Book?> GetByIdAsync(int bookId);

    Task<BookRegistry> GetByIsbnAsync(string isbn);
    Task<BookRegistry> GetByBookTitleAsync(string dtoTitle);
}
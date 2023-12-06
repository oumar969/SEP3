using Domain.DTOs;
using Domain.Models;
using FileData;
using BookRegistry = Domain.Models.BookRegistry;

namespace Application.DaoInterfaces;

public interface IBookRegistryDao : IGenericDao<BookRegistry>
{
    Task<BookRegistry?> GetByIsbnAsync(string bookIsbn);

    Task<BookRegistry> GetByBookTitleAsync(string dtoTitle);

    Task<BookRegistry> DeleteAsync(string isbn);

}
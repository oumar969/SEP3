using Domain.DTOs;
using Domain.Models;
using FileData;
using BookRegistry = Domain.Models.BookRegistry;

namespace Application.DaoInterfaces;

public interface IBookRegistryDao
{
    Task<BookRegistry?> GetByIsbnAsync(string bookIsbn);

    Task<BookRegistry> GetByBookTitleAsync(string dtoTitle);

    Task<BookRegistry> DeleteAsync(string isbn);
    Task<BookRegistryCreationDto> CreateAsync(BookRegistryCreationDto dto);
    Task<BookRegistry> GetByUuidAsync(string uuid);
    Task<IEnumerable<BookRegistry>> GetAllAsync();
}
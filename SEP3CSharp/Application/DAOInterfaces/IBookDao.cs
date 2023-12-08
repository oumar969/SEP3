using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao
{
    Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto);
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<IEnumerable<Book>> GetAllAsync(string isbn);
    Task<Book> DeleteAsync(string id);
    Task<Book> GetByUuidAsync(string uuid);
}
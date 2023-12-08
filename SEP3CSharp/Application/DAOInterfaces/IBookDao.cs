using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao
{
    Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto);
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<ICollection<Book>> GetAllAsync(string isbn);
    Task<BookDeleteDto> DeleteAsync(BookDeleteDto dto);
    Task<Book> GetByUuidAsync(string uuid);
}
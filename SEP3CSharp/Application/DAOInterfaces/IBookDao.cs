using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DAOInterfaces;

public interface IBookDao
{
    Task<Book> LoanAsync(string bookId, string userId);
    Task<Book> DeliverAsync(string bookId, string userId);
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<IEnumerable<Book>> GetAllAsync(string isbn);
    Task<Book> DeleteAsync(string id);
    Task<Book> GetByUuidAsync(string uuid);
}
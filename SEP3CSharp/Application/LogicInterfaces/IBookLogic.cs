using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto);
    Task<IEnumerable<Book>> GetAllBooksAsync(string isbn);
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<Book> DeleteAsync(string isbn);
}
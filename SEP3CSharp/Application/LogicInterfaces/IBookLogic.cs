using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto);
    Task<ICollection<Book>> GetAllBooksAsync(string isbn);
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<BookDeleteDto> DeleteAsync(BookDeleteDto dto);
}
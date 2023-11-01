using Domain.Models;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book> CreateAsync(BookCreationDto dto);
    Task<IEnumerable<Book>> GetAsync(SearchBookParametersDto searchParameters);
    Task UpdateAsync(BookUpdateDto dto);
    Task DeleteAsync(int id);

    Task<BookBasicDto> GetByIdAsync(int id);
}
using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<Domain.Models.BookRegistry> CreateAsync(BookRegistryCreationDto dto);
    Task<ICollection<Book>> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters);
    Task UpdateAsync(BookRegistryUpdateDto dto);
    Task DeleteAsync(string id);
    
    Task<BookRegistry> EditAsync(int isbn, BookRegistryUpdateDto dto);
}
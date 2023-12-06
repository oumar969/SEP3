using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<BookRegistry> CreateAsync(BookRegistryCreationDto dto);
    Task<ICollection<Book>> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters);
    Task UpdateAsync(BookRegistryUpdateDto dto);
    Task<BookRegistry> DeleteAsync(string isbn);
    Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync();

    Task<BookRegistry> EditAsync(int isbn, BookRegistryUpdateDto dto);
    Task<BookRegistry> GetBookRegistryByIsbnAsync(string isbn);
}
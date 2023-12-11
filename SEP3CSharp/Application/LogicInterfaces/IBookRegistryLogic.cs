using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<BookRegistryCreationDto> CreateAsync(BookRegistryCreationDto dto);
    Task<BookRegistryDeleteDto> DeleteAsync(BookRegistryDeleteDto dto);
    Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync();

    Task<BookRegistry> EditAsync(int isbn, BookRegistryUpdateDto dto);
    Task<BookRegistry> GetBookRegistryByIsbnAsync(string isbn);
}
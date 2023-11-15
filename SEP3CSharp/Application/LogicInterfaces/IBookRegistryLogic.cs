using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<BookRegistry> CreateAsync(BookRegistryCreationDto dto);
    Task<BookRegistry> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters);
    Task UpdateAsync(BookUpdateDto dto);
    Task DeleteAsync(int id);

    Task<BookRegistryDto> GetByIdAsync(int id);
}
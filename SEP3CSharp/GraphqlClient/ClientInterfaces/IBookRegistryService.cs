using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookRegistryService
{
    Task<BookRegistryCreationDto> Create(BookRegistryCreationDto dto);
    Task<ICollection<BookRegistry>> GetBookRegistries();
    Task<BookRegistryDeleteDto> Delete(BookRegistryDeleteDto dto);
}
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookRegistryService
{
    Task<BookRegistryCreationDto> Create(BookRegistryCreationDto dto);
    Task<ICollection<BookRegistry>> GetBookRegistries();

    class BookRegistryGraphqlDto
    {
        public BookRegistry CreateBookBookRegistry { get; set; }
    }
}
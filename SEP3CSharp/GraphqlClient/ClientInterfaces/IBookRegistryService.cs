using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookRegistryService
{
    Task<string> Create(BookRegistryCreationDto dto);
    
    class BookRegistryGraphqlDto
    {
        public BookRegistry CreateBookBookRegistry { get; set; }
    }
}
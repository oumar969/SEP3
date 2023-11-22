using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    Task CreateAsync(BookRegistryCreationDto dto);
    Task<ICollection<Book>> GetAsync(
        string? userName, 
        int? userId, 
        bool? reservedStatus, 
        string? titleContains,
        string? authorContains,
        string? isbnContains,
        string? genreContains,
        string? descriptionContains,
        string? locationContains
    );
    
    Task UpdateAsync(BookUpdateDto dto);

    Task<BookBasicDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);


}
using Domain.DTOs;
using Domain.Models;
using BookRegistry = Domain.DTOs.BookRegistry;

namespace Application.LogicInterfaces;

public interface IBookRegistryLogic
{
    Task<Domain.Models.BookRegistry> CreateAsync(BookRegistryCreationDto dto);
    Task<ICollection<Book>> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters);
    Task UpdateAsync(BookUpdateDto dto);
    Task DeleteAsync(int id);

    
    Task<BookRegistry>GetAllBooksAsync();
    
    Task<BookRegistry> GetByTitleAsync(string title);
    
    Task<BookRegistry> GetByAuthorAsync(string author);
    
    Task<BookRegistry> GetByIsbnAsync(string isbn);
}
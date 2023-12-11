using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookService
{
    Task<BookCreationDto> CreateAsync(BookCreationDto dto);
    Task<BookDeleteDto> DeleteAsync(BookDeleteDto dtp);
    Task<BookUpdateDto> UpdateBook(BookUpdateDto dto);
    Task<ICollection<Book>> GetAllBooksAsync(string isbn);
}
using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book> CreateAsync(BookCreationDto dto, LibrarianCreationDto librarianCreationDto);
}
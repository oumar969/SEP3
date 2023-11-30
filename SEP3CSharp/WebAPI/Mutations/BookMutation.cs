using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using BookRegistry = Domain.Models.BookRegistry;

namespace WebAPI.Schema;

public class BookMutation
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookMutation(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }
    
    public async Task<BookRegistry> CreateBook(string title, string author, string genre, string isbn, string description)
    {
        var bookRegistry = new BookRegistryCreationDto(
            title,
            author,
            genre,
            isbn,
            description
        );

        return await _bookRegistryLogic.CreateAsync(bookRegistry);
    }
    
    
}
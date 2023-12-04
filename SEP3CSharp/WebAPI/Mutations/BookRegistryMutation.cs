using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Schema;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class BookRegistryMutation
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookRegistryMutation(BookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }

    public async Task<BookRegistry> CreateBookRegistry(string title, string author, string genre, string isbn,
        string description)
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

    public async Task DeleteBookRegistry(string isbn)
    {
        await _bookRegistryLogic.DeleteAsync(isbn);
    }

    public async Task<BookRegistry> EditBookRegistry(string isbn, string title, string author, string genre,
        string description)
    {
        var bookRegistry = new BookRegistryUpdateDto(
            isbn,
            title,
            author,
            genre,
            description
        );

        return await _bookRegistryLogic.EditAsync(Convert.ToInt32(isbn), bookRegistry);
    }
}
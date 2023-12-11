using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class BookRegistryMutation
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookRegistryMutation(IBookRegistryLogic bookRegistryLogic)
    {
        Console.WriteLine("bookregmuttt");
        _bookRegistryLogic = bookRegistryLogic;
    }

    public async Task<BookRegistryCreationDto> CreateBookRegistry(string title, string author, string genre,
        string isbn,
        string description)
    {
        Console.WriteLine("create book mutation");
        var bookRegistry = new BookRegistryCreationDto(
            title,
            author,
            genre,
            isbn,
            description
        );
        Console.WriteLine("create book mutation 2");
        BookRegistryCreationDto created = await _bookRegistryLogic.CreateAsync(bookRegistry);
        Console.WriteLine(created);
        return created;
    }


    public async Task<BookRegistryDeleteDto> DeleteBookRegistry(string isbn)
    {
        Console.WriteLine("delete book mutation");
        BookRegistryDeleteDto dto = new BookRegistryDeleteDto(isbn);
        return await _bookRegistryLogic.DeleteAsync(dto);
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
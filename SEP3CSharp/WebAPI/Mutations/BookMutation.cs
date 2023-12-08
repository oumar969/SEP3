using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class BookMutation
{
    private readonly IBookLogic _bookLogic;

    public BookMutation(IBookLogic bookLogic)
    {
        _bookLogic = bookLogic;
    }

    public async Task<BookCreationDto> CreateBook(string isbn)
    {
        BookCreationDto dto = new BookCreationDto(Guid.NewGuid().ToString(), isbn, "");
        Console.WriteLine("hej bak2");
        BookCreationDto bookCreationDto = await _bookLogic.CreateAsync(dto);
        Console.WriteLine("bookCreationDto1: " + bookCreationDto.IsSuccessful);
        Console.WriteLine("bookCreationDto2: " + bookCreationDto.Message);
        return bookCreationDto;
    }

    public async Task<Book?> DeleteBook(string isbn)
    {
        Console.WriteLine("delete book mutation");
        return await _bookLogic.DeleteAsync(isbn);
    }

    public async Task<BookUpdateDto> UpdateBook(string uuid, string isbn, string loanerUuid)
    {
        BookUpdateDto dto = new BookUpdateDto(uuid, isbn, loanerUuid);
        return await _bookLogic.UpdateAsync(dto);
    }
}
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

    public async Task<BookDeleteDto> DeleteBook(string uuid, string isbn, string loanerUuid)
    {
        BookDeleteDto dto = new BookDeleteDto(uuid, isbn, loanerUuid);
        return await _bookLogic.DeleteAsync(dto);
    }

    public async Task<BookUpdateDto> UpdateBook(string uuid, string isbn, string loanerUuid)
    {
        BookUpdateDto dto = new BookUpdateDto(uuid, isbn, loanerUuid);
        return await _bookLogic.UpdateAsync(dto);
    }
}
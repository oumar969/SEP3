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
        Console.WriteLine("hej bak2");
        return await _bookLogic.CreateAsync(isbn);
    }

    public async Task<Book> DeliverBookAsync(string bookId, string userId)
    {
        return await _bookLogic.DeliverAsync(bookId, userId);
    }

    public async Task<Book?> DeleteBook(string isbn)
    {
        Console.WriteLine("delete book mutation");
        return await _bookLogic.DeleteAsync(isbn);
    }

    public async Task<Book?> LoanBook(string bookId, string userId)
    {
        return await _bookLogic.LoanAsync(bookId, userId);
    }
}

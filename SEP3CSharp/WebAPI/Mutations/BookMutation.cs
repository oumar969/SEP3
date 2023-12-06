using Application.Logic;
using Application.LogicInterfaces;
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
    
    public async Task<Book> CreateBook(string isbn)
    {
        Console.WriteLine("hej bak");
        return await _bookLogic.CreateAsync(isbn);
    }

    public async Task<Book> DeliverBookAsync(string bookId, string userId)
    {
        return await _bookLogic.DeliverAsync(bookId, userId);
    }

    public async Task DeleteBook(string isbn)
    {
        await _bookLogic.DeleteAsync(isbn);
    }

    public async Task<Book?> LoanBook(string bookId, string userId)
    {
        return await _bookLogic.LoanAsync(bookId, userId);
    }
}
using Application.Logic;
using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Schema;

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

    public async Task<Book> DeliverBookAsync(Book book, User user)
    {
        return await _bookLogic.DeliverAsync(book, user);
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
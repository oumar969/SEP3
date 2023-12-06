using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookQuery
{
    private readonly IBookLogic _bookLogic;
    
    public BookQuery(IBookLogic bookLogic)
    {
        _bookLogic = bookLogic;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooks(string isbn)
    {
        return await _bookLogic.GetAllBooksAsync(isbn);
    }
}
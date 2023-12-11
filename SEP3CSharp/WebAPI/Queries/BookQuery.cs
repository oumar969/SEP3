using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Schema;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookQuery
{
    private readonly IBookLogic _bookLogic;

    public BookQuery(IBookLogic bookLogic)
    {
        _bookLogic = bookLogic;
    }

    public async Task<ICollection<Book>> AllBooks(string isbn)
    {
        return await _bookLogic.GetAllBooksAsync(isbn);
    }
}
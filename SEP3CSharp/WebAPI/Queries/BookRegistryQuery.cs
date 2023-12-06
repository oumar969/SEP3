using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookRegistryQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookRegistryQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }

    public async Task<IEnumerable<BookRegistry>> allBooks()
    {
        return await _bookRegistryLogic.GetAllBookRegistriesAsync();
    }
}
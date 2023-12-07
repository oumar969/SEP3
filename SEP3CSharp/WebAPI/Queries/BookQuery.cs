using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Schema;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }
    
    public async Task<IEnumerable<BookRegistry>> GetAllBook()
    {
        return await _bookRegistryLogic.GetAllBookRegistriesAsync();
    }
}
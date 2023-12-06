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

    public async Task<IEnumerable<BookRegistry>> allBookRegistries()
    {
        Console.WriteLine("allBookRegistries 1");
        return await _bookRegistryLogic.GetAllBookRegistriesAsync();
    }
}
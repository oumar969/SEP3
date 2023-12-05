using Application.LogicInterfaces;

namespace WebAPI.Schema;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }
}
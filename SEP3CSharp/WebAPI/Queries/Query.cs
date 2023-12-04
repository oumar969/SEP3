using WebAPI.Schema;

namespace WebAPI.Queries;

public class Query
{
    public UserQuery User { get; }

    public Query(UserQuery userQuery)
    {
        User = userQuery;
    }
}

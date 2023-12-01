namespace WebAPI.Schema;

public class Query
{
    public UserQuery User { get; }

    public Query(UserQuery userQuery)
    {
        User = userQuery;
    }
}

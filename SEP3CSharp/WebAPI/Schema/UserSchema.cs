
using WebAPI.Mutations;
using WebAPI.Queries;
namespace WebAPI.Schema;
 
public class UserSchema : GraphQL.Types.Schema, ISchema
{
    public UserSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<UserQuery>();
        Mutation = provider.GetRequiredService<UserMutation>();
    }

}
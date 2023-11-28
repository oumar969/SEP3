using Application.LogicInterfaces;
using Domain.DTOs;
using GraphQL.Types;
using Types;
using WebAPI.Schema;

namespace WebAPI.Queries;

public class UserQuery : ObjectGraphType
{
    public UserQuery(IUserLogic userLogic)
    {
        Field<ListGraphType<UserType>>(
            "users",
            resolve: context => userLogic.GetAllUsersAsync()
        );
       /* Field<ListGraphType<UserType>>(
            "users",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<SearchUserParametersDto>> { Name = "searchParameters" }
            ),
            resolve: context => userLogic.GetAsync()
        );
        */
    }
}
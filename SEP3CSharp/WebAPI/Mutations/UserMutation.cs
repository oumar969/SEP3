using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using GraphQL;
using GraphQL.Types;
using Types;
using WebAPI.Schema;

namespace WebAPI.Mutations;

public class UserMutation : ObjectGraphType
{
    public UserMutation(IUserLogic userLogic)
    {
        Field<UserType>(
            "createUser",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
            ),
            resolve: context =>
            {
                var userDto = context.GetArgument<UserCreationDto>("user");
                return userLogic.CreateAsync(userDto);
            
            });
        // ... other mutations
    }
}
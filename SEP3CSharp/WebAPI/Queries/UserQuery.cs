using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class UserQuery
{
    private readonly IUserLogic _userLogic;

    public UserQuery(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    public async Task<User> GetUserByUuid(string uuid)
    {
        return await _userLogic.GetByUuidAsync(uuid);
    }

    public async Task<IEnumerable<User>> allUsers()
    {
        Console.WriteLine("here xD1");
        return await _userLogic.GetAllUsersAsync();
    }


    public async Task<User> userByEmail(string email)
    {
        Console.WriteLine("here1");
        User? user = await _userLogic.GetByEmailAsync(email);
        Console.WriteLine("userQuery" + user);
        return user;
    }
}

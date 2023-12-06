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

    public async Task<User?> GetUserByUuid(string uuid)
    {
        return await _userLogic.GetByUuidAsync(uuid);
    }
    
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userLogic.GetAllUsersAsync();
    }

    
    public async Task<User?> UserByEmail(string email)
    {
        return await _userLogic.GetByEmailAsync(email);
        // User? user = await _userLogic.GetByEmailAsync(email);
        // Console.WriteLine("userQuery" + user);
        // return user;
    }

  }
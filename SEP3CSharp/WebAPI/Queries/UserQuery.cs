using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Schema;

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

    public async Task<ICollection<User>> GetAllUsers()
    {
        return await _userLogic.GetAllUsersAsync();
    }

    public async Task DeleteUser(string uuid)
    {
        await _userLogic.DeleteAsync(uuid);
    }

    public async Task<User> userByEmail(string email)
    {
        Console.WriteLine("here1");
        User user = await _userLogic.GetByEmailAsync(email);
        Console.WriteLine("userQuery" + user);
        return user;
    }
    
    public async Task<ICollection<Book>> GetAllLoanerBooks(string loanerUuid)
    {
        return await _userLogic.GetAllLoanerBooks(loanerUuid);
    }
}
using Application.LogicInterfaces;
using Domain.Models;
using System.Threading.Tasks;

namespace WebAPI.Schema;

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
    
}
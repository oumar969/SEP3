using Application.LogicInterfaces;
using Domain.Models;
using System.Threading.Tasks;

namespace WebAPI.Schema;

public class Query
{
    private readonly IUserLogic _userLogic;

    public Query(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    public string Welcome => "Welcome to Hot Chocolate!";

    public async Task<User?> GetUserByUuid(string uuid)
    {
        return await _userLogic.GetByUuidAsync(uuid);
    }
    
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userLogic.GetAllUsersAsync();
    }
    
}
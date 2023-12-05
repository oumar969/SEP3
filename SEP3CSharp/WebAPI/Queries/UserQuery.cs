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

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userLogic.GetAllUsersAsync();
    }

    public async Task DeleteUser(string uuid)
    {
        await _userLogic.DeleteAsync(uuid);
    }


    public async Task<User> EditUser(string uuid, string firstName, string lastName, string email, string password,
        bool isLibrarian)
    {
        var userUpdateDto = new UserUpdateDto(firstName, lastName, email, password, isLibrarian);

        return await _userLogic.UpdateAsync(uuid, userUpdateDto);
    }
}
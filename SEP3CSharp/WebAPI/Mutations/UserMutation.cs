using Domain.DTOs;
using Application.LogicInterfaces;
using System.Threading.Tasks;
using Domain.Models;

namespace WebAPI.Schema;

public class UserMutation
{
    private readonly IUserLogic _userLogic;

    public UserMutation(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    public async Task<User> CreateUser(string firstName, string lastName, string email, string password,
        bool isLibrarian)
    {
        var userCreationDto = new UserCreationDto(
            null, 
            firstName,
            lastName,
            email,
            password,
            isLibrarian
        );

        return await _userLogic.CreateAsync(userCreationDto);
    }
}
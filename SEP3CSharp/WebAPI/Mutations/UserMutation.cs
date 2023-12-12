using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using WebApi.Services;

namespace WebAPI.Schema;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class UserMutation
{
    private readonly IAuthService _authService;
    private readonly IBookRegistryLogic _bookRegistryLogic;
    private readonly IUserLogic _userLogic;

    public UserMutation(IUserLogic userLogic, IAuthService authServive)
    {
        _userLogic = userLogic;
        _authService = authServive;
    }

    public async Task<UserLoginDto> Login(string email, string password)
    {
        UserLoginDto userLoginDto = new UserLoginDto(email, password, "");
        Console.WriteLine("login mutation");
        return await _authService.LoginAsync(userLoginDto);
    }

    public async Task<UserCreationDto> CreateUser(string firstName, string lastName, string email, string password,
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

    public async Task<UserDeleteDto> DeleteUser(string uuid)
    {
        Console.WriteLine("delete mutation: " + uuid);
        return await _userLogic.DeleteAsync(new UserDeleteDto(uuid));
    }


    public async Task<UserUpdateDto> EditUser(string uuid, string firstName, string lastName, string email,
        string password,
        bool isLibrarian)
    {
        var userUpdateDto = new UserUpdateDto(firstName, lastName, email, password, isLibrarian);

        return await _userLogic.UpdateAsync(userUpdateDto);
    }
}
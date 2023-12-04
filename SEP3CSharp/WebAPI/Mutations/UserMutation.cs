using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using WebApi.Services;

namespace WebAPI.Schema;

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
        Console.WriteLine("login mutation");
        return await _authService.LoginAsync(email, password);
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

    public async Task DeleteUser(string uuid)
    {
        await _userLogic.DeleteAsync(uuid);
    }
}
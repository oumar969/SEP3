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
        Console.WriteLine("login mutation");
        var userLoginDto = await _authService.LoginAsync(email, password);
        Console.WriteLine("userLoginDto: " + userLoginDto);
        return userLoginDto;
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

    public async Task DeleteUser(string uuid)
    {
        await _userLogic.DeleteAsync(uuid);
    }
    
    
}
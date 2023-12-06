﻿using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using WebApi.Services;

namespace WebAPI.Mutations;

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
        Console.WriteLine("errMsg: " + userLoginDto.ErrMsg);
        return userLoginDto;
    }

    public async Task<UserCreationDto> CreateUser(string firstName, string lastName, string email, string password,
        bool isLibrarian)
    {
        Console.WriteLine("creater user mut");
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

    public async Task<bool> DeleteUser(string uuid)
    {
        try
        {
            await _userLogic.DeleteAsync(uuid);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
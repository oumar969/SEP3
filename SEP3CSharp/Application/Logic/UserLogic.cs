using System.Net.Mail;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }


    public async Task<UserCreationDto> CreateAsync(UserCreationDto dto)
    {
        Console.WriteLine("dto0: " + dto);
        var existing = await userDao.GetByEmailAsync(dto.Email);
        if (existing != null)
        {
            dto.ErrMsg = "Email already exists";
            dto.IsSuccessful = false;
            return dto;
        }

        return await userDao.CreateAsync(dto);
    }


    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    public Task<UserUpdateDto> UpdateAsync(string uuid, UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        var user = await userDao.GetByUuidAsync(uuid);
        if (user == null) throw new Exception($"User with UUID {uuid} was not found!");

        await userDao.DeleteAsync(uuid);
    }

    public Task<ICollection<User>> GetAllUsersAsync()
    {
        return userDao.GetAllUsersAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await userDao.GetByEmailAsync(email);
        // User? user = await userDao.GetByEmailAsync(email);
        // Console.WriteLine(user + "UserLogic");
        // return user;
    }

    public Task<UserUpdateDto> UpdateAsync(UserUpdateDto dto)
    {
        return userDao.UpdateAsync(dto);
    }

    public async Task<User?> GetByUuidAsync(string uuid)
    {
        return await userDao.GetByUuidAsync(uuid);
    }

    public static void ValidateData(UserCreationDto userCreationDto)
    {
        if (string.IsNullOrWhiteSpace(userCreationDto.FirstName))
            throw new Exception("First Name is required");

        if (string.IsNullOrWhiteSpace(userCreationDto.LastName))
            throw new Exception("Last Name is required");

        if (string.IsNullOrWhiteSpace(userCreationDto.Email))
            throw new Exception("Email is required");

        if (string.IsNullOrWhiteSpace(userCreationDto.Password))
            throw new Exception("Password is required");

        if (userCreationDto.FirstName.Length < 3 || userCreationDto.LastName.Length < 3)
            throw new Exception("Both First Name and Last Name must be at least 3 characters long");

        if (userCreationDto.Email.Length < 5 || !IsValidEmail(userCreationDto.Email))
            throw new Exception("Email is not valid");

        if (userCreationDto.Password.Length < 8)
        {
            throw new Exception("Password must be at least 8 characters long");
        }
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var address = new MailAddress(email);
            return address.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
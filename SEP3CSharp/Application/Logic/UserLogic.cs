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


    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        var existing = await userDao.GetByEmailAsync(dto.Email);
        if (existing != null)

            throw new Exception("User already exists");


        ValidateData(dto);

        var toCreate = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password
        };

        var created = await userDao.CreateAsync(toCreate);
        return created;
    }


    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    public Task<User> UpdateAsync(int id, UserUpdateDto dto)
    {
        var toUpdate = new User
        {
            UUID = id, FirstName = dto.FirstName, LastName = dto.LastName, Password = dto.Password, Email = dto.Email,
            IsLibrarian = dto.IsLibrarian
        };

        return userDao.UpdateAsync(toUpdate);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        var user = await userDao.GetByUuidAsync(uuid);
        if (user == null) throw new Exception($"Book with UUID {uuid} was not found!");

        await userDao.DeleteAsync(uuid);
    }


    public static void ValidateData(UserCreationDto userCreationDto)
    {
        var firstName = userCreationDto.FirstName;
        var lastName = userCreationDto.LastName;
        var email = userCreationDto.Email;
        var password = userCreationDto.Password;

        if (string.IsNullOrWhiteSpace(firstName))
            throw new Exception("First Name is required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("Last Name is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("Email is required");

        if (string.IsNullOrWhiteSpace(password))
            throw new Exception("Password is required");

        if (firstName.Length < 3 || lastName.Length < 3)
            throw new Exception("Both First Name and Last Name must be at least 3 characters long");

        if (email.Length < 5 || !IsValidEmail(email))
            throw new Exception("Email is not valid");

        if (password.Length < 8)
            throw new Exception("Password must be at least 8 characters long");
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
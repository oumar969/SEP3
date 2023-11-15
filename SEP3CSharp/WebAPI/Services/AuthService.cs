using System.ComponentModel.DataAnnotations;
using Application.Logic;
using Domain.Models;
using FileData;
using JavaPersistenceClient.DAOs;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IList<User> Users = new List<User>();
    private UserLogic userLogic;

    public AuthService()
    {
        IGenericDao<User> userDao = new UserDao();
        userLogic = new UserLogic(userDao);
    }

    public Task<User> ValidateUser(string username, string password)
    {
        //    file.LoadData();
        //    User? existingUser = file.Users.FirstOrDefault(u => 
        //       u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        ;


        Console.WriteLine(username + password);
        User? existingUser = file.Users.FirstOrDefault(u =>
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));


        if (existingUser == null) throw new Exception("User not found");

        if (!existingUser.Password.Equals(password)) throw new Exception("Password mismatch");

        return Task.FromResult(existingUser);
    }


    public Task<User> RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email cannot be null");

        if (string.IsNullOrEmpty(user.Password)) throw new ValidationException("Password cannot be null");

        return (Task<User>)Task.CompletedTask;
    }
}
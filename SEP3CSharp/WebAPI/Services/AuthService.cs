// using System.ComponentModel.DataAnnotations;
// using System.Security.Claims;
// using System.Text.Json;
// using Domain.Models;
// using FileData;
//
// using WebApi.Services;
//
// namespace WebApi.Services;
//
// public class AuthService : IAuthService
// {
//     //private FileContext file = new FileContext();
//     private readonly IList<User> Users = new List<User>();
//
//     public AuthService()
//     {
//     //    file.LoadData();
//     }
//
//     public Task LoginAsync(string username, string password)
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task LogoutAsync()
//     {
//         throw new NotImplementedException();
//     }
//
//     public Task<User> ValidateUser(string username, string password)
//     {
//         //    file.LoadData();
//         //    User? existingUser = file.Users.FirstOrDefault(u => 
//         //       u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
//         ;
//
//      
//         Console.WriteLine(username+password);
//         // User? existingUser = file.Users.FirstOrDefault(u => 
//         //     u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
//         //
//         //
//         // if (existingUser == null)
//         // {
//         //     throw new Exception("User not found");
//         // }
//         //
//         // if (!existingUser.Password.Equals(password))
//         // {
//         //     throw new Exception("Password mismatch");
//         // }
//
//         // return Task.FromResult(existingUser);
//         throw new NotImplementedException();
//     }
//     
//
//     public Task<User> RegisterUser(User user)
//     {
//
//         if (string.IsNullOrEmpty(user.Email))
//         {
//             throw new ValidationException("Email cannot be null");
//         }
//
//         if (string.IsNullOrEmpty(user.Password))
//         {
//             throw new ValidationException("Password cannot be null");
//         }
//         
//         return (Task<User>)Task.CompletedTask;
//     }
//
//     public Task<ClaimsPrincipal> GetAuthAsync()
//     {
//         throw new NotImplementedException();
//     }
//
//     public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
// }
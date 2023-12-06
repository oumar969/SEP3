using System.Security.Claims;
using Domain.DTOs;
using Domain.Models;

namespace WebApi.Services;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<UserLoginDto> LoginAsync(string username, string password);

    public Task LogoutAsync();


    Task<UserLoginDto> ValidateUser(string username, string password);
    Task<User> RegisterUser(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();
}
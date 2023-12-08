using System.Security.Claims;
using Domain.DTOs;
using Domain.Models;

namespace WebApi.Services;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<UserLoginDto> LoginAsync(UserLoginDto dto);

    public Task LogoutAsync();


    Task<UserLoginDto> ValidateUser(UserLoginDto dto);
    Task<User> RegisterUser(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();
}
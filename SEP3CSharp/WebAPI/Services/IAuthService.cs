using System.Security.Claims;
using Domain.Models;

namespace WebApi.Services;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);

    public Task LogoutAsync();

    
    Task<User> ValidateUser(string username, string password);
    Task <User>  RegisterUser(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}
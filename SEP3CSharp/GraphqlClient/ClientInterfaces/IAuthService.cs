using System.Security.Claims;
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<UserLoginDto> LoginAsync(UserLoginDto dto);
    public Task LogoutAsync();
    public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    class UserAuthGraphqlDto
    {
        public UserLoginDto Login { get; set; }
    }
}

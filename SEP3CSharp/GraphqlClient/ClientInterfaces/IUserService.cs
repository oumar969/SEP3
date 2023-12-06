using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<UserCreationDto> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);

    Task<string> Delete(string uuid);
    Task<User> GetUserDataAsync(string email);

    class UserGraphqlDto
    {
        public User CreateUser { get; set; }
        public User DeleteUser { get; set; }
        public User Login { get; set; }
    }
}
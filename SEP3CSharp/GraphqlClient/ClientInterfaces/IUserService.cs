using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<string> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);

    Task<string> Delete(string uuid);

    class UserGraphqlDto
    {
        public User CreateUser { get; set; }
        public User DeleteUser { get; set; }
    }
}
using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    Task <IEnumerable<User>> GetUsers(string? usernameContains = null);
    
    Task<User> GetUserById(int id);
    Task<User> UpdateUser(int id, UserUpdateDto dto);
    Task DeleteUser(int id);

}
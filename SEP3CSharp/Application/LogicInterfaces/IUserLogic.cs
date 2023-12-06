using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDto dto);
    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByUuidAsync(string uuid);
    public Task<User> UpdateAsync(string uuid, UserUpdateDto dto);
    public Task DeleteAsync(string id);
    public Task<ICollection<User>> GetAllUsersAsync();
    public Task<User?> GetByEmailAsync(string email);
    
}
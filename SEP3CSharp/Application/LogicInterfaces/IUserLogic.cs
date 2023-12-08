using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<UserCreationDto> CreateAsync(UserCreationDto dto);
    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByUuidAsync(string uuid);
    public Task<UserUpdateDto> UpdateAsync(UserUpdateDto dto);
    public Task DeleteAsync(string id);
    public Task<ICollection<User>> GetAllUsersAsync();
    public Task<User?> GetByEmailAsync(string email);
}
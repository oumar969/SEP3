using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDto dto);
    public Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters);
    public Task<User> UpdateAsync(int id, UserUpdateDto dto);
    public Task DeleteAsync(int id);
}
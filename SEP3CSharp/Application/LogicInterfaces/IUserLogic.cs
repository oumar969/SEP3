using Domain.Models;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<User> CreateAsync(UserCreationDto dto);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    public Task<User> UpdateAsync(int id, UserUpdateDto dto);
    public Task DeleteAsync(int id);
}
using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IUserDao : IGenericDao<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(int id);
}
using Domain.Models;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User account);// vi bruger Task, fordi vi skal bruge async.
    Task<User?> GetByUserNameAsync(string firstName,string lastName, string email, string password);// vi bruger ? fordi vi ikke er sikre på at vi får en User tilbage.
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(int id);
}
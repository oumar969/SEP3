using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IUserDao : IGenericDao<User>
{
    Task<User> GetByEmailAsync(string email);
}
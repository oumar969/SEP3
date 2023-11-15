using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IUserDao : IGenericDao<User>
{
    Task<User> GetAsync(SearchUserParametersDto searchParameters);
}
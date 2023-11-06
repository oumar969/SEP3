using Domain.DTOs;
using Domain.Models;
using FileData;

namespace JavaPersistenceClient.DAOs;

public class UserDao : IGenericDao<User>
{
    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetAsync(ISearchParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
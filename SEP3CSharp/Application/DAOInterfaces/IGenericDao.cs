using Domain.DTOs;
using Domain.Models;

namespace FileData;

public interface IGenericDao<TEntity>
{
    // Create
    Task<TEntity> CreateAsync(TEntity entity);

    // Read
    Task<TEntity> GetByUuidAsync(string uuid);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAsync(ISearchParametersDto searchParameters);

    // Update
    Task<TEntity> UpdateAsync(TEntity entity);

    // Delete
    Task<Book> DeleteAsync(string uuid);
}

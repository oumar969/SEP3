using Domain.DTOs;
using Domain.Models;

namespace FileData;

public interface IGenericDao<TEntity>
{
    
    Task<TEntity> CreateAsync(TEntity entity);

    
    Task<TEntity> GetByUuidAsync(string uuid);
    Task<ICollection<TEntity>> GetAllAsync();
    Task<ICollection<TEntity>> GetAsync(ISearchParametersDto searchParameters);

    
    Task<TEntity> UpdateAsync(TEntity entity);
    
    Task<Book> DeleteAsync(string uuid);
}
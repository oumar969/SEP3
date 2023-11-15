namespace FileData;

public interface IGenericDao<TEntity>
{
    // Create
    Task<TEntity> CreateAsync(TEntity entity);

    // Read
    Task<TEntity> GetByUuidAsync(string uuid);
    Task<ICollection<TEntity>> GetAllAsync();

    // Update
    Task<TEntity> UpdateAsync(TEntity entity);

    // Delete
    Task DeleteAsync(string uuid);
}
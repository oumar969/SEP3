using Domain.Models;


namespace Application.DaoInterfaces;

public interface ILibrarianDao
{
    Task<User?> GetByIdAsync(string id);
}
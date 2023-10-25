using Domain;

namespace Application.DaoInterfaces;

public interface ILibrarianDao
{
    Task<Librarian?> GetByIdAsync(string id);
}
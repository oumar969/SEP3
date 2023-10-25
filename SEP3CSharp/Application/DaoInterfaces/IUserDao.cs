using Domain;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<IAccount> CreateAsync(IAccount account);// vi bruger Task, fordi vi skal bruge async.
    Task<IAccount?> GetByUserNameAsync(string firstName,string lastName, string email, string password);// vi bruger ? fordi vi ikke er sikre på at vi får en User tilbage.

}
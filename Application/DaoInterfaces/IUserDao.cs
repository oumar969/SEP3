using Domain;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);// vi bruger Task, fordi vi skal bruge async.
    Task<User?> GetByUserNameAsync(string userName);// vi bruger ? fordi vi ikke er sikre på at vi får en User tilbage.

}
using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly EfcContext context;

    public UserEfcDao(EfcContext context)
    {
        this.context = context;
    }

    public async Task<IAccount> CreateAsync(IAccount account)
    {
        EntityEntry<IAccount> newAccount = await context.Accounts.AddAsync(account);
        await context.SaveChangesAsync();
        return newAccount.Entity;
    }

    public async Task<IAccount?> GetByUserNameAsync(string firstName, string lastName, string email, string password)
    {
        IAccount? existing = await context.Accounts.FirstOrDefaultAsync(account =>
            account.FirstName.ToLower() == firstName.ToLower() &&
            account.LastName.ToLower() == lastName.ToLower() &&
            account.Email.ToLower() == email.ToLower() &&
            account.Password == password
        );
        return existing;
    }
    

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        if (searchParameters.UsernameContains != null)
            usersQuery = usersQuery.Where(u =>
                u.UserName.ToLower().Contains(searchParameters.UsernameContains.ToLower()));

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await context.Users.FindAsync(id);
        return user;
    }
}
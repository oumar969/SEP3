using Application.DaoInterfaces;
using Domain.Models;
using Domain.DTOs;
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

    public async Task<User> CreateAsync(User account)
    {
        EntityEntry<User> newAccount = await context.Users.AddAsync(account);
        await context.SaveChangesAsync();
        return newAccount.Entity;
    }

    public async Task<User?> GetByUserNameAsync(string firstName, string lastName, string email, string password)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(account =>
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
                u.FirstName.ToLower().Contains(searchParameters.UsernameContains.ToLower()));

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await context.Users.FindAsync(id);
        return user;
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async  Task DeleteAsync(int id)
    {
        var existing = await context.Users.FirstOrDefaultAsync(u => u.UUID == id);

        if (existing == null)
        {
            throw new Exception($"User with ID {id} not found!");
        }

        context.Users.Remove(existing);
        await context.SaveChangesAsync();
         
    }
}
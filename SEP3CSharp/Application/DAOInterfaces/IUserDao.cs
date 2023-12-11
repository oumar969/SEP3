using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> GetByEmailAsync(string email);
    Task<UserCreationDto> CreateAsync(UserCreationDto user);
    Task<User?> GetByUuidAsync(string uuid);
    Task<User?> GetByUsernameAsync(string userName);
    Task<ICollection<User>> GetAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
    Task<UserUpdateDto> UpdateAsync(UserUpdateDto user);
    Task DeleteAsync(string uuid);
    Task<ICollection<User>> GetAllUsersAsync();
    Task<ICollection<Book>> GetAllLoanerBooks(string loanerUuid);
}
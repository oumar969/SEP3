using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<UserCreationDto> Create(UserCreationDto dto);
    Task<ICollection<User>> GetUsers(string? usernameContains = null);

    Task<UserDeleteDto> Delete(UserDeleteDto dto);
    Task<User> GetUserByEmailAsync(string email);
    Task<ICollection<Book>> GetAllLoanerBooks(string loanerUuid);

    class UserGraphqlDto
    {
        public User CreateUser { get; set; }
        public User DeleteUser { get; set; }
        public User Login { get; set; }
    }
}
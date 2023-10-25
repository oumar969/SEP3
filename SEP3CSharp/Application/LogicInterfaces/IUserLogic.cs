using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<IAccount> CreateAsync(UserCreationDto userCreationDto);

}
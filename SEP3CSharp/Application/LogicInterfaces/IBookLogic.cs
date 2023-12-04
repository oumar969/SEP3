using Domain.Models;

namespace Application.LogicInterfaces;

public interface IBookLogic
{
    Task<Book?> LoanAsync(Book book, User user);
}
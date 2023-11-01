using Domain.Models;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IBookDao
{
    Task<Book> CreateAsync(Book book);

    public Task<IEnumerable<Book>> GetAsync(SearchBookParametersDto searchParameters);

    public Task UpdateAsync(Book book);

    public Task<Book?> GetByIdAsync(int bookId);

    public Task DeleteAsync(int id);
}
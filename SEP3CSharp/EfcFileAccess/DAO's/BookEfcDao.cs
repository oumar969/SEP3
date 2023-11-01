using Application.DaoInterfaces;
using Domain.Models;
using Domain.DTOs;

namespace EfcDataAccess.DAOs;

public class BookEfcDao : IBookDao
{
    public Task<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAsync(SearchBookParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
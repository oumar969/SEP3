using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace Application.Logic;

public class BookLogic : IBookLogic
{
    private readonly IBookDao _bookDao;

    public BookLogic(IBookDao bookDao)
    {
        _bookDao = bookDao;
    }

    public async Task<Book?> LoanAsync(Book book, User user)
    {
        return await _bookDao.LoanAsync(book, user);
    }

    public async Task<Book?> DeliverAsync(Book book, User user)
    {
        return await _bookDao.DeliverAsync(book, user);
    }

    public Task<Book?> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book> DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }
}
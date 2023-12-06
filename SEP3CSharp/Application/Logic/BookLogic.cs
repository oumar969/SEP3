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

    public async Task<Book?> LoanAsync(string bookId, string userId)
    {
        return await _bookDao.LoanAsync(bookId, userId);
    }

    public async Task<Book?> DeliverAsync(string bookId, string userId)
    {
        return await _bookDao.DeliverAsync(bookId, userId);
    }

    public Task<Book?> GetByUuidAsync(string uuid)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync(string isbn)
    {
        return await _bookDao.GetAllAsync(isbn);
    }

    public async Task<Book> CreateAsync(string isbn)
    {
        Console.WriteLine("lgoc");
        return await _bookDao.CreateAsync(isbn);
    }

    public Task<Book> DeleteAsync(string uuid)
    {
        throw new NotImplementedException();
    }
}
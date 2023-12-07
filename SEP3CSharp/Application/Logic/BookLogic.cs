using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
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

    public Task<Book> GetByUuidAsync(string uuid)
    {
        return _bookDao.GetByUuidAsync(uuid);
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync(string isbn)
    {
        return await _bookDao.GetAllAsync(isbn);
    }

    public async Task<BookCreationDto> CreateAsync(string isbn)
    {
        Console.WriteLine("lgoc");
        return await _bookDao.CreateAsync(isbn);
    }

    public async Task<Book> DeleteAsync(string isbn)
    {
        return await _bookDao.DeleteAsync(isbn);
    }
}
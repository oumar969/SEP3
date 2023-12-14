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

    public async Task<BookUpdateDto> UpdateAsync(BookUpdateDto dto)
    {
        return await _bookDao.UpdateAsync(dto);
    }

    public Task<Book> GetByUuidAsync(string uuid)
    {
        return _bookDao.GetByUuidAsync(uuid);
    }

    public async Task<ICollection<Book>> GetAllBooksAsync(string isbn)
    {
        return await _bookDao.GetAllAsync(isbn);
    }

    public async Task<BookCreationDto> CreateAsync(BookCreationDto dto)
    {
        return await _bookDao.CreateAsync(dto);
    }

    public async Task<BookDeleteDto> DeleteAsync(BookDeleteDto dto)
    {
        return await _bookDao.DeleteAsync(dto);
    }
}
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class BookRegistryLogic : IBookRegistryLogic
{
    private readonly IBookRegistryDao _bookRegistryDao;
    private readonly IUserDao _userDao;


    public BookRegistryLogic(IBookRegistryDao bookRegistryDao, IUserDao userDao)
    {
        _bookRegistryDao = bookRegistryDao;
        _userDao = userDao;
    }


    public async Task<BookRegistryCreationDto> CreateAsync(BookRegistryCreationDto dto)
    {
        ValidateBookRegistry(dto);
        var created = await _bookRegistryDao.CreateAsync(dto);
        return created;
    }

    public async Task<BookRegistry> DeleteAsync(string isbn)
    {
        var book = await _bookRegistryDao.GetByIsbnAsync(isbn);
        if (book == null) throw new Exception($"Book with UUID {isbn} was not found!");
        return await _bookRegistryDao.DeleteAsync(isbn);
    }

    public Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync()
    {
        return _bookRegistryDao.GetAllAsync();
    }

    public Task<BookRegistry> EditAsync(int id, BookRegistryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> GetBookRegistryByIsbnAsync(string isbn)
    {
        return _bookRegistryDao.GetByIsbnAsync(isbn);
    }

    private void ValidateBookRegistry(BookRegistryUpdateDto bookRegistry)
    {
        if (string.IsNullOrWhiteSpace(bookRegistry.Title)) throw new Exception("Book title is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Author)) throw new Exception("Book author is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Genre)) throw new Exception("Book genre is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Isbn)) throw new Exception("Book ISBN is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Description)) throw new Exception("Book description is required.");
    }

    /*
    public async Task<Domain.Models.BookRegistry> CreateAsync(BookRegistryCreationDto dto)
    {
        var existing = await _bookRegistryDao.GetByBookTitleAsync(dto.Title);

        if (existing != null) throw new Exception("Book already exists");

        ValidateBookRegistry(dto);
        var bookRegistry = new Domain.Models.BookRegistry(dto.Title, dto.Author, dto.Genre, dto.Isbn, dto.Description, dto.Review);
        var created = await _bookRegistryDao.CreateAsync(bookRegistry);
        return created;
    }
    */

    private void ValidateBookRegistry(BookRegistry bookRegistry)
    {
        if (string.IsNullOrWhiteSpace(bookRegistry.Title)) throw new Exception("Book title is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Author)) throw new Exception("Book author is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Genre)) throw new Exception("Book genre is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Isbn)) throw new Exception("Book ISBN is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Description)) throw new Exception("Book description is required.");
    }

    private void ValidateBookRegistry(BookRegistryCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Author)) throw new Exception("Author cannot be empty.");
        if (string.IsNullOrEmpty(dto.Genre)) throw new Exception("Genre cannot be empty.");
        if (string.IsNullOrEmpty(dto.Isbn)) throw new Exception("ISBN cannot be empty.");
        if (string.IsNullOrEmpty(dto.Description)) throw new Exception("Description cannot be empty.");
    }
}
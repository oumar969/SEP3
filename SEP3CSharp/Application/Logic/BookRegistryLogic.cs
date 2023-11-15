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

    Task<BookRegistry> IBookRegistryLogic.CreateAsync(BookRegistryCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(BookUpdateDto dto)
    {
        var existing = await _bookRegistryDao.GetByUuidAsync(dto.UUID);

        if (existing == null) throw new Exception($"Book with ID {dto.UUID} not found!");

        User? user = null;
        if (dto.BorrowerId != null)
        {
            // user = await _userDao.GetByUuidAsync((int)dto.BorrowerId);
            // if (user == null) throw new Exception($"User with id {dto.BorrowerId} was not found.");
        }

        var titleToUse = dto.Title ?? existing.Title;
        var authorToUse = dto.Author ?? existing.Author;
        var genreToUse = dto.Genre ?? existing.Genre;
        var isbnToUse = dto.Isbn ?? existing.Isbn;
        var descriptionToUse = dto.Description ?? existing.Description;
        var reviewToUse = dto.Review ?? existing.Reviews;

        if (titleToUse.Length > 10) throw new Exception($"{dto.Title} cannot be longer than 10 characters.");

        BookRegistry updated = new(titleToUse, authorToUse, genreToUse, isbnToUse, descriptionToUse, reviewToUse);

        ValidateBookRegistry(updated);

        await _bookRegistryDao.UpdateAsync(updated);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistryDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> GetAsync(SearchBookRegistryParametersDto searchParameters)
    {
        return _bookRegistryDao.GetAsync(searchParameters);
    }

    public Task<ICollection<BookRegistry>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookRegistry> UpdateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(string uuid)
    {
        var book = await _bookRegistryDao.GetByUuidAsync(uuid);
        if (book == null) throw new Exception($"Book with UUID {uuid} was not found!");
        await _bookRegistryDao.DeleteAsync(uuid);
    }

    public Task<BookRegistry> CreateAsync(BookRegistry entity)
    {
        throw new NotImplementedException();
    }


    public async Task<BookRegistry> CreateAsync(BookRegistryCreationDto dto)
    {
        ValidateBookRegistry(dto);
        var bookRegistry = new BookRegistry(dto.Title, dto.Author, dto.Genre, dto.Isbn, dto.Description, dto.Review);
        var created = await _bookRegistryDao.CreateAsync(bookRegistry);
        return created;
    }

    public async Task<BookBasicDto> GetByUuidAsync(string uuid)
    {
        var bookRegistry = await _bookRegistryDao.GetByUuidAsync(uuid);
        if (bookRegistry == null) throw new Exception($"Book with UUID {uuid} not found");

        return new BookBasicDto(bookRegistry.Title, bookRegistry.Author, bookRegistry.Genre, bookRegistry.Isbn,
            bookRegistry.Description, bookRegistry.Reviews);
    }

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
        if (string.IsNullOrEmpty(dto.Location)) throw new Exception("Location cannot be empty.");
        if (string.IsNullOrEmpty(dto.Isbn)) throw new Exception("ISBN cannot be empty.");
        if (string.IsNullOrEmpty(dto.Description)) throw new Exception("Description cannot be empty.");
    }
}
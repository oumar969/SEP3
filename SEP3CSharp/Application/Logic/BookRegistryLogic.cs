﻿using Application.DaoInterfaces;
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

    public Task<ICollection<Book>> GetAsync(SearchBookRegistryParametersDto searchRegistryParameters)
    {
        return _bookRegistryDao.GetAsync(searchRegistryParameters);
    }

    public async Task UpdateAsync(BookRegistryUpdateDto dto)
    {
        var existing = await _bookRegistryDao.GetByUuidAsync(dto.Isbn);

        if (existing == null) throw new Exception($"Book with ISBN {dto.Isbn} not found!");

        ValidateBookRegistry(dto);

        existing.Title = dto.Title ?? existing.Title;
        existing.Author = dto.Author ?? existing.Author;
        existing.Genre = dto.Genre ?? existing.Genre;
        existing.Isbn = dto.Isbn ?? existing.Isbn;
        existing.Description = dto.Description ?? existing.Description;
        existing.Reviews = dto.Review ?? existing.Reviews;

        if (existing.Title.Length > 10) throw new Exception($"{existing.Title} cannot be longer than 10 characters.");

        ValidateBookRegistry(existing);

        await _bookRegistryDao.UpdateAsync(existing);
    }


    async Task<BookRegistry> IBookRegistryLogic.CreateAsync(BookRegistryCreationDto dto)
    {
        Console.WriteLine("create book mutation 3");
        ValidateBookRegistry(dto);
        Console.WriteLine("create book mutation 4");
        var newBookRegistry = new BookRegistry(dto.Title, dto.Author, dto.Genre, dto.Isbn, dto.Description, dto.Review);
        var created = await _bookRegistryDao.CreateAsync(newBookRegistry);
        return created;
    }
    /*
    public async Task<BookRegistry> GetByIsbnAsync(string id)
    {
        return await _bookRegistryDao.GetByIsbnAsync(id);
    }
*/

    public async Task DeleteAsync(string uuid)
    {
        var book = await _bookRegistryDao.GetByUuidAsync(uuid);
        if (book == null) throw new Exception($"Book with UUID {uuid} was not found!");
        await _bookRegistryDao.DeleteAsync(uuid);
    }

    public Task<ICollection<BookRegistry>> GetAllBookRegistriesAsync()
    {
        return _bookRegistryDao.GetAllAsync();
    }

    public Task<BookRegistry> EditAsync(int id, BookRegistryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    private void ValidateBookRegistry(BookRegistryUpdateDto bookRegistry)
    {
        if (string.IsNullOrWhiteSpace(bookRegistry.Title)) throw new Exception("Book title is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Author)) throw new Exception("Book author is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Genre)) throw new Exception("Book genre is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Isbn)) throw new Exception("Book ISBN is required.");

        if (string.IsNullOrWhiteSpace(bookRegistry.Description)) throw new Exception("Book description is required.");
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

    public async Task<BookRegistry> EditAsync(string id, BookRegistryCreationDto dto)
    {
        var existing = await _bookRegistryDao.GetByIsbnAsync(id);

        if (existing == null) throw new Exception($"Book with ID {id} not found!");

        ValidateBookRegistry(dto);

        existing.Title = dto.Title ?? existing.Title;
        existing.Author = dto.Author ?? existing.Author;
        existing.Genre = dto.Genre ?? existing.Genre;
        existing.Isbn = dto.Isbn ?? existing.Isbn;
        existing.Description = dto.Description ?? existing.Description;
        existing.Reviews = dto.Review ?? existing.Reviews;

        ValidateBookRegistry(existing);

        await _bookRegistryDao.UpdateAsync(existing);

        return existing;
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
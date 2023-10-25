using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class BookLogic: IBookLogic
{
    private readonly IBookDao _bookDao; 
    private readonly ILibrarianDao _librarianDao;

    public BookLogic(IBookDao bookDao, ILibrarianDao librarianDao)
    {
        _bookDao = bookDao;
        _librarianDao = librarianDao;
    }

    public async Task<Book> CreateAsync(BookCreationDto dto, LibrarianCreationDto librarianCreationDto)
    {
        Librarian? librarian = await _librarianDao.GetByIdAsync(dto.UUID);
        if (librarian == null)
        {
            throw new Exception($"Librarian with id {librarianCreationDto.UUID} was not found.");
        }

        Book book = new Book(dto.Title,dto.Author,dto.Genre,dto.Location, dto.Isbn, dto.Description);

        ValidateBook(book);

        Book created = await _bookDao.CreateAsync(book);
        return created;
    }
    
    private void ValidateBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
        {
            throw new Exception("Book title is required.");
        }

        if (string.IsNullOrWhiteSpace(book.Author))
        {
            throw new Exception("Book author is required.");
        }

        if (string.IsNullOrWhiteSpace(book.Genre))
        {
            throw new Exception("Book genre is required.");
        }

        if (string.IsNullOrWhiteSpace(book.Location))
        {
            throw new Exception("Book location is required.");
        }

        if (string.IsNullOrWhiteSpace(book.Isbn))
        {
            throw new Exception("Book ISBN is required.");
        }

        if (string.IsNullOrWhiteSpace(book.Description))
        {
            throw new Exception("Book description is required.");
        }
    }

}
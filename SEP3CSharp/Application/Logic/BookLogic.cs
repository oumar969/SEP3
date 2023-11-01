using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;
using Domain.DTOs;
using Domain.Models;


namespace Application.Logic;

public class BookLogic: IBookLogic
{
    private readonly IBookDao _bookDao; 
    private readonly IUserDao _userDao;

    public BookLogic(IBookDao bookDao, IUserDao userDao)
    {
        _bookDao = bookDao;
        _userDao = userDao;
    }

    public async Task<Book> CreateAsync(BookCreationDto dto)
    {
        User? user = await _userDao.GetByIdAsync(dto.UUID);
        if (user == null)
        {
            throw new Exception($"User with id {dto.UUID} was not found.");
        }

        ValidateBook(dto);
        Book book = new Book(dto.Title,dto.Author,dto.Genre,dto.Location,dto.Isbn,dto.Description,dto.Review);
        Book created = await _bookDao.CreateAsync(book);
        return created;    
    }

    public Task<IEnumerable<Book>> GetAsync(SearchBookParametersDto searchParameters)
    {
        return _bookDao.GetAsync(searchParameters);
    }

    public async Task UpdateAsync(BookUpdateDto dto)
    {
        Book? existing = await _bookDao.GetByIdAsync(dto.UUID);

        if (existing == null)
        {
            throw new Exception($"Book with ID {dto.UUID} not found!");
        }

        User? user = null;
        if (dto.BorrowerId != null)
        {
            user = await _userDao.GetByIdAsync((int)dto.BorrowerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.BorrowerId} was not found.");
            }
        }

        User userToUse = user ?? existing.Borrower;
        string titleToUse = dto.Title ?? existing.Title;
        string authorToUse = dto.Author ?? existing.Author;
        string genreToUse = dto.Genre ?? existing.Genre;
        string locationToUse = dto.Location ?? existing.Location;
        string isbnToUse = dto.Isbn ?? existing.Isbn;
        string descriptionToUse = dto.Description ?? existing.Description;
        string reviewToUse = dto.Review ?? existing.Review;

        if (titleToUse.Length > 10)
        {
            throw new Exception($"{dto.Title} cannot be longer than 10 characters.");
        }
        
        Book updated = new (titleToUse,authorToUse,genreToUse,locationToUse,isbnToUse,descriptionToUse,reviewToUse)
        {
            UUID = existing.UUID,
        };

        ValidateBook(updated);

        await _bookDao.UpdateAsync(updated);
    }

    public async Task DeleteAsync(int id)
    {
        Book? book = await _bookDao.GetByIdAsync(id);
        if (book == null)
        {
            throw new Exception($"Book with ID {id} was not found!");
        }
        await _bookDao.DeleteAsync(id);    
    }

    public async Task<BookBasicDto> GetByIdAsync(int id)
    {
        Book? Book = await _bookDao.GetByIdAsync(id);
        if (Book == null)
        {
            throw new Exception($"Book with id {id} not found");
        }

        return new BookBasicDto(Book.UUID, Book.Title, Book.Author, Book.Genre,Book.Location,Book.Isbn,Book.Description,Book.Review);    
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
    
    private void ValidateBook(BookCreationDto dto)
    {
        if (dto.UUID == 0)
        {
            throw new Exception("UUID cannot be 0.");
        }
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Author)) throw new Exception("Author cannot be empty.");
        if (string.IsNullOrEmpty(dto.Genre)) throw new Exception("Genre cannot be empty.");
        if (string.IsNullOrEmpty(dto.Location)) throw new Exception("Location cannot be empty.");
        if (string.IsNullOrEmpty(dto.Isbn)) throw new Exception("ISBN cannot be empty.");
        if (string.IsNullOrEmpty(dto.Description)) throw new Exception("Description cannot be empty.");
    }

   
}
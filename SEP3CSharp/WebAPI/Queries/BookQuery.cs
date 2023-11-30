using Application.LogicInterfaces;
using Domain.Models;

namespace WebAPI.Schema;

public class BookQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }
    
    public async Task<IEnumerable<BookRegistry>> GetAllBooks()
    {
        return await _bookRegistryLogic.GetAllBooksAsync();
    }
    
    public async Task<IEnumerable<BookRegistry>> GetBooksByTitle(string title)
    {
        return await _bookRegistryLogic.GetByTitleAsync(title);
    }
    
    public async Task<IEnumerable<BookRegistry>> GetBooksByAuthor(string author)
    {
        return await _bookRegistryLogic.GetByAuthorAsync(author);
    }
    
    public async Task<IEnumerable<BookRegistry>> GetBooksByIsbn(string isbn)
    {
        return await _bookRegistryLogic.GetByIsbnAsync(isbn);
    }
    
    

    
}
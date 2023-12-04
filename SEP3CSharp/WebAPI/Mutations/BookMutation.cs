using Application.Logic;
using Domain.Models;

namespace WebAPI.Schema;

public class BookMutation
{
    private readonly BookLogic _bookLogic;
    
    public BookMutation(BookLogic bookLogic)
    {
        _bookLogic = bookLogic;
    }
    
    public async Task<Book> DeliverBookAsync(Book book, User user)
    {
        return await _bookLogic.DeliverAsync(book, user);
    }
}
using Domain;

namespace Application.DaoInterfaces;

public interface IBookDao
{
    Task<Book> CreateAsync(Book book);
     
    
}
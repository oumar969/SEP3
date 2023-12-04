using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Schema;

public class BookQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }
    
    public async Task DeleteBookRegistry(string isbn)
    {
        await _bookRegistryLogic.DeleteAsync((isbn));
    }
    
    public async Task<BookRegistry> EditBookRegistry(string isbn, string title, string author, string genre, string description)
    {
        var bookRegistry = new BookRegistryUpdateDto(
            isbn,
            title,
            author,
            genre,
            description
        );

        return await _bookRegistryLogic.EditAsync(Convert.ToInt32(isbn), bookRegistry);
    }
    
    
    

}
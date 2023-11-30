using Domain.DTOs;
using Application.LogicInterfaces;
using System.Threading.Tasks;
using Domain.Models;
using BookRegistry = Domain.Models.BookRegistry;

namespace WebAPI.Schema;

public class Mutation
{
    private readonly IUserLogic _userLogic;
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public Mutation(IUserLogic userLogic, IBookRegistryLogic bookRegistryLogic)
    {
        _userLogic = userLogic;
        _bookRegistryLogic = bookRegistryLogic;
    }

    public async Task<User> CreateUser(string firstName, string lastName, string email, string password,
        bool isLibrarian)
    {
        var userCreationDto = new UserCreationDto(
            null, 
            firstName,
            lastName,
            email,
            password,
            isLibrarian
        );

        return await _userLogic.CreateAsync(userCreationDto);
    }
    
    public async Task<BookRegistry> CreateBookRegistry(string title, string author, string genre, string isbn, string description)
    {
        var bookRegistry = new BookRegistryCreationDto(
            title,
            author,
            genre,
            isbn,
            description
        );

        return await _bookRegistryLogic.CreateAsync(bookRegistry);
    }

}
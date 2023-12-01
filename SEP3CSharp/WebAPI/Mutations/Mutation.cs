﻿using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Schema;

public class Mutation
{
    private readonly IBookRegistryLogic _bookRegistryLogic;
    private readonly IUserLogic _userLogic;

    public Mutation(IUserLogic userLogic, IBookRegistryLogic bookRegistryLogic)
    {
        _userLogic = userLogic;
        _bookRegistryLogic = bookRegistryLogic;
    }

    /* BOOK REGISTRY */

    public async Task<BookRegistry> CreateBookRegistry(string title, string author, string genre, string isbn,
        string description)
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

    public async Task DeleteBookRegistry(string isbn)
    {
        await _bookRegistryLogic.DeleteAsync(isbn);
    }


    /*Book*/
    public async Task DeleteBook(string id)
    {
        await _bookRegistryLogic.DeleteAsync(id);
    }

    public async Task<BookRegistry> EditRegistryBook(string isbn, string title, string author, string genre,
        string description)
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

    /*USER*/

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

    public async Task DeleteUser(string id)
    {
        await _userLogic.DeleteAsync(id);
    }
}
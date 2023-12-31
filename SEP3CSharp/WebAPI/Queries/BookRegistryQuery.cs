﻿using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class BookRegistryQuery
{
    private readonly IBookRegistryLogic _bookRegistryLogic;

    public BookRegistryQuery(IBookRegistryLogic bookRegistryLogic)
    {
        _bookRegistryLogic = bookRegistryLogic;
    }

    public async Task<ICollection<BookRegistry>> AllBookRegistries()
    {
        Console.WriteLine("allBookRegistries 1");
        ICollection<BookRegistry> bookRegistries = await _bookRegistryLogic.GetAllBookRegistriesAsync();
        Console.WriteLine("allBookRegistries 2: " + bookRegistries.Count());
        return bookRegistries;
    }

    public async Task<BookRegistry> GetBookByIsbn(string isbn)
    {
        return await _bookRegistryLogic.GetBookRegistryByIsbnAsync(isbn);
    }
}
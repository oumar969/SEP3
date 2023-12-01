﻿using Application.LogicInterfaces;
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
    
    
    
    

}
using Domain.Models;
using HotChocolate.AspNetCore;
using JavaPersistenceClient.DAOs;

namespace WebAPI.Queries;

public class BookQuery
{
    public IQueryable<Book> GetBook([Service] BookRegistryDao)
    {
        
    }
}
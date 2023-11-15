using Domain.DTOs;
using Domain.Models;
using FileData;

namespace Application.DaoInterfaces;

public interface IBookRegistryDao : IGenericDao<BookRegistry>
{
    Task<BookRegistry> GetAsync(SearchBookRegistryParametersDto email);
}
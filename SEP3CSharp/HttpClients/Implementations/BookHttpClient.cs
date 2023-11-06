using System.Text;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class BookHttpClient : IBookService
{
    private readonly HttpClient client;

    public BookHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public Task CreateAsync(BookRegistryCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Book>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(BookUpdateDto dto)
    {
        
    }

    public Task<BookBasicDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}